namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Akadora : YakuBase
{
    public override int YakuId => 54;

    public override int TenhouId => 54;

    public override string Name => "Aka Dora";

    public override string Japanese => "赤ドラ";

    public override string English => "Red Five";

    public override int HanOpen { get; set; } = 1;

    public override int HanClosed { get; set; } = 1;

    public override bool IsYakuman => false;

    public override string ToString()
    {
        return $"Aka Dora {HanClosed}";
    }
}