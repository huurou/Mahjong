using Mahjong.Domain.Models.Tiles;
using static Mahjong.Domain.Models.Tiles.TileKind;

namespace Mahjong.Domain.Models.HandCalculatings.Yakus
{
    public class YakuhaiWest : YakuBase
    {
        public override int YakuId => 18;

        public override int TenhouId => 10;

        public override string Name => "Yakuhai (west)";

        public override string Japanese => "役牌(西)";

        public override string English => "West Round/Seat";

        public override int HanOpen { get; set; } = 1;

        public override int HanClosed { get; set; } = 1;

        public override bool IsYakuman => false;

        public override bool IsConditionMet(IEnumerable<TileKindList>? devidedHand, params object[] args)
        {
            if (devidedHand is null || !args.Any()) return false;
            var roundWind = (TileKind)args[0];
            var playerWind = (TileKind)args[1];

            return devidedHand.Any(x => x == TileKindList.Repeat(West, 3)) &&
                (roundWind == West || playerWind == West);
        }
    }

    public abstract class YakuBase
    {
        public abstract int YakuId { get; }
        public abstract int TenhouId { get; }
        public abstract string Name { get; }
        public abstract string Japanese { get; }
        public abstract string English { get; }
        public abstract int HanOpen { get; set; }
        public abstract int HanClosed { get; set; }
        public abstract bool IsYakuman { get; }

        public abstract bool IsConditionMet(IEnumerable<TileKindList>? hand, params object[] args);
    }
}