using Mahjong.Model.Fuuro;
using Mahjong.Model.Hands;
using Mahjong.Model.Tiles;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 白
/// </summary>
public record Haku : Yaku
{
    public override string Name => "白";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(Hand hand, FuuroList fuuroList)
    {
        return hand.ConcatFuuro(fuuroList).IncludesKoutsu(Tile.Haku);
    }
}
