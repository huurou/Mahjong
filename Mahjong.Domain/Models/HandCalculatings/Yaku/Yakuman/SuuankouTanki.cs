namespace Mahjong.Domain.Models.HandCalculatings.Yaku.Yakuman;

internal class SuuankouTanki : YakuBase
{
    public override int YakuId => 48;

    public override int TenhouId => 40;

    public override string Name => "Suu ankou tanki";

    public override string Japanese => "四暗刻単騎待ち";

    public override string English => "Four Concealed Triplets Single Wait";

    public override int HanOpen { get; set; } = 26;

    public override int HanClosed { get; set; } = 26;

    public override bool IsYakuman => true;
}