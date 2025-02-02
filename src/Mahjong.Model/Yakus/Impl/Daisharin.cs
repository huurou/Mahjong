using Mahjong.Model.Games;
using Mahjong.Model.Hands;
using Mahjong.Model.Tiles;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 大車輪
/// </summary>
public record Daisharin : Yaku
{
    public override string Name => "大車輪";
    public override int HanOpen => 0;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;
    public static bool Valid(Hand hand, GameRules rules)
    {
        return rules.Daisharin && new TileListList(hand) == TileListList.FromOneLine(["22p", "33p", "44p", "55p", "66p", "77p", "88p"]);
    }
}
