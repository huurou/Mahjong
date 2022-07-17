namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Rinshan : YakuBase
{
    public override int YakuId => 4;
    public override int TenhouId => 4;
    public override string Name => "Rinshan Kaihou";
    public override string Japanese => "嶺上開花";
    public override string English => "Dead Wall Draw";
    public override int HanOpen { get; set; } = 1;
    public override int HanClosed { get; set; } = 1;
    public override bool IsYakuman => false;
}