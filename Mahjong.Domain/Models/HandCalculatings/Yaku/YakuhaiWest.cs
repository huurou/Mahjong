namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class YakuhaiWest : YakuBase
{
    public override int YakuId => 18;

    public override int TenhouId => 10;

    public override string Name => "Yakuhai (west)";

    public override string Japanese => "役牌(西)";

    public override string English => "West Round/Seat";

    public override int HanOpen { get; set; } = 1;

    public override int HanClosed { get; set; } = 1;

    public override bool IsYakuman => false;
}