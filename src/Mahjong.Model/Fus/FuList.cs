using System.Collections;
using System.Collections.Immutable;

namespace Mahjong.Model.Fus;

public record FuList : IEnumerable<Fu>
{
    private readonly ImmutableList<Fu> fus_;

    public FuList(ImmutableList<Fu> fus)
    {
        fus_ = fus;
    }

    public int Total =>
        !this.Any() ? 0
        : this.Contains(Fu.Chiitoitsu) ? 25
        : (this.Sum(x => x.Value) + 9) / 10 * 10;

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