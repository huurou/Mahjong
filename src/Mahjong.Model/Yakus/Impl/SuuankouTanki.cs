using Mahjong.Model.Hands;
using Mahjong.Model.Tiles;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 四暗刻単騎待ち
/// </summary>
public record SuuankouTanki : Yaku
{
    public override string Name => "四暗刻単騎";
    public override int HanOpen => 26;
    public override int HanClosed => 26;
    public override bool IsYakuman => true;
    public static bool Valid(Hand hand, Tile winTile)
    {
        var mans = hand.Where(x => x.IsAllMan);
        var pins = hand.Where(x => x.IsAllPin);
        var sous = hand.Where(x => x.IsAllSou);
        var suits = new[] { mans, pins, sous }.Where(x => x.Any());
        if (hand.All(x => x.IsAllMan) && winTile.IsMan ||
            hand.All(x => x.IsAllPin) && winTile.IsPin ||
            hand.All(x => x.IsAllSou) && winTile.IsSou)
        {
            return false;
        }
        var nums = hand.SelectMany(x => x, (_, x) => x.Number).ToList();
        // numsは 1112345678999+アガリ牌 になっているはず
        foreach (var n in new[] { 1, 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 9, 9 })
        {
            if (!nums.Remove(n)) { return false; }
        }
        return nums.Count == 1 && nums.ElementAt(0) == winTile.Number;
    }
}
