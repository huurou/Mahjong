using System.Collections;
using System.Collections.Immutable;

namespace Mahjong.Model.Tiles;

public record TileListList : IEnumerable<TileList>, IEquatable<TileListList>
{
    public int Count => tileLists_.Count;

    public TileList this[Index index] => tileLists_[index];

    private readonly ImmutableList<TileList> tileLists_;

    public TileListList(IEnumerable<TileList> tileLists)
    {
        tileLists_ = [.. tileLists];
    }

    public static TileListList FromOneLine(IEnumerable<string> oneLines)
    {
        return new(oneLines.Select(TileList.FromOneLine));
    }

    public override string ToString()
    {
        return string.Join("", this.Select(x => $"[{x}]"));
    }

    public IEnumerator<TileList> GetEnumerator()
    {
        return tileLists_.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public virtual bool Equals(TileListList? other)
    {
        return other is not null && this.OrderBy(x => x).SequenceEqual(other.OrderBy(x => x));
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        foreach (var tileList in tileLists_)
        {
            hashCode.Add(tileList);
        }
        return hashCode.ToHashCode();
    }
}
