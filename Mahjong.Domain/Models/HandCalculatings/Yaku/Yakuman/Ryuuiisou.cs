namespace Mahjong.Domain.Models.HandCalculatings.Yaku.Yakuman;

internal class Ryuuiisou : YakuBase
{
    public override int YakuId => 41;

    public override int TenhouId => 43;

    public override string Name => "Ryuuiisou";

    public override string Japanese => "緑一色";

    public override string English => "All Green";

    public override int HanOpen { get; set; } = 13;

    public override int HanClosed { get; set; } = 13;

    public override bool IsYakuman => true;
}