using System.Collections;
using static Mahjong.Domain.Models.Tiles.TileKind;

namespace Mahjong.Domain.Models.Tiles
{
    /// <summary>
    /// TileKind 0 ~33をインデックスとして, それぞれの牌の個数を値として持つ配列
    /// </summary>
    public class TileArray : ValueObject<TileArray>, IEnumerable<int>
    {
        private readonly int[] tiles_ = new int[34];

        public int this[TileKind kind] { get => tiles_[(int)kind - 1]; set => tiles_[(int)kind - 1] = value; }

        public int Length => tiles_.Length;

        public override bool Equals(ValueObject<TileArray>? other)
        {
            return other is TileArray array && this.SequenceEqual(array);
        }

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

        public TileKindList ToTileKindList()
        {
            return ToTileList().ToKindList();
        }

        /// <summary>
        /// 自身及び隣り合った牌が存在しないTileKindのリストを返す
        /// </summary>
        /// <returns>自身及び隣り合った牌が存在しないTileKindのリスト</returns>
        internal List<TileKind> FindIsolatedKinds()
        {
            var isolated = new List<TileKind>();
            for (var kind = None; kind <= Chun; kind++)
            {
                if (kind.IsHonor() && this[kind] == 0)
                {
                    isolated.Add(kind);
                    continue;
                }
                if (kind.Simplify() == 1 && this[kind] == 0 && this[kind + 1] == 0 ||
                    kind.Simplify() == 9 && this[kind - 1] == 0 && this[kind] == 0
                    || this[kind - 1] == 0 && this[kind] == 0 && this[kind + 1] == 0)
                {
                    isolated.Add(kind);
                }
            }
            return isolated;
        }

        internal bool IsStrictlyIsolated(TileKind kind)
        {
            var hand = Clone();
            if (hand[kind] > 0) hand[kind]--;
            return kind.IsHonor()
                ? hand[kind] == 0
                : (kind.Simplify() switch
                {
                    1 => new List<TileKind> { kind, kind + 1, kind + 2 },
                    2 => new List<TileKind> { kind - 1, kind, kind + 1, kind + 2 },
                    8 => new List<TileKind> { kind - 2, kind - 1, kind, kind + 1 },
                    9 => new List<TileKind> { kind - 2, kind - 1, kind },
                    _ => new List<TileKind> { kind - 2, kind - 1, kind, kind + 1, kind + 2 },
                }).All(x => hand[x] == 0);
        }

        public static TileArray Parse(string man = "", string pin = "", string sou = "", string honor = "", bool hasAkaDora = false)
        {
            return TileList.Parse(man, pin, sou, honor, hasAkaDora).ToTileArray();
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

        public string ToOneLineString(bool printAkaDora = false)
        {
            return ToTileList().ToOneLineString(printAkaDora);
        }

        public override string ToString()
        {
            return ToTileList().ToString();
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
}