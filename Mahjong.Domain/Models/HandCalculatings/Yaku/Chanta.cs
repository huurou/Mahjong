namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Chanta : YakuBase
{
    public override int YakuId => 24;

    public override int TenhouId => 23;

    public override string Name => "Chanta";

    public override string Japanese => "混全帯幺九";

    public override string English => "Terminal Or Honor In Each Group";

    public override int HanOpen { get; set; } = 1;

    public override int HanClosed { get; set; } = 2;

    public override bool IsYakuman => false;
}