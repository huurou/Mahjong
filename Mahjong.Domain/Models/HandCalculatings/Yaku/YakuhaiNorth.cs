namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class YakuhaiNorth : YakuBase
{
    public override int YakuId => 19;

    public override int TenhouId => 10;

    public override string Name => "Yakuhai (north)";

    public override string Japanese => "役牌(北)";

    public override string English => "North Round/Seat";

    public override int HanOpen { get; set; } = 1;

    public override int HanClosed { get; set; } = 1;

    public override bool IsYakuman => false;
}