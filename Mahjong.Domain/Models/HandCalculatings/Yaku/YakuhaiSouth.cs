namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class YakuhaiSouth : YakuBase
{
    public override int YakuId => 17;

    public override int TenhouId => 10;

    public override string Name => "Yakuhai (south)";

    public override string Japanese => "役牌(南)";

    public override string English => "South Round/Seat";

    public override int HanOpen { get; set; } = 1;

    public override int HanClosed { get; set; } = 1;

    public override bool IsYakuman => false;
}