namespace Mahjong.Domain.Models.HandCalculatings.Yaku.Yakuman;

internal class Suuankou : YakuBase
{
    public override int YakuId => 38;

    public override int TenhouId => 41;

    public override string Name => "Suuankou";

    public override string Japanese => "四暗刻";

    public override string English => "Four Concealed Triplets";

    public override int HanOpen { get; set; } = 0;

    public override int HanClosed { get; set; } = 13;

    public override bool IsYakuman => true;
}