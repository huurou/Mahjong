using System.Collections;
using System.Text;
using static Mahjong.Domain.Models.Tiles.TileKind;

namespace Mahjong.Domain.Models.Tiles;

/// <summary>
/// TileKind 0 ~33をインデックスとして, それぞれの牌の個数を値として持つ配列
/// </summary>
internal class TileArray : ValueObject<TileArray>, IEnumerable<int>
{
    private readonly int[] tiles_ = new int[34];

    public int this[TileKind kind] { get => tiles_[(int)kind - 1]; set => tiles_[(int)kind - 1] = value; }

    public int Length => tiles_.Length;

    public TileList ToTileList()
    {
        var list = new TileList();
        for (var i = 0; i < Length; i++)
        {
            for (var j = 0; j < tiles_[i]; j++)
            {
                list.Add(new(i * 4 + j));
            }
        }
        return list;
    }

    public TileKindList ToKindList()
    {
        return ToTileList().ToKindList();
    }

    /// <summary>
    /// 自身及び隣り合った牌が存在しないTileKindのリストを返す
    /// </summary>
    /// <returns>自身及び隣り合った牌が存在しないTileKindのリスト</returns>
    internal TileKindList FindIsolatedKindList()
    {
        var isolated = new TileKindList();
        for (var kind = Man1; kind <= Chun; kind++)
        {
            if (kind.IsHonor() && this[kind] == 0)
            {
                isolated.Add(kind);
                continue;
            }
            if (kind.Simplify() is 1 && this[kind] == 0 && this[kind + 1] == 0 ||
                kind.Simplify() is >= 2 and <= 8 && this[kind - 1] == 0 && this[kind] == 0 && this[kind + 1] == 0 ||
                kind.Simplify() is 9 && this[kind - 1] == 0 && this[kind] == 0)
            {
                isolated.Add(kind);
            }
        }
        return isolated;
    }

    public static TileArray Parse(string man = "", string pin = "", string sou = "", string honor = "", bool hasAkaDora = false)
    {
        return TileList.Parse(man, pin, sou, honor).ToTileArray();
    }

    public TileArray Clone()
    {
        var array = new TileArray();
        for (var i = 0; i < Length; i++)
        {
            array.tiles_[i] = tiles_[i];
        }
        return array;
    }

    public override bool Equals(ValueObject<TileArray>? other)
    {
        return other is TileArray array && this.SequenceEqual(array);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("man:");
        for (var kind = Man1; kind <= Man9; kind++)
        {
            sb.Append(this[kind]);
        }
        sb.Append("pin:");
        for (var kind = Pin1; kind <= Pin9; kind++)
        {
            sb.Append(this[kind]);
        }
        sb.Append("sou:");
        for (var kind = Sou1; kind <= Sou9; kind++)
        {
            sb.Append(this[kind]);
        }
        sb.Append("honor:");
        for (var kind = East; kind <= Chun; kind++)
        {
            sb.Append(this[kind]);
        }
        return sb.ToString();
    }

    public IEnumerator<int> GetEnumerator()
    {
        return ((IEnumerable<int>)tiles_).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override int GetHashCodeCore()
    {
        return new { tiles_ }.GetHashCode();
    }
}