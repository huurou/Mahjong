namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Honitsu : YakuBase
{
    public override int YakuId => 32;

    public override int TenhouId => 34;

    public override string Name => "Honitsu";

    public override string Japanese => "混一色";

    public override string English => "Half Flush";

    public override int HanOpen { get; set; } = 2;

    public override int HanClosed { get; set; } = 3;

    public override bool IsYakuman => false;
}