using Mahjong.Model.Hands;
using Mahjong.Model.Tiles;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 国士無双十三面待ち
/// </summary>
public record Kokushimusou13 : Yaku
{
    public override string Name => "国士無双十三面待ち";
    public override int HanOpen => 0;
    public override int HanClosed => 26;
    public override bool IsYakuman => true;
    public static bool Valid(Hand hand, Tile winTile)
    {
        return hand.SelectMany(x => x).Count(x => x == winTile) == 2 &&
            Kokushimusou.Valid(hand);
    }
}
