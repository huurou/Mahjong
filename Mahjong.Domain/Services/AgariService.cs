using Mahjong.Domain.Models.Tiles;
using static Mahjong.Domain.Models.Tiles.TileKind;

namespace Mahjong.Domain.Services
{
    public class AgariService
    {
        /// <summary>
        /// あがり形かどうか判定する
        /// </summary>
        /// <param name="hand">手牌</param>
        /// <param name="openSets">副露</param>
        /// <returns>あがり形かどうか</returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool IsAgari(TileList hand, IEnumerable<TileList>? openSets = null)
        {
            if (hand.Count is not (13 or 14)) throw new ArgumentException("手牌の数が13or14個でないです。", nameof(hand));
            var array = hand.TileArray;
            if (openSets is not null && openSets.Any())
            {
                var isolated = hand.FindIsolatedKindList();
                if (isolated.Any())
                {
                    foreach (var meld in openSets)
                    {
                        if (meld.Count is not (3 or 4)) throw new ArgumentException("openSetsに3or4個でない組が含まれています。", nameof(openSets));
                        array[meld[0].Kind]--;
                        array[meld[1].Kind]--;
                        array[meld[2].Kind]--;
                        if (meld.Count == 4) array[meld[3].Kind]--; // 槓
                        array[isolated[^1]] = 3;
                        isolated.RemoveAt(isolated.Count - 1);
                    }
                }
            }

            // 各字牌の個数
            var honor = TileKindList.AllKinds.Where(x => x.IsHonor()).Select(x => array[x]);
            // 各么九牌の個数
            var yaochu = TileKindList.AllKinds.Where(x => x.IsYaochu()).Select(x => array[x]);

            // 国士無双判定
            // 么九牌のうち1種類だけ2個の牌があり、それ以外の12種類は1個
            if (yaochu.Count(x => x == 2) == 1 &&
                yaochu.Count(x => x == 1) == 12) return true;

            // 国士無双でないなら字牌が1個だけ存在することはない
            if (honor.Any(x => x == 1)) return false;

            // 七対子判定
            // 1,3,4個の牌は存在せず、2個の牌が7種類存在する
            if (!array.Any(x => x is 1 or 3 or 4) &&
                array.Count(x => x == 2) == 7) return true;

            // 1,4,7  2,5,8  3,6,9 それぞれの個数を集めたもの
            var man147 = array[Man1] + array[Man4] + array[Man7];
            var man258 = array[Man2] + array[Man5] + array[Man8];
            var man369 = array[Man3] + array[Man6] + array[Man9];
            var pin147 = array[Pin1] + array[Pin4] + array[Pin7];
            var pin258 = array[Pin2] + array[Pin5] + array[Pin8];
            var pin369 = array[Pin3] + array[Pin6] + array[Pin9];
            var sou147 = array[Sou1] + array[Sou4] + array[Sou7];
            var sou258 = array[Sou2] + array[Sou5] + array[Sou8];
            var sou369 = array[Sou3] + array[Sou6] + array[Sou9];
            // 対子があれば2 面子のみなら0
            var man = (man147 + man258 + man369) % 3;
            var sou = (sou147 + sou258 + sou369) % 3;
            var pin = (pin147 + pin258 + pin369) % 3;
            if (man == 1 || sou == 1 || pin == 1) return false;
            // 雀頭は1つだけ
            if (new[] { man, sou, pin }.Concat(honor)
                .Count(x => x == 2) != 1) return false;

            // 0なら3,6,9のいずれかが雀頭 or 雀頭なし
            // 1なら2,5,8のいずれかが雀頭
            // 2なら1,4,7のいずれかが雀頭
            var manHead = (man147 + man258 * 2) % 3;
            var pinHead = (pin147 + pin258 * 2) % 3;
            var souHead = (sou147 + sou258 * 2) % 3;
            // 各スートをbits変換する
            var manBits = ToBits(Man1);
            var souBits = ToBits(Sou1);
            var pinBits = ToBits(Pin1);

            return man == 2
                ? (pin | pinHead | sou | souHead) == 0 &&
                  IsMentsu(pinBits) &&
                  IsMentsu(souBits) &&
                  IsHeadMentsu(manHead, manBits)
                : pin == 2
                ? (sou | souHead | man | manHead) == 0 &&
                  IsMentsu(souBits) &&
                  IsMentsu(manBits) &&
                  IsHeadMentsu(pinHead, pinBits)
                : sou == 2
                ? (man | manHead | pin | pinHead) == 0 &&
                  IsMentsu(manBits) &&
                  IsMentsu(pinBits) &&
                  IsHeadMentsu(souHead, souBits)
                : honor.Any(x => x == 2) &&
                  (man | manHead | pin | pinHead | sou | souHead) == 0 &&
                  IsMentsu(manBits) &&
                  IsMentsu(pinBits) &&
                  IsMentsu(souBits);

            // arrayの各intをbitsにしたものが右から3桁ずつ並ぶ
            // [0,1,2,3,4]=>0b100_011_010_001_000
            int ToBits(TileKind offset)
            {
                var bits = 0;
                for (var i = 0; i < 9; i++)
                {
                    bits |= array[offset + i] << i * 3;
                }
                return bits;
            }

            // すべて面子で構成されているかどうか
            bool IsMentsu(int bits)
            {
                // arrayの左端の個数
                var c = bits & 7;
                var p0 = 0;
                var p1 = 0;
                // 1か4個のとき次とその次の1個と順子を構成するはず
                if (c is 1 or 4)
                {
                    p0 = p1 = 1;
                }
                // 2個のとき次とその次の2個と順子を構成するはず
                else if (c == 2)
                {
                    p0 = p1 = 2;
                }
                bits >>= 3;
                // 想定される個数分削除する
                c = (bits & 7) - p0;
                // 想定された個数を満たしていない
                if (c < 0) return false;

                for (var x = 0; x < 6; x++)
                {
                    (p0, p1) = (p1, 0);
                    if (c is 1 or 4)
                    {
                        p0++;
                        p1++;
                    }
                    else if (c == 2)
                    {
                        p0 += 2;
                        p1 += 2;
                    }
                    bits >>= 3;
                    c = (bits & 7) - p0;
                    if (c < 0) return false;
                }
                bits >>= 3;
                c = (bits & 7) - p1;
                // なにも残らないか刻子の3個残るはず
                return c is 0 or 3;
            }

            // 雀頭1個とそれ以外面子で構成されているかどうか
            bool IsHeadMentsu(int head, int bits)
            {
                // 3,6,9のいずれかが雀頭
                if (head == 0)
                {
                    if ((bits & (7 << 6)) >= (2 << 6) && IsMentsu(bits - (2 << 6))) return true;
                    if ((bits & (7 << 15)) >= (2 << 15) && IsMentsu(bits - (2 << 15))) return true;
                    if ((bits & (7 << 24)) >= (2 << 24) && IsMentsu(bits - (2 << 24))) return true;
                }
                // 2,5,8のいずれかが雀頭
                else if (head == 1)
                {
                    if ((bits & (7 << 3)) >= (2 << 3) && IsMentsu(bits - (2 << 3))) return true;
                    if ((bits & (7 << 12)) >= (2 << 12) && IsMentsu(bits - (2 << 12))) return true;
                    if ((bits & (7 << 21)) >= (2 << 21) && IsMentsu(bits - (2 << 21))) return true;
                }
                // 1,4,7のいずれかが雀頭
                else if (head == 2)
                {
                    if ((bits & (7 << 0)) >= (2 << 0) && IsMentsu(bits - (2 << 0))) return true;
                    if ((bits & (7 << 9)) >= (2 << 9) && IsMentsu(bits - (2 << 9))) return true;
                    if ((bits & (7 << 18)) >= (2 << 18) && IsMentsu(bits - (2 << 18))) return true;
                }
                return false;
            }
        }
    }
}