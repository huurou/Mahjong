namespace Mahjong.Domain.Models.HandCalculatings.Yaku.Yakuman;

internal class ChuurenPoutou : YakuBase
{
    public override int YakuId => 37;

    public override int TenhouId => 45;

    public override string Name => "ChuurenPoutou";

    public override string Japanese => "九蓮宝燈";

    public override string English => "Nine Gates";

    public override int HanOpen { get; set; } = 0;

    public override int HanClosed { get; set; } = 13;

    public override bool IsYakuman => true;
}