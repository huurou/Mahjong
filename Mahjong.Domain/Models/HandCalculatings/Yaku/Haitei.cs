namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class Haitei : YakuBase
{
    public override int YakuId => 5;
    public override int TenhouId => 5;
    public override string Name => "Haitei Raoyue";
    public override string Japanese => "海底摸月";
    public override string English => "Win By Last Draw";
    public override int HanOpen { get; set; } = 1;
    public override int HanClosed { get; set; } = 1;
    public override bool IsYakuman => false;
}