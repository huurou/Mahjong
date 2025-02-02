using Mahjong.Model.Fuuro;
using Mahjong.Model.Hands;
using Mahjong.Model.Tiles;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 緑一色
/// </summary>
public record Ryuuiisou : Yaku
{
    public override string Name => "緑一色";
    public override int HanOpen => 13;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;
    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        var greens = new[] { Tile.Sou2, Tile.Sou3, Tile.Sou4, Tile.Sou6, Tile.Sou8, Tile.Hatsu };
        return hand.SelectMany(x => x).All(x => greens.Contains(x));
    }
}
