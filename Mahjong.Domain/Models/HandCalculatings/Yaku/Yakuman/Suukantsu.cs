namespace Mahjong.Domain.Models.HandCalculatings.Yaku.Yakuman;

internal class Suukantsu : YakuBase
{
    public override int YakuId => 42;

    public override int TenhouId => 51;

    public override string Name => "Suukantsu";

    public override string Japanese => "四槓子";

    public override string English => "Four Kans";

    public override int HanOpen { get; set; } = 13;

    public override int HanClosed { get; set; } = 13;

    public override bool IsYakuman => true;
}