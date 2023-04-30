// Read ​​ ZSearch Album.cs
// 2023-04-29 @ 8:46 PM

using JetBrains.Annotations;
// ReSharper disable InconsistentNaming

namespace ZSearch.Server;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class Album
{
    public int id { get; set; }
    public string title { get; set; }
    public string cover { get; set; }
    public string cover_small { get; set; }
    public string cover_medium { get; set; }
    public string cover_big { get; set; }
    public string cover_xl { get; set; }
    public string md5_image { get; set; }
    public string tracklist { get; set; }
    public string type { get; set; }
}