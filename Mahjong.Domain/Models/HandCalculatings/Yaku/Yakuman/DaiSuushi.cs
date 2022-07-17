namespace Mahjong.Domain.Models.HandCalculatings.Yaku.Yakuman;

internal class DaiSuushi : YakuBase
{
    public override int YakuId => 46;

    public override int TenhouId => 49;

    public override string Name => "Dai Suushi";

    public override string Japanese => "大四喜";

    public override string English => "Big Four Winds";

    public override int HanOpen { get; set; } = 26;

    public override int HanClosed { get; set; } = 26;

    public override bool IsYakuman => true;
}