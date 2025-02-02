using Mahjong.Model.Hands;
using Mahjong.Model.Tiles;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 国士無双
/// </summary>
public record Kokushimusou : Yaku
{
    public override string Name => "国士無双";
    public override int HanOpen => 0;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;

    public static bool Valid(Hand hand)
    {
        var tiles = hand.SelectMany(x => x).ToList();
        foreach (var yaochuu in Tile.Yaochuus)
        {
            if (!tiles.Remove(yaochuu)) { return false; }
        }
        return tiles.Count == 1 && tiles[0].IsYaochuu;
    }
}
