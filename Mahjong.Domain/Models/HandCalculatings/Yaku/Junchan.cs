namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Junchan : YakuBase
{
    public override int YakuId => 33;

    public override int TenhouId => 13;

    public override string Name => "Junchan";

    public override string Japanese => "純全帯幺九";

    public override string English => "Terminal In Each Meld";

    public override int HanOpen { get; set; } = 2;

    public override int HanClosed { get; set; } = 3;

    public override bool IsYakuman => false;
}