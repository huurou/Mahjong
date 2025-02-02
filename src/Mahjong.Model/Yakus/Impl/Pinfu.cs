using Mahjong.Model.Fus;
using Mahjong.Model.Fuuro;

namespace Mahjong.Model.Yakus.Impl;

/// <summary>
/// 平和
/// </summary>
public record Pinfu : Yaku
{
    public override string Name => "平和";
    public override int HanOpen => 0;
    public override int HanClosed => 1;
    public override bool IsYakuman => false;

    public static bool Valid(FuList fuList, FuuroList fuuroList)
    {
        return !fuuroList.HasOpen &&
            (fuList.Contains(Fu.Base) && fuList.Count == 1 ||
            fuList.Contains(Fu.Base) && fuList.Contains(Fu.Menzen) && fuList.Count == 2);
    }
}
