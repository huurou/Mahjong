namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Sanshoku : YakuBase
{
    public override int YakuId => 22;

    public override int TenhouId => 25;

    public override string Name => "Sanshoku Doujun";

    public override string Japanese => "三色同順";

    public override string English => "Three Colored Triplets";

    public override int HanOpen { get; set; } = 1;

    public override int HanClosed { get; set; } = 2;

    public override bool IsYakuman => false;
}