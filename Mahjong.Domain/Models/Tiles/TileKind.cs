using static Mahjong.Domain.Models.Tiles.TileKind;

namespace Mahjong.Domain.Models.Tiles
{
    /// <summary>
    /// 牌種別
    /// </summary>
    public enum TileKind
    {
        None,

        /// <summary>
        /// 一萬
        /// </summary>
        Man1,
        /// <summary>
        /// 二萬
        /// </summary>
        Man2,
        /// <summary>
        /// 三萬
        /// </summary>
        Man3,
        /// <summary>
        /// 四萬
        /// </summary>
        Man4,
        /// <summary>
        /// 五萬
        /// </summary>
        Man5,
        /// <summary>
        /// 六萬
        /// </summary>
        Man6,
        /// <summary>
        /// 七萬
        /// </summary>
        Man7,
        /// <summary>
        /// 八萬
        /// </summary>
        Man8,
        /// <summary>
        /// 九萬
        /// </summary>
        Man9,

        /// <summary>
        /// 一筒
        /// </summary>
        Pin1,
        /// <summary>
        /// 二筒
        /// </summary>
        Pin2,
        /// <summary>
        /// 三筒
        /// </summary>
        Pin3,
        /// <summary>
        /// 四筒
        /// </summary>
        Pin4,
        /// <summary>
        /// 五筒
        /// </summary>
        Pin5,
        /// <summary>
        /// 六筒
        /// </summary>
        Pin6,
        /// <summary>
        /// 七筒
        /// </summary>
        Pin7,
        /// <summary>
        /// 八筒
        /// </summary>
        Pin8,
        /// <summary>
        /// 九筒
        /// </summary>
        Pin9,

        /// <summary>
        /// 一索
        /// </summary>
        Sou1,
        /// <summary>
        /// 二索
        /// </summary>
        Sou2,
        /// <summary>
        /// 三索
        /// </summary>
        Sou3,
        /// <summary>
        /// 四索
        /// </summary>
        Sou4,
        /// <summary>
        /// 五索
        /// </summary>
        Sou5,
        /// <summary>
        /// 六索
        /// </summary>
        Sou6,
        /// <summary>
        /// 七索
        /// </summary>
        Sou7,
        /// <summary>
        /// 八索
        /// </summary>
        Sou8,
        /// <summary>
        /// 九索
        /// </summary>
        Sou9,

        /// <summary>
        /// 東
        /// </summary>
        East,
        /// <summary>
        /// 南
        /// </summary>
        South,
        /// <summary>
        /// 西
        /// </summary>
        West,
        /// <summary>
        /// 北
        /// </summary>
        North,
        /// <summary>
        /// 白
        /// </summary>
        Haku,
        /// <summary>
        /// 發
        /// </summary>
        Hatsu,
        /// <summary>
        /// 中
        /// </summary>
        Chun,
    }

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
    }
}