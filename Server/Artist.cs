// Read ​​ ZSearch Artist.cs
// 2023-04-29 @ 8:46 PM
// ReSharper disable InconsistentNaming

using JetBrains.Annotations;

namespace ZSearch.Server;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class Artist
{
    public int id { get; set; }
    public string name { get; set; }
    public string link { get; set; }
    public string picture { get; set; }
    public string picture_small { get; set; }
    public string picture_medium { get; set; }
    public string picture_big { get; set; }
    public string picture_xl { get; set; }
    public string tracklist { get; set; }
    public string type { get; set; }
}