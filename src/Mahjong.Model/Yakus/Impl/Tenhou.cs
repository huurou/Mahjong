using Mahjong.Model.Games;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 天和
/// </summary>
public record Tenhou : Yaku
{
    public override string Name => "天和";
    public override int HanOpen => 0;
    public override int HanClosed => 13;
    public override bool IsYakuman => true;
    public static bool Valid(WinSituation situation)
    {
        return situation.Tenhou;
    }
}
