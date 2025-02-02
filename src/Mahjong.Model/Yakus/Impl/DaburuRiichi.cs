using Mahjong.Model.Fuuro;
using Mahjong.Model.Games;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// ダブル立直
/// </summary>
public record DaburuRiichi : Yaku
{
    public override string Name => "ダブル立直";
    public override int HanOpen => 0;
    public override int HanClosed => 2;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation situation, FuuroList fuuroList)
    {
        return situation.DaburuRiichi && !fuuroList.HasOpen;
    }
}
