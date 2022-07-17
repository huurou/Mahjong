namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Sanankou : YakuBase
{
    public override int YakuId => 27;

    public override int TenhouId => 29;

    public override string Name => "San Ankou";

    public override string Japanese => "三暗刻";

    public override string English => "Tripple Concealed Triplets";

    public override int HanOpen { get; set; } = 2;

    public override int HanClosed { get; set; } = 2;

    public override bool IsYakuman => false;
}