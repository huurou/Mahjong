using Mahjong.Domain.Models.Tiles;

namespace Mahjong.Domain.Models.Melds
{
    public class Meld
    {
        /// <summary>
        /// 鳴きの種類
        /// </summary>
        public MeldType Type { get; }
        /// <summary>
        /// 副露牌
        /// </summary>
        public TileList Tiles { get; }
        /// <summary>
        /// 明槓か暗槓か区別する
        /// </summary>
        public bool Opened { get; }
        /// <summary>
        /// 鳴かれた牌
        /// </summary>
        public TileId? CalledTile { get; }
        /// <summary>
        /// 誰から鳴いたか
        /// </summary>
        public Who From { get; }

        public Meld(MeldType type, TileList tiles,
            bool opened = true, TileId? calledTile = null, Who from = Who.None)
        {
            Type = type;
            Tiles = tiles;
            Opened = opened;
            CalledTile = calledTile;
            From = from;
        }

        public override string ToString()
        {
            return $"{Type} {Tiles}";
        }
    }
}