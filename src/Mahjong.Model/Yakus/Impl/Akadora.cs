namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 赤ドラ
/// </summary>
public record Akadora : Yaku
{
    public override string Name => "赤ドラ";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;
}