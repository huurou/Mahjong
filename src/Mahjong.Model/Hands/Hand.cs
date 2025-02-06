using Mahjong.Model.Fuuro;
using Mahjong.Model.Tiles;

namespace Mahjong.Model.Hands;

/// <summary>
/// 晒していない手牌
/// </summary>
public record Hand : TileListList
{
    public Hand(IEnumerable<TileList> tileLists) : base(tileLists)
    {
    }

    public TileListList ConcatFuuro(FuuroList fuuroList)
    {
        return new([.. this, .. fuuroList.Select(x => x.TileList)]);
    }
}
