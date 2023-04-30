// Read ​​ ZSearch ResultRoot.cs
// 2023-04-29 @ 8:46 PM
// ReSharper disable InconsistentNaming

using JetBrains.Annotations;

namespace ZSearch.Server;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class ResultRoot
{
    public List<Item> data { get; set; }
    public int total { get; set; }
}