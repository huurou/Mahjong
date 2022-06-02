using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Mahjong.Domain.Models.Tiles
{
    public class TileCollection : ValueObject<TileCollection>, IList<Tile>
    {
        private readonly List<Tile> tiles_ = new();

        public int Count => tiles_.Count;

        public bool IsReadOnly => false;

        public Tile this[int index] { get => tiles_[index]; set => tiles_[index] = value; }

        public TileCollection(IEnumerable<TileId> tileIds)
            : this(tileIds.Select(x => new Tile(x))) { }

        public TileCollection(IEnumerable<Tile> tiles)
        {
            tiles_ = new(tiles);
        }

        public static TileCollection Parse(string man = "", string pin = "", string sou = "", string honors = "", bool hasAkaDora = false)
        {
            return new(SplitString(man, 0, Tile.FIVE_RED_MAN.Id)
                .Concat(SplitString(pin, 36, Tile.FIVE_RED_PIN.Id))
                .Concat(SplitString(sou, 72, Tile.FIVE_RED_SOU.Id))
                .Concat(SplitString(honors, 108, -1)));

            IEnumerable<TileId> SplitString(string str, TileId offset, int red)
            {
                if (string.IsNullOrWhiteSpace(str)) return new List<TileId>();
                var data = new List<TileId>();
                var temp = new List<TileId>();
                foreach (var s in str)
                {
                    if (s is 'r' or '0' && hasAkaDora)
                    {
                        data.Add(red);
                        temp.Add(red);
                    }
                    else
                    {
                        var id = offset + int.Parse(s.ToString()) * 4;
                        if (id == red && hasAkaDora) id++;
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

        public bool TryFind(TileKind kind, [NotNullWhen(true)] out Tile? tile)
        {
            tile = null;
            if (kind.IsNone()) return false;
            var possibleIds = Enumerable.Range(0, 4).Select(x => new TileId((int)kind * 4 + x));
            foreach (var id in possibleIds)
            {
                if (tiles_.Select(x => x.Id).Contains(id))
                {
                    tile = new(id);
                    return true;
                }
            }
            return false;
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

        public override bool Equals(ValueObject<TileCollection>? other)
        {
            return other is TileCollection tileCollection && tiles_.SequenceEqual(tileCollection.tiles_);
        }

        public override int GetHashCodeCore()
        {
            return new { tiles_ }.GetHashCode();
        }

        public string ToOneLineString(bool printAkaDora = false)
        {
            return string.Join("", tiles_.Select(x => x.ToOneLineString(printAkaDora)));
        }

        public override string ToString()
        {
            return string.Join("", tiles_.Select(x => x.ToString()));
        }
    }
}