using Mahjong.Model.Tiles;
using System.Collections;
using System.Collections.Immutable;

namespace Mahjong.Model.Fuuro;

public record FuuroList : IEnumerable<Fuuro>
{
    public bool HasOpen => this.Any(x => x.IsOpen);
    public int Count => fuuros_.Count;

    private readonly ImmutableList<Fuuro> fuuros_;

    public FuuroList(IEnumerable<Fuuro> fuuros)
    {
        fuuros_ = [.. fuuros];
    }

    public IEnumerator<Fuuro> GetEnumerator()
    {
        return fuuros_.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override string ToString()
    {
        return string.Join(" ", this);
    }
}
