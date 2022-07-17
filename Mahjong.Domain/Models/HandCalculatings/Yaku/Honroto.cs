namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Honroto : YakuBase
{
    public override int YakuId => 25;

    public override int TenhouId => 31;

    public override string Name => "Honroto";

    public override string Japanese => "混老頭";

    public override string English => "Terminals and Honors";

    public override int HanOpen { get; set; } = 2;

    public override int HanClosed { get; set; } = 2;

    public override bool IsYakuman => false;
}