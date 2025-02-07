using Mahjong.Model.Tiles;
using System.Collections;
using System.Collections.Immutable;

namespace Mahjong.Model.Shantens;

public record IsolationSet() : IEnumerable<Tile>
{
    public ImmutableHashSet<Tile> isolationSet_ = [];

    public IsolationSet(ImmutableHashSet<Tile> isolationSet) : this()
    {
        isolationSet_ = isolationSet;
    }

    public int Count => isolationSet_.Count;

    public IsolationSet Add(Tile tile)
    {
        return new(isolationSet_.Add(tile));
    }

    public IEnumerator<Tile> GetEnumerator()
    {
        return isolationSet_.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
