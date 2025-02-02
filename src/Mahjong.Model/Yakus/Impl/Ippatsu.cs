using Mahjong.Model.Fuuro;
using Mahjong.Model.Games;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 一発
/// </summary>
public record Ippatsu : Yaku
{
    public override string Name => "一発";
    public override int HanOpen => 0;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation situation, FuuroList fuuroList)
    {
        return situation.Ippatsu && !fuuroList.HasOpen;
    }
}
