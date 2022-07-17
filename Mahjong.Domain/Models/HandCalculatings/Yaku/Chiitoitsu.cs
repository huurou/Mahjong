namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Chiitoitsu : YakuBase
{
    public override int YakuId => 30;

    public override int TenhouId => 22;

    public override string Name => "Chiitoitsu";

    public override string Japanese => "七対子";

    public override string English => "Seven Pairs";

    public override int HanOpen { get; set; } = 0;

    public override int HanClosed { get; set; } = 2;

    public override bool IsYakuman => false;
}