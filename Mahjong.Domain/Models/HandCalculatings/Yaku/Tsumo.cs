namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Tsumo : YakuBase
{
    public override int YakuId => 0;
    public override int TenhouId => 0;
    public override string Name => "Menzen Tsumo";
    public override string Japanese => "門前清自摸和";
    public override string English => "Self Draw";
    public override int HanOpen { get; set; } = 0;
    public override int HanClosed { get; set; } = 1;
    public override bool IsYakuman => false;
}