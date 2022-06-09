using static Mahjong.Domain.Models.Tiles.TileKind;

namespace Mahjong.Domain.Models.Tiles
{
    public static class TileKindExtension
    {
        public static bool IsNone(this TileKind kind)
        {
            return kind == None;
        }

        public static bool IsMan(this TileKind kind)
        {
            return kind is >= Man1 and <= Man9;
        }

        public static bool IsPin(this TileKind kind)
        {
            return kind is >= Pin1 and <= Pin9;
        }

        public static bool IsSou(this TileKind kind)
        {
            return kind is >= Sou1 and <= Sou9;
        }

        public static bool IsHonor(this TileKind kind)
        {
            return kind is >= East and <= Chun;
        }

        public static bool IsTerminal(this TileKind kind)
        {
            return kind is Man1 or Man9 or Pin1 or Pin9 or Sou1 or Sou9;
        }

        public static bool IsYaochu(this TileKind kind)
        {
            return kind.IsHonor() || kind.IsTerminal();
        }

        public static bool IsChuchan(this TileKind kind)
        {
            return !kind.IsYaochu() && !kind.IsNone();
        }

        /// <summary>
        /// 牌種別をスートを除いた数字で表したもの
        /// 一萬 → 1 九萬 → 9
        /// 東 → 1 中 → 7
        /// </summary>
        /// <param name="kind"></param>
        /// <returns></returns>
        public static int Simplify(this TileKind kind)
        {
            return kind == None
                ? 0
                : ((int)kind - 1) % 9 + 1;
        }

        public static string ToString(this TileKind kind, bool printAkaDora)
        {
            return printAkaDora
                ? kind switch
                {
                    Man5 => "[五]",
                    Pin5 => "[⑤]",
                    Sou5 => "[５]",
                    _ => ToString()
                }
                : ToString();

            string ToString() => kind switch
            {
                Man1 => "一",
                Man2 => "二",
                Man3 => "三",
                Man4 => "四",
                Man5 => "五",
                Man6 => "六",
                Man7 => "七",
                Man8 => "八",
                Man9 => "九",
                Pin1 => "(1)",
                Pin2 => "(2)",
                Pin3 => "(3)",
                Pin4 => "(4)",
                Pin5 => "(5)",
                Pin6 => "(6)",
                Pin7 => "(7)",
                Pin8 => "(8)",
                Pin9 => "(9)",
                Sou1 => "1",
                Sou2 => "2",
                Sou3 => "3",
                Sou4 => "4",
                Sou5 => "5",
                Sou6 => "6",
                Sou7 => "7",
                Sou8 => "8",
                Sou9 => "9",
                East => "東",
                South => "南",
                West => "西",
                North => "北",
                Haku => "白",
                Hatsu => "發",
                Chun => "中",
                None or _ => "-",
            };
        }
    }
}