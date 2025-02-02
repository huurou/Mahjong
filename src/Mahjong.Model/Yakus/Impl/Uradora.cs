namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 裏ドラ
/// </summary>
public record Uradora : Yaku
{
    public override string Name => "裏ドラ";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;
}
