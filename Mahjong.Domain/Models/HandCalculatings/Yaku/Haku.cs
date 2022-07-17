namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Haku : YakuBase
{
    public override int YakuId => 13;

    public override int TenhouId => 18;

    public override string Name => "Yakuhai (haku)";

    public override string Japanese => "役牌(白)";

    public override string English => "White Dragon";

    public override int HanOpen { get; set; } = 1;

    public override int HanClosed { get; set; } = 1;

    public override bool IsYakuman => false;
}