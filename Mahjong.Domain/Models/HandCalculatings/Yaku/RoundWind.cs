namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class RoundWind : YakuBase
{
    public override int YakuId => 21;

    public override int TenhouId => 11;

    public override string Name => "Yakuhai (wind of round)";

    public override string Japanese => "場風";

    public override string English => "Value Tiles (Round)";

    public override int HanOpen { get; set; } = 1;

    public override int HanClosed { get; set; } = 1;

    public override bool IsYakuman => false;
}