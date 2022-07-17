namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Dora : YakuBase
{
    public override int YakuId => 53;

    public override int TenhouId => 52;

    public override string Name => $"Dora{HanClosed}";

    public override string Japanese => $"ドラ{HanClosed}";

    public override string English => $"Dora{HanClosed}";

    public override int HanOpen { get; set; } = 1;

    public override int HanClosed { get; set; } = 1;

    public override bool IsYakuman => false;

    public override string ToString()
    {
        return $"Dora {HanClosed}";
    }
}