using System.Diagnostics;
using Flurl;
using Flurl.Http;
using Spectre.Console;
using ZSearch.Server;

// ReSharper disable InconsistentNaming

namespace ZSearch;

public static class Program
{
	private static readonly FlurlClient Client = new FlurlClient();

	private const string BASE_URL = "https://free-mp3-download.net/search.php";

	static Program()
	{
		FlurlHttp.Configure(settings =>
		{
			settings.Redirects.Enabled                    = true; // default true
			settings.Redirects.AllowSecureToInsecure      = true; // default false
			settings.Redirects.ForwardAuthorizationHeader = true; // default false
			settings.Redirects.MaxAutoRedirects           = 5;    // default 10 (consecutive)
		});

	}

	public static async Task<int> Main(string[] args)
	{

		string query = null;

		if (args.Length == 0) {
			query = Console.ReadLine();
		}
		else {
			query = args[0];
		}

		Client.OnRedirect(call =>
		{
			call.Redirect.ChangeVerbToGet = (call.Response.StatusCode == 301);
			call.Redirect.Follow          = true;
			Debug.WriteLine($"{call.Redirect.Url}");
		});

		CookieJar cj = new CookieJar();

		var r1 = await Client.Request("https://free-mp3-download.net/")
			         .WithCookies(cj)
			         .GetAsync();

		foreach (FlurlCookie c in cj) {
			Debug.WriteLine($"{c.Name} {c.Value}");
		}

		var u = Client.Request(BASE_URL)
			.SetQueryParam("s", query, true)
			.WithAutoRedirect(true)
			.AllowAnyHttpStatus()
			.WithCookies(cj);

		var r = await u.GetAsync();
		var j = await r.GetJsonAsync<ResultRoot>();

		Debug.WriteLine($"{r.ResponseMessage.Content.Headers}");
		Console.WriteLine($"{j.total}");

		foreach (Item d1 in j.data) {
			Console.WriteLine($"{d1}");
		}

		return 0;
	}
}