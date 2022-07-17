namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal class PlayerWind : YakuBase
{
    public override int YakuId => 20;

    public override int TenhouId => 10;

    public override string Name => "Yakuhai (wind of place)";

    public override string Japanese => "自風";

    public override string English => "Value Tiles (Seat)";

    public override int HanOpen { get; set; } = 1;

    public override int HanClosed { get; set; } = 1;

    public override bool IsYakuman => false;
}