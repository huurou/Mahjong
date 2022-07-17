namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Chun : YakuBase
{
    public override int YakuId => 15;

    public override int TenhouId => 20;

    public override string Name => "Yakuhai (chun)";

    public override string Japanese => "役牌(中)";

    public override string English => "Red Dragon";

    public override int HanOpen { get; set; } = 1;

    public override int HanClosed { get; set; } = 1;

    public override bool IsYakuman => false;
}