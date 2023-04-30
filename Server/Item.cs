// Read ​​ ZSearch Item.cs
// 2023-04-29 @ 8:46 PM
// ReSharper disable InconsistentNaming

using JetBrains.Annotations;

namespace ZSearch.Server;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class Item
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

	public override string ToString()
	{
		return
			$"{nameof(id)}: {id}, {nameof(readable)}: {readable}, \n" +
			$"{nameof(title)}: {title}, {nameof(title_short)}: {title_short}, {nameof(title_version)}: {title_version}, \n" +
			$"{nameof(link)}: {link}, {nameof(duration)}: {duration}, {nameof(rank)}: {rank}, {nameof(explicit_lyrics)}: {explicit_lyrics}, \n" +
			$"{nameof(explicit_content_lyrics)}: {explicit_content_lyrics}, {nameof(explicit_content_cover)}: {explicit_content_cover}, \n" +
			$"{nameof(preview)}: {preview}, {nameof(md5_image)}: {md5_image}, {nameof(artist)}: {artist}, {nameof(album)}: {album}, \n" +
			$"{nameof(type)}: {type}";
	}
}