using System.Collections;
using System.Text;
using static Mahjong.Domain.Models.Tiles.TileKind;

namespace Mahjong.Domain.Models.Tiles
{
    /// <summary>
    /// TileKindのリスト
    /// </summary>
    public class TileKindList : ValueObject<TileKindList>, IList<TileKind>, IComparable<TileKindList>
    {
        /// <summary>
        /// 全ての牌種別の牌を1個ずつ含んだリスト
        /// </summary>
        public static TileKindList AllKinds => new(Enumerable.Range((int)Man1, (int)Chun));

        public static TileKindList HonorList => new(AllKinds.Where(x => x.IsHonor()));

        public static TileKindList YaochuList => new(AllKinds.Where(x => x.IsYaochu()));

        private readonly List<TileKind> kinds_ = new();

        public TileKind this[int index] { get => kinds_[index]; set => kinds_[index] = value; }

        public int Count => kinds_.Count;

        public bool IsReadOnly => false;

        public bool IsChi => Count == 3 &&
            kinds_[0] == kinds_[1] - 1 &&
            kinds_[1] == kinds_[2] - 1;

        public bool IsPon => Count == 3 &&
            kinds_[0] == kinds_[1] &&
            kinds_[1] == kinds_[2];

        public bool IsPair => Count == 2 && kinds_[0] == kinds_[1];

        public TileKindList()
        { }

        public TileKindList(IEnumerable<int> kinds)
            : this(kinds.Select(x => (TileKind)x)) { }

        public TileKindList(IEnumerable<TileKind> kinds)
        {
            kinds_ = kinds.ToList();
        }

        public static TileKindList Parse(string man = "", string pin = "", string sou = "", string honor = "", bool hasAkaDora = false)
        {
            return TileList.Parse(man, pin, sou, honor).ToKindList();
        }

        public List<TileKindList> GetPermutations(int count)
        {
            var result = new List<TileKindList>();
            Inner(this, count, new());
            return result;

            void Inner(TileKindList stock, int depth, TileKindList current)
            {
                if (depth == 0)
                {
                    result.Add(current);
                    return;
                }
                for (var i = 0; i < stock.Count; i++)
                {
                    var stockCopy = stock.Clone();
                    var currentCopy = new TileKindList(current) { stockCopy[i] };
                    stockCopy.RemoveAt(i);
                    Inner(stockCopy, depth - 1, currentCopy);
                }
            }
        }

        public static TileKindList Repeat(TileKind kind, int count)
        {
            return new(Enumerable.Repeat(kind, count));
        }

        public TileKindList Clone()
        {
            return new(kinds_);
        }

        public int CompareTo(TileKindList? other)
        {
            if (other is null) return 1;
            var min = Math.Min(Count, other.Count);
            for (var i = 0; i < min; i++)
            {
                if (this[i].CompareTo(other[i]) > 0) return 1;
                if (this[i].CompareTo(other[i]) < 0) return -1;
            }
            return Count.CompareTo(other.Count);
        }

        public void Add(TileKind item)
        {
            kinds_.Add(item);
        }

        public void AddRange(IEnumerable<TileKind> collection)
        {
            kinds_.AddRange(collection);
        }

        public void Clear()
        {
            kinds_.Clear();
        }

        public bool Contains(TileKind item)
        {
            return kinds_.Contains(item);
        }

        public void CopyTo(TileKind[] array, int arrayIndex)
        {
            kinds_.CopyTo(array, arrayIndex);
        }

        public int IndexOf(TileKind item)
        {
            return kinds_.IndexOf(item);
        }

        public void Insert(int index, TileKind item)
        {
            kinds_.Insert(index, item);
        }

        public bool Remove(TileKind item)
        {
            return kinds_.Remove(item);
        }

        public void RemoveAt(int index)
        {
            kinds_.RemoveAt(index);
        }

        public void Foreach(Action<TileKind> action)
        {
            kinds_.ForEach(action);
        }

        public IEnumerator<TileKind> GetEnumerator()
        {
            return kinds_.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public string ToString(bool printAkaDora)
        {
            var sb = new StringBuilder();
            sb.AppendJoin("", kinds_.Select(x => ToString(printAkaDora)));
            return sb.ToString();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendJoin("", kinds_.Select(x => x.ToString(false)));
            return sb.ToString();
        }

        public override bool Equals(ValueObject<TileKindList>? other)
        {
            return other is TileKindList kinds && this.SequenceEqual(kinds);
        }

        public override int GetHashCodeCore()
        {
            return new { kinds_ }.GetHashCode();
        }
    }
}