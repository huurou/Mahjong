namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class YakuhaiEast : YakuBase
{
    public override int YakuId => 16;

    public override int TenhouId => 10;

    public override string Name => "Yakuhai (east)";

    public override string Japanese => "役牌(東)";

    public override string English => "East Round/Seat";

    public override int HanOpen { get; set; } = 1;

    public override int HanClosed { get; set; } = 1;

    public override bool IsYakuman => false;
}