namespace Mahjong.Domain.Models.HandCalculatings.Yaku;

internal abstract class YakuBase
{
    public abstract int YakuId { get; }
    public abstract int TenhouId { get; }
    public abstract string Name { get; }
    public abstract string Japanese { get; }
    public abstract string English { get; }
    public abstract int HanOpen { get; set; }
    public abstract int HanClosed { get; set; }
    public abstract bool IsYakuman { get; }
}