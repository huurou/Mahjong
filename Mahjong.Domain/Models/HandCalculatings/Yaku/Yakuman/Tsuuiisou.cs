namespace Mahjong.Domain.Models.HandCalculatings.Yaku.Yakuman;

internal class Tsuuiisou : YakuBase
{
    public override int YakuId => 43;

    public override int TenhouId => 42;

    public override string Name => "Tsuuiisou";

    public override string Japanese => "字一色";

    public override string English => "All Honors";

    public override int HanOpen { get; set; } = 13;

    public override int HanClosed { get; set; } = 13;

    public override bool IsYakuman => true;
}