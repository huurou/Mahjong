using System.Collections;
using System.Text;

namespace Mahjong.Domain.Models.Tiles
{
    /// <summary>
    /// TileKindのリスト
    /// </summary>
    public class TileKindList : ValueObject<TileKindList>, IList<TileKind>
    {
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

        public TileKindList(IEnumerable<TileKind> kinds)
        {
            kinds_ = kinds.ToList();
        }

        public static TileKindList Parse(string man = "", string pin = "", string sou = "", string honor = "", bool hasAkaDora = false)
        {
            return TileList.Parse(man, pin, sou, honor, hasAkaDora).KindList;
        }

        public void Add(TileKind item)
        {
            kinds_.Add(item);
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