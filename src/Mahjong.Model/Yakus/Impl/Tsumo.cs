﻿using Mahjong.Model.Fuuro;
using Mahjong.Model.Games;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// ツモ
/// </summary>
public record Tsumo : Yaku
{
    public override string Name => "門前清自摸和";
    public override int HanOpen => 0;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(WinSituation situation, FuuroList fuuroList)
    {
        return situation.Tsumo && !fuuroList.HasOpen;
    }
}
