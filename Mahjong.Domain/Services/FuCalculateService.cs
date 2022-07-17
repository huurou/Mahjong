using Mahjong.Domain.Models.HandCalculatings;
using Mahjong.Domain.Models.Melds;
using Mahjong.Domain.Models.Tiles;
using static Mahjong.Domain.Models.HandCalculatings.FuReason;
using static Mahjong.Domain.Models.Melds.MeldType;
using static Mahjong.Domain.Models.Tiles.TileKind;

namespace Mahjong.Domain.Services;

internal static class FuCalculateService
{
    public static FuResult CalcFu(
        IEnumerable<TileKindList> devidedHand,
        TileKind winTile,
        TileKindList winGroup,
        HandConfig config,
        IEnumerable<Meld>? melds = null)
    {
        // 七対子
        if (devidedHand.Count() == 7) return new(new FuDetail(Base, 25));

        melds ??= new List<Meld>();
        var fuReasons = new List<FuReason>();
        var pair = devidedHand.Where(x => x.IsPair).ElementAt(0);
        var chiSets = devidedHand.Where(x => x.IsChi);
        var ponSets = devidedHand.Where(x => x.IsPon);

        var closedChiSets = chiSets.ToList();
        // 純手牌に副露と同じ並びが存在したとき、純手牌側は取り除いてしまわないようRemoveで削除する
        foreach (var meld in melds)
        {
            var kinds = new TileKindList(meld.Kinds.Take(3));
            closedChiSets.Remove(kinds);
        }
        if (closedChiSets.Contains(winGroup))
        {
            var winSimplify = winTile.Simplify();
            // ペンチャン
            if (winGroup.Contains(x => x.IsTerminal()) &&
                (winSimplify == 3 && winGroup.IndexOf(winTile) == 2 || winSimplify == 7 && winGroup.IndexOf(winTile) == 0))
            {
                fuReasons.Add(Penchan);
            }
            // カンチャン
            if (winGroup.IndexOf(winTile) == 1) fuReasons.Add(Kanchan);
        }

        var valuedTiles = new TileKindList(new[]
        {
            config.RoundWind,
            config.PlayerWind,
            Haku,
            Hatsu,
            Chun
        });
        // 役牌雀頭 ダブ東 ダブ南は2*2の4符になる
        for (var i = 0; i < valuedTiles.Count(x => x == pair[0]); i++)
        {
            fuReasons.Add(ValuedPair);
        }

        //シャンポン待ち
        if (winGroup.IsPair) fuReasons.Add(PairWait);

        foreach (var ponSet in ponSets)
        {
            var meldedPon = melds.FirstOrDefault(x => new TileKindList(x.Kinds.Take(3)) == ponSet);
            var isOpen = !config.IsTsumo && ponSet == winGroup ||
                         (meldedPon?.IsOpen ?? false);
            var isKan = meldedPon?.Type is Ankan or Shouminkan;
            var isYaochu = ponSet.Contains(x => x.IsYaochu());
            fuReasons.Add(
                isYaochu
                    ? isKan
                        ? isOpen ? OpenYaochuKan : ClosedYaochuKan
                        : isOpen ? OpenYaochuPon : ClosedYaochuPon
                    : isKan
                        ? isOpen ? OpenKan : ClosedKan
                        : isOpen ? OpenPon : ClosedPon);
        }
        if (config.IsTsumo && (fuReasons.Any() || !config.Rurles.PinfuTsumo))
        {
            fuReasons.Add(Tsumo);
        }
        if (melds.Any(x => x.IsOpen) && !fuReasons.Any() && config.Rurles.OpenPinfu)
        {
            fuReasons.Add(HandWithoutHu);
        }
        if (!melds.Any(x => x.IsOpen) && !config.IsTsumo)
        {
            fuReasons.Add(MenzenRon);
        }
        fuReasons.Add(Base);
        return new(fuReasons.OrderBy(x => x));
    }
}