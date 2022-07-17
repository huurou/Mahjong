namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Hatsu : YakuBase
{
    public override int YakuId => 14;

    public override int TenhouId => 19;

    public override string Name => "Yakuhai (hatsu)";

    public override string Japanese => "役牌(發)";

    public override string English => "Green Dragon";

    public override int HanOpen { get; set; } = 1;

    public override int HanClosed { get; set; } = 1;

    public override bool IsYakuman => false;
}