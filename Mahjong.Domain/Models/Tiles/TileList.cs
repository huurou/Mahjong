using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Mahjong.Domain.Models.Tiles;

/// <summary>
/// Tileのリスト
/// </summary>
public class TileList : ValueObject<TileList>, IList<Tile>
{
    private readonly List<Tile> tiles_ = new();

    public int Count => tiles_.Count;

    public bool IsReadOnly => false;

    public Tile this[int index] { get => tiles_[index]; set => tiles_[index] = value; }

    public TileList()
    {
    }

    public TileList(IEnumerable<int> tileIds)
        : this(tileIds.Select(x => new Tile(x))) { }

    public TileList(IEnumerable<TileId> tileIds)
        : this(tileIds.Select(x => new Tile(x))) { }

    public TileList(IEnumerable<Tile> tiles)
    {
        tiles_ = new(tiles);
    }

    public TileArray ToTileArray()
    {
        var array = new TileArray();
        foreach (var tile in tiles_)
        {
            array[tile.Kind]++;
        }
        return array;
    }

    public TileKindList ToKindList()
    {
        return new(tiles_.Select(x => x.Kind));
    }

    public bool TryFind(TileKind kind, [NotNullWhen(true)] out Tile? tile)
    {
        tile = null;
        if (kind.IsNone()) return false;
        var possibleIds = Enumerable.Range(0, 4).Select(x => new TileId((int)kind * 4 + x));
        foreach (var id in possibleIds)
        {
            if ((tile = tiles_.FirstOrDefault(x => x.Id == id)) is null) continue;
            return true;
        }
        return false;
    }

    public static TileList Parse(string str)
    {
        var manSb = new StringBuilder();
        var pinSb = new StringBuilder();
        var souSb = new StringBuilder();
        var honorSb = new StringBuilder();

        var splitStart = 0;
        for (var i = 0; i < str.Length; i++)
        {
            switch (str[i])
            {
                case 'm':
                    for (var j = splitStart; j < i; j++)
                    {
                        manSb.Append(str[j]);
                    }
                    break;

                case 'p':
                    for (var j = splitStart; j < i; j++)
                    {
                        pinSb.Append(str[j]);
                    }
                    break;

                case 's':
                    for (var j = splitStart; j < i; j++)
                    {
                        souSb.Append(str[j]);
                    }
                    break;

                case 'z':
                    for (var j = splitStart; j < i; j++)
                    {
                        honorSb.Append(str[j]);
                    }
                    break;

                default: continue;
            }
            splitStart = i + 1;
        }
        return Parse(manSb.ToString(), pinSb.ToString(), souSb.ToString(), honorSb.ToString());
    }

    public static TileList Parse(string man = "", string pin = "", string sou = "", string honor = "")
    {
        return new(SplitString(man, 0, Tile.FIVE_RED_MAN.Id.Value)
            .Concat(SplitString(pin, 36, Tile.FIVE_RED_PIN.Id.Value))
            .Concat(SplitString(sou, 72, Tile.FIVE_RED_SOU.Id.Value))
            .Concat(SplitString(honor, 108, -1)));

        IEnumerable<int> SplitString(string str, int offset, int red)
        {
            if (string.IsNullOrWhiteSpace(str)) return new List<int>();
            var data = new List<int>();
            var temp = new List<int>();
            foreach (var c in str)
            {
                if (c is 'r' or '0')
                {
                    data.Add(red);
                    temp.Add(red);
                }
                else
                {
                    if (!int.TryParse(c.ToString(), out var i)) throw new ApplicationException($"数字とr以外の文字が含まれています。str:{str}");
                    var id = (i - 1) * 4 + offset;
                    if (data.Contains(id))
                    {
                        data.Add(id + temp.Count(x => x == id));
                        temp.Add(id);
                    }
                    else
                    {
                        data.Add(id);
                        temp.Add(id);
                    }
                }
            }
            return data;
        }
    }

    /// <summary>
    /// 自身及び隣り合った牌が存在しないTileKindのリストを返す
    /// </summary>
    /// <returns>自身及び隣り合った牌が存在しないTileKindのリスト</returns>
    public TileKindList FindIsolatedKindList()
    {
        return ToTileArray().FindIsolatedKindList();
    }

    public string ToString(bool printAkaDora)
    {
        return string.Join("", tiles_.Select(x => x.ToString(printAkaDora)));
    }

    public override string ToString()
    {
        return string.Join("", tiles_.Select(x => x.ToString()));
    }

    public string ToOneLineString(bool printAkaDora = false)
    {
        var tiles = this.OrderBy(x => x.Id.Value);

        var man = tiles.Where(x => x.Kind.IsMan());
        var pin = tiles.Where(x => x.Kind.IsPin());
        var sou = tiles.Where(x => x.Kind.IsSou());
        var honor = tiles.Where(x => x.Kind.IsHonor());

        var manStr = Words(man, Tile.FIVE_RED_MAN.Id.Value, "m");
        var pinStr = Words(pin, Tile.FIVE_RED_PIN.Id.Value, "p");
        var souStr = Words(sou, Tile.FIVE_RED_SOU.Id.Value, "s");
        var honorStr = Words(honor, -1, "z");

        return manStr + pinStr + souStr + honorStr;

        string Words(IEnumerable<Tile> tiles, int red, string suffix) => tiles.Any()
                ? $"{string.Join("", tiles.Select(x => x.Id.Value == red && printAkaDora ? 0 : x.Kind.Simplify()))}{suffix}"
                : "";
    }

    public void Add(Tile item)
    {
        tiles_.Add(item);
    }

    public void Clear()
    {
        tiles_.Clear();
    }

    public bool Contains(Tile item)
    {
        return tiles_.Contains(item);
    }

    public void CopyTo(Tile[] array, int arrayIndex)
    {
        tiles_.CopyTo(array, arrayIndex);
    }

    public bool Remove(Tile item)
    {
        return tiles_.Remove(item);
    }

    public int IndexOf(Tile item)
    {
        return tiles_.IndexOf(item);
    }

    public void Insert(int index, Tile item)
    {
        tiles_.Insert(index, item);
    }

    public void RemoveAt(int index)
    {
        tiles_.RemoveAt(index);
    }

    public IEnumerator<Tile> GetEnumerator()
    {
        return tiles_.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override bool Equals(ValueObject<TileList>? other)
    {
        return other is TileList list && tiles_.SequenceEqual(list.tiles_);
    }

    public override int GetHashCodeCore()
    {
        return new { tiles_ }.GetHashCode();
    }
}