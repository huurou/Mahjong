using Mahjong.Model.Fuuro;
using Mahjong.Model.Games;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 立直
/// </summary>
public record Riichi : Yaku
{
    public override string Name => "立直";
    public override int HanOpen => 0;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation situation, FuuroList fuuroList)
    {
        return situation.Riichi && !situation.DaburuRiichi && !fuuroList.HasOpen;
    }
}
