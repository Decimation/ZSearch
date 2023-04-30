using Flurl;
using Flurl.Http;
using JetBrains.Annotations;
using Spectre.Console;

// ReSharper disable InconsistentNaming

namespace ZSearch;

public static class Program
{
	private const string BASE_URL = "https://free-mp3-download.net/search.php";

	public static async Task<int> Main(string[] args)
	{

		string query = null;

		if (args.Length == 0) {
			query = Console.ReadLine();
		}
		else {
			query = args[0];
		}

		Url u = BASE_URL.SetQueryParam("s", query, true);

		var r = await u.GetAsync();
		var j = await r.GetJsonAsync<Root>();

		Console.WriteLine($"{j.total}");

		foreach (Datum d1 in j.data) {
			Console.WriteLine($"{d1}");
		}

		return 0;
	}
}

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class Album
{
	public int    id           { get; set; }
	public string title        { get; set; }
	public string cover        { get; set; }
	public string cover_small  { get; set; }
	public string cover_medium { get; set; }
	public string cover_big    { get; set; }
	public string cover_xl     { get; set; }
	public string md5_image    { get; set; }
	public string tracklist    { get; set; }
	public string type         { get; set; }
}

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class Artist
{
	public int    id             { get; set; }
	public string name           { get; set; }
	public string link           { get; set; }
	public string picture        { get; set; }
	public string picture_small  { get; set; }
	public string picture_medium { get; set; }
	public string picture_big    { get; set; }
	public string picture_xl     { get; set; }
	public string tracklist      { get; set; }
	public string type           { get; set; }
}

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class Datum
{
	public long   id                      { get; set; }
	public bool   readable                { get; set; }
	public string title                   { get; set; }
	public string title_short             { get; set; }
	public string title_version           { get; set; }
	public string link                    { get; set; }
	public int    duration                { get; set; }
	public int    rank                    { get; set; }
	public bool   explicit_lyrics         { get; set; }
	public int    explicit_content_lyrics { get; set; }
	public int    explicit_content_cover  { get; set; }
	public string preview                 { get; set; }
	public string md5_image               { get; set; }
	public Artist artist                  { get; set; }
	public Album  album                   { get; set; }
	public string type                    { get; set; }
}

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class Root
{
	public List<Datum> data  { get; set; }
	public int         total { get; set; }
}