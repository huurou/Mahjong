using System.Collections;
using System.Collections.Immutable;

namespace Mahjong.Model.Fus;

public record FuList : IEnumerable<Fu>
{
    public int Count => fus_.Count;
    public int Total =>
        Count == 0 ? 0
        : this.Contains(Fu.Chiitoitsu) ? 25
        : (this.Sum(x => x.Value) + 9) / 10 * 10;

    private readonly ImmutableList<Fu> fus_;

    public FuList(ImmutableList<Fu> fus)
    {
        fus_ = fus;
    }

    public override string ToString()
    {
        return $"{Total}符 {string.Join(',', this)}";
    }

    public IEnumerator<Fu> GetEnumerator()
    {
        return fus_.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}