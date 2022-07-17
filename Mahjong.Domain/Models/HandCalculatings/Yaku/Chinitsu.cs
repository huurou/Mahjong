namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Chinitsu : YakuBase
{
    public override int YakuId => 35;

    public override int TenhouId => 35;

    public override string Name => "Chinitsu";

    public override string Japanese => "清一色";

    public override string English => "Flush";

    public override int HanOpen { get; set; } = 5;

    public override int HanClosed { get; set; } = 6;

    public override bool IsYakuman => false;
}