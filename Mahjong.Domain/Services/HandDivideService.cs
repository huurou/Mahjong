using Mahjong.Domain.Models.Melds;
using Mahjong.Domain.Models.Tiles;
using static Mahjong.Domain.Models.Tiles.TileKind;

namespace Mahjong.Domain.Services;

internal static class HandDivideService
{
    public static List<List<TileKindList>> DivideHand(TileList hand, IEnumerable<Meld>? melds = null)
    {
        if (melds is null) melds = new List<Meld>();
        var closedArray = hand.ToTileArray();
        var openKindList = new TileKindList(melds.SelectMany(x => x.Tiles.ToKindList()));
        openKindList.Foreach(x => closedArray[x]--);
        // 対子を探す 字牌の刻子は無視する(途中で分断して対子にはできない)
        var pairs = new TileKindList(TileKindList.AllKinds.Where(x => x.IsHonor() && closedArray[x] == 2 || !x.IsHonor() && closedArray[x] >= 2));

        var hands = new List<List<TileKindList>>();
        foreach (var pair in pairs)
        {
            var localArray = hand.ToTileArray();
            // 既に鳴いている牌は形が決まっているので外す
            openKindList.Foreach(x => localArray[x]--);
            // 雀頭候補を外す
            localArray[pair] -= 2;

            var man = FindValidCombinations(localArray, Man1, Man9);
            var pin = FindValidCombinations(localArray, Pin1, Pin9);
            var sou = FindValidCombinations(localArray, Sou1, Sou9);
            var honor = TileKindList.HonorList.Where(x => localArray[x] == 3).Select(x => TileKindList.Repeat(x, 3));
            var honors = new List<IEnumerable<TileKindList>>();
            if (honor.Any()) honors.Add(honor);
            var suits = new List<IEnumerable<IEnumerable<TileKindList>>> { new[] { new[] { TileKindList.Repeat(pair, 2) } } };
            if (man.Any()) suits.Add(man);
            if (pin.Any()) suits.Add(pin);
            if (sou.Any()) suits.Add(sou);
            if (honors.Any()) suits.Add(honors);
            suits.AddRange(melds.Select(x => new[] { new[] { x.Tiles.ToKindList() } }));

            foreach (var p in Product(suits))
            {
                var h = p.SelectMany(x => x.Select(y => y));
                if (h.Count() == 5)
                {
                    hands.Add(h.OrderBy(x => x[0]).ToList());
                }
            }
        }
        var unique_hands = new List<List<TileKindList>>();
        foreach (var h in hands)
        {
            h.Sort();
            if (unique_hands.All(x =>
            {
                for (var i = 0; i < x.Count; i++)
                {
                    if (x[i] != h[i]) return true;
                }
                return false;
            }))
            {
                unique_hands.Add(h);
            }
        }
        hands = unique_hands;
        // 七対子判定
        if (pairs.Count == 7) hands.Add(pairs.Select(x => TileKindList.Repeat(x, 2)).ToList());

        hands.Sort((x, y) =>
        {
            for (var i = 0; i < Math.Min(x.Count, y.Count); i++)
            {
                if (x[i].CompareTo(y[i]) > 0) return 1;
                if (x[i].CompareTo(y[i]) < 0) return -1;
            }
            return x.Count.CompareTo(y.Count);
        });
        return hands;

        List<IEnumerable<TileKindList>> FindValidCombinations(TileArray array, TileKind first, TileKind second, bool completed = true)
        {
            var kindList = new TileKindList();
            for (var kind = first; kind <= second; kind++)
            {
                if (array[kind] != 0) kindList.AddRange(Enumerable.Repeat(kind, array[kind]));
            }
            if (!kindList.Any()) return new();

            // kindListのnP3全順列を列挙
            // [1,2,3,4,4]=>[[1,2,3],[1,2,4],[1,3,2],[1,3,4],[1,4,2],[1,4,3],[1,4,4],...]
            var allPerms = kindList.GetPermutations(3);
            //刻子、順子の形をしている順列を抜きだす
            var validPerms = allPerms.Where(x => x.IsChi || x.IsPon).ToList();
            if (!validPerms.Any()) return new();

            var neededPermsCount = kindList.Count / 3;
            // 有り得る順列のセットが一通りしかないときそれで確定する
            if (neededPermsCount == validPerms.Count && kindList == new TileKindList(validPerms.SelectMany(x => x))) return new() { validPerms };

            foreach (var perm in validPerms.ToList())
            {
                if (!perm.IsPon) continue;
                var setCount = 1;
                var tilesCount = 0;
                while (setCount > tilesCount)
                {
                    tilesCount = kindList.Count(x => perm[0] == x) / 3;
                    setCount = validPerms.Count(x => (perm[0], perm[1], perm[2]) == (x[0], x[1], x[2]));
                    if (setCount > tilesCount) validPerms.Remove(perm);
                }
            }
            foreach (var perm in validPerms.ToList())
            {
                if (!perm.IsChi) continue;
                var setCount = 5;
                var possibleSetCount = 4;
                while (setCount > possibleSetCount)
                {
                    setCount = validPerms.Count(x => (perm[0], perm[1], perm[2]) == (x[0], x[1], x[2]));
                    if (setCount > possibleSetCount) validPerms.Remove(perm);
                }
            }
            if (!completed) return new() { validPerms };

            var possiblePerms = new TileKindList(Enumerable.Range((int)Man1, validPerms.Count)).GetPermutations(neededPermsCount);
            var result = new List<IEnumerable<TileKindList>>();
            foreach (var perm in possiblePerms)
            {
                if (kindList != new TileKindList(perm.SelectMany(x => validPerms[(int)x - 1]).OrderBy(x => x))) continue;
                var res = perm.Select(x => validPerms[(int)x - 1]).OrderBy(x => x[0]);
                if (result.FirstOrDefault(x => x.SequenceEqual(res)) == default) result.Add(res);
            }
            return result;
        }

        List<IEnumerable<IEnumerable<TileKindList>>> Product(List<IEnumerable<IEnumerable<TileKindList>>> suits)
        {
            var result = new List<IEnumerable<IEnumerable<TileKindList>>>();
            return suits.Count switch
            {
                1 => suits,
                2 => suits[0].SelectMany(i => suits[1].Select(j => new[] { i, j }.AsEnumerable())).ToList(),
                3 => suits[0].SelectMany(i => suits[1].SelectMany(j => suits[2].Select(k => new[] { i, j, k }.AsEnumerable()))).ToList(),
                4 => suits[0].SelectMany(i => suits[1].SelectMany(j => suits[2].SelectMany(k => suits[3].Select(l => new[] { i, j, k, l }.AsEnumerable())))).ToList(),
                5 => suits[0].SelectMany(i => suits[1].SelectMany(j => suits[2].SelectMany(k => suits[3].SelectMany(l => suits[4].Select(m => new[] { i, j, k, l, m }.AsEnumerable()))))).ToList(),
                _ => result,
            };
        }
    }
}