using Mahjong.Model.Tiles;

namespace Mahjong.Model.Shantens;

public static class Shanten
{
    public const int AGARI_SHANTEN = -1;

    public static int Calculate(TileList tileList, bool useChiitoitsu = true, bool useKokushi = true)
    {
        if (tileList.Count > 14) throw new ArgumentException($"手牌の数が14個より多いです。tileList:{tileList}", nameof(tileList));
        List<int> shantens = [];
        shantens.Add(CalculateForRegular(tileList));
        if (useChiitoitsu)
        {
            shantens.Add(CalculateForChiitoitsu(tileList));
        }
        if (useKokushi)
        {
            shantens.Add(CalculateForKokushi(tileList));
        }
        return shantens.Min();
    }

    public static int CalculateForRegular(TileList tileList)
    {
        var context = new ShantenContext(tileList);
        context = context.ScanHonor();
        context = context with
        {
            MentsuCount = context.MentsuCount + (14 - context.TileList.Count) / 3,
            FourSuits = [.. Tile.Suits.Where(x => context.TileList.CountOf(x) == 4)]
        };
        return context.ScanSuit();
    }

    public static int CalculateForChiitoitsu(TileList tileList)
    {
        var toitsuCout = tileList.Distinct().Count(x => tileList.CountOf(x) >= 2);
        var typeCount = tileList.Distinct().Count();
        return 6 - toitsuCout + Math.Max(0, 7 - typeCount);
    }

    public static int CalculateForKokushi(TileList tileList)
    {
        var yaochuuToitsu = Tile.All.Count(x => x.IsYaochuu && tileList.CountOf(x) >= 2);
        var yaochuuCount = tileList.Distinct().Count(x => x.IsYaochuu);
        return 13 - yaochuuCount - (yaochuuToitsu != 0 ? 1 : 0);
    }
}
