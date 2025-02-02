using Mahjong.Model.Fuuro;
using Mahjong.Model.Tiles;
using System.Collections;
using System.Collections.Immutable;

namespace Mahjong.Model.Hands;

/// <summary>
/// 晒していない手牌
/// </summary>
public record Hand : IEnumerable<TileList>
{
    private readonly ImmutableList<TileList> hand_;

    public Hand(IEnumerable<TileList> hand)
    {
        hand_ = [.. hand];
    }

    public TileListList ConcatFuuro(FuuroList fuuroList)
    {
        return new([.. hand_, .. fuuroList.Select(x => x.TileList)]);
    }

    public IEnumerator<TileList> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
