namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// ドラ
/// </summary>
public record Dora : Yaku
{
    public override string Name => "ドラ";
    public override int HanOpen => 1;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;
}
