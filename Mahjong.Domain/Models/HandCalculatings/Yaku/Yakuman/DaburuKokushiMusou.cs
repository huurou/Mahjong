namespace Mahjong.Domain.Models.HandCalculatings.Yaku.Yakuman;

internal class DaburuKokushiMusou : YakuBase
{
    public override int YakuId => 47;

    public override int TenhouId => 48;

    public override string Name => "Kokushi Musou Juusanmen Machi";

    public override string Japanese => "国士無双十三面待ち";

    public override string English => "Thirteen Orphans 13-way wait";

    public override int HanOpen { get; set; } = 26;

    public override int HanClosed { get; set; } = 26;

    public override bool IsYakuman => true;
}