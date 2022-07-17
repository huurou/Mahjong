namespace Mahjong.Domain.Models.HandCalculatings.Yaku.Yakuman;

internal class Chinroutou : YakuBase
{
    public override int YakuId => 44;

    public override int TenhouId => 44;

    public override string Name => "Chinroutou";

    public override string Japanese => "清老頭";

    public override string English => "All Terminals";

    public override int HanOpen { get; set; } = 13;

    public override int HanClosed { get; set; } = 13;

    public override bool IsYakuman => true;
}