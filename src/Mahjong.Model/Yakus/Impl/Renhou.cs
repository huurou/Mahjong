using Mahjong.Model.Games;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 人和
/// </summary>
public record Renhou : Yaku
{
    public override string Name => "人和";
    public override int HanOpen => 0;
    public override int HanClosed => 5;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation situation, GameRules rules)
    {
        return situation.Renhou && !rules.RenhouAsYakuman;
    }
}
