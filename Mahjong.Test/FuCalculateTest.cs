using Mahjong.Domain.Models.HandCalculatings;
using Mahjong.Domain.Models.Melds;
using Mahjong.Domain.Models.Tiles;
using static Mahjong.Domain.Models.HandCalculatings.FuReason;
using static Mahjong.Domain.Models.Melds.MeldType;
using static Mahjong.Domain.Models.Tiles.TileKind;
using static Mahjong.Domain.Services.FuCalculateService;
using static Mahjong.Domain.Services.HandDivideService;

namespace Mahjong.Test;

public class FuCalculateTest
{
    private readonly OptionalRules rules_ = new();

    [Fact]
    public void ChitoitsuFuTest()
    {
        var config = new HandConfig(rules_, East, East, false);
        var hand = TileList.Parse(man: "115599", pin: "66", sou: "112244");
        var winTile = Tile.Parse(pin: "6");
        var dividedHand = DivideHand(hand)[0];
        var winGroup = GetWinGroup(dividedHand, winTile);
        var result = CalcFu(dividedHand, winTile.Kind, winGroup, config);

        Single(result.Details);
        Contains(new(Base, 25), result.Details);
        Equal(25, result.Total);
    }

    [Fact]
    public void OpenHandBaseTest()
    {
        var config = new HandConfig(rules_, East, East, false);
        var hand = TileList.Parse(man: "123456", pin: "11", sou: "222678");
        var winTile = Tile.Parse(sou: "6");
        var melds = new[] { MakeMeld(Pon, sou: "222") };
        var dividedHand = DivideHand(hand, melds)[0];
        var winGroup = GetWinGroup(dividedHand, winTile);
        var result = CalcFu(dividedHand, winTile.Kind, winGroup, config, melds: melds);

        Equal(2, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(OpenPon), result.Details);
        Equal(30, result.Total);
    }

    [Fact]
    public void FuBasedOnWinGroupTest()
    {
        var config = new HandConfig(rules_, East, East, false);
        var hand = TileList.Parse(man: "234789", pin: "12345666");
        var winTile = Tile.Parse(pin: "6");
        var dividedHand = DivideHand(hand)[0];
        var winGroups = GetWinGroups(dividedHand, winTile);
        var result = CalcFu(dividedHand, winTile.Kind, winGroups.ElementAt(0), config);

        Equal(2, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(MenzenRon), result.Details);
        Equal(30, result.Total);

        result = CalcFu(dividedHand, winTile.Kind, winGroups.ElementAt(1), config);

        Equal(3, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(MenzenRon), result.Details);
        Contains(new(PairWait), result.Details);
        Equal(40, result.Total);
    }

    [Fact]
    public void OpenHandAdditionalFuTest()
    {
        // 喰い平和加符あり
        var rules = new OptionalRules(openPinfu: true);
        var config = new HandConfig(rules, East, East, false);
        var hand = TileList.Parse(man: "234567", pin: "22", sou: "234678");
        var winTile = Tile.Parse(sou: "6");
        var dividedHand = DivideHand(hand)[0];
        var winGroup = GetWinGroup(dividedHand, winTile);
        var melds = new[] { MakeMeld(Chi, sou: "234") };
        var result = CalcFu(dividedHand, winTile.Kind, winGroup, config, melds: melds);

        Equal(2, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(HandWithoutHu), result.Details);
        Equal(30, result.Total);

        // 喰い平和加符なし
        rules = new OptionalRules(openPinfu: false);
        config = new HandConfig(rules, East, East, false);
        result = CalcFu(dividedHand, winTile.Kind, winGroup, config, melds: melds);

        Single(result.Details);
        Contains(new(Base), result.Details);
        Equal(20, result.Total);
    }

    [Fact]
    public void PinfuTest()
    {
        // ピンヅモあり
        var rules = new OptionalRules(pinfuTsumo: true);
        var config = new HandConfig(rules, East, East, true);
        var hand = TileList.Parse(man: "123456", pin: "123", sou: "22678");
        var winTile = Tile.Parse(sou: "6");
        var dividedHand = DivideHand(hand)[0];
        var winGroup = GetWinGroup(dividedHand, winTile);
        var result = CalcFu(dividedHand, winTile.Kind, winGroup, config);

        Single(result.Details);
        Contains(new(Base), result.Details);
        Equal(20, result.Total);

        // ピンヅモなし
        rules = new OptionalRules(pinfuTsumo: false);
        config = new HandConfig(rules, East, East, true);
        result = CalcFu(dividedHand, winTile.Kind, winGroup, config);

        Equal(2, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(Tsumo), result.Details);
        Equal(30, result.Total);
    }

    [Fact]
    public void NotPinfuTest()
    {
        var config = new HandConfig(rules_, East, East, true);
        var hand = TileList.Parse(man: "123456", pin: "111", sou: "22678");
        var winTile = Tile.Parse(sou: "6");
        var dividedHand = DivideHand(hand)[0];
        var winGroup = GetWinGroup(dividedHand, winTile);
        var result = CalcFu(dividedHand, winTile.Kind, winGroup, config);

        Equal(3, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(Tsumo), result.Details);
        Contains(new(ClosedYaochuPon), result.Details);
        Equal(30, result.Total);

        config = new HandConfig(rules_, East, East, false);
        result = CalcFu(dividedHand, winTile.Kind, winGroup, config);

        Equal(3, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(MenzenRon), result.Details);
        Contains(new(ClosedYaochuPon), result.Details);
        Equal(40, result.Total);
    }

    [Fact]
    public void PenchanFuTest()
    {
        var config = new HandConfig(rules_, East, East, false);
        var hand = TileList.Parse(man: "123456", pin: "55", sou: "123456");
        var winTile = Tile.Parse(sou: "3");
        var dividedHand = DivideHand(hand)[0];
        var winGroup = GetWinGroup(dividedHand, winTile);
        var result = CalcFu(dividedHand, winTile.Kind, winGroup, config);

        Equal(3, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(MenzenRon), result.Details);
        Contains(new(Penchan), result.Details);
        Equal(40, result.Total);

        hand = TileList.Parse(man: "123456", pin: "55", sou: "345789");
        winTile = Tile.Parse(sou: "7");
        dividedHand = DivideHand(hand)[0];
        winGroup = GetWinGroup(dividedHand, winTile);
        result = CalcFu(dividedHand, winTile.Kind, winGroup, config);

        Equal(3, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(MenzenRon), result.Details);
        Contains(new(Penchan), result.Details);
        Equal(40, result.Total);
    }

    [Fact]
    public void KanchanFuTest()
    {
        var config = new HandConfig(rules_, East, East, false);
        var hand = TileList.Parse(man: "123456", pin: "55", sou: "123456");
        var winTile = Tile.Parse(sou: "2");
        var dividedHand = DivideHand(hand)[0];
        var winGroup = GetWinGroup(dividedHand, winTile);
        var result = CalcFu(dividedHand, winTile.Kind, winGroup, config);

        Equal(3, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(MenzenRon), result.Details);
        Contains(new(Kanchan), result.Details);
        Equal(40, result.Total);

        hand = TileList.Parse(man: "123456", pin: "55", sou: "234567");
        winTile = Tile.Parse(sou: "3");
        dividedHand = DivideHand(hand)[0];
        winGroup = GetWinGroup(dividedHand, winTile);
        result = CalcFu(dividedHand, winTile.Kind, winGroup, config);

        Equal(3, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(MenzenRon), result.Details);
        Contains(new(Kanchan), result.Details);
        Equal(40, result.Total);

        hand = TileList.Parse(man: "123456", pin: "55", sou: "345678");
        winTile = Tile.Parse(sou: "4");
        dividedHand = DivideHand(hand)[0];
        winGroup = GetWinGroup(dividedHand, winTile);
        result = CalcFu(dividedHand, winTile.Kind, winGroup, config);

        Equal(3, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(MenzenRon), result.Details);
        Contains(new(Kanchan), result.Details);
        Equal(40, result.Total);

        hand = TileList.Parse(man: "123456", pin: "55", sou: "456789");
        winTile = Tile.Parse(sou: "5");
        dividedHand = DivideHand(hand)[0];
        winGroup = GetWinGroup(dividedHand, winTile);
        result = CalcFu(dividedHand, winTile.Kind, winGroup, config);

        Equal(3, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(MenzenRon), result.Details);
        Contains(new(Kanchan), result.Details);
        Equal(40, result.Total);

        hand = TileList.Parse(man: "123456", pin: "55", sou: "234567");
        winTile = Tile.Parse(sou: "6");
        dividedHand = DivideHand(hand)[0];
        winGroup = GetWinGroup(dividedHand, winTile);
        result = CalcFu(dividedHand, winTile.Kind, winGroup, config);

        Equal(3, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(MenzenRon), result.Details);
        Contains(new(Kanchan), result.Details);
        Equal(40, result.Total);

        hand = TileList.Parse(man: "123456", pin: "55", sou: "345678");
        winTile = Tile.Parse(sou: "7");
        dividedHand = DivideHand(hand)[0];
        winGroup = GetWinGroup(dividedHand, winTile);
        result = CalcFu(dividedHand, winTile.Kind, winGroup, config);

        Equal(3, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(MenzenRon), result.Details);
        Contains(new(Kanchan), result.Details);
        Equal(40, result.Total);

        hand = TileList.Parse(man: "123456", pin: "55", sou: "456789");
        winTile = Tile.Parse(sou: "8");
        dividedHand = DivideHand(hand)[0];
        winGroup = GetWinGroup(dividedHand, winTile);
        result = CalcFu(dividedHand, winTile.Kind, winGroup, config);

        Equal(3, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(MenzenRon), result.Details);
        Contains(new(Kanchan), result.Details);
        Equal(40, result.Total);
    }

    [Fact]
    public void ValuedPairFuTest()
    {
        var config = new HandConfig(rules_, East, South, false);
        var hand = TileList.Parse(man: "123456", sou: "123678", honor: "11");
        var winTile = Tile.Parse(sou: "6");
        var dividedHand = DivideHand(hand)[0];
        var winGroup = GetWinGroup(dividedHand, winTile);
        var result = CalcFu(dividedHand, winTile.Kind, winGroup, config);

        Equal(3, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(MenzenRon), result.Details);
        Contains(new(ValuedPair), result.Details);
        Equal(40, result.Total);

        // ダブ東
        config = new HandConfig(rules_, East, East, false);
        result = CalcFu(dividedHand, winTile.Kind, winGroup, config);

        Equal(4, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(MenzenRon), result.Details);
        Contains(new(ValuedPair), result.Details);
        Contains(new(ValuedPair), result.Details);
        Equal(40, result.Total);
    }

    [Fact]
    public void PairWaitFuTest()
    {
        var config = new HandConfig(rules_, East, East, false);
        var hand = TileList.Parse(man: "123456", pin: "11", sou: "123678");
        var winTile = Tile.Parse(pin: "1");
        var dividedHand = DivideHand(hand)[0];
        var winGroup = GetWinGroup(dividedHand, winTile);
        var result = CalcFu(dividedHand, winTile.Kind, winGroup, config);

        Equal(3, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(MenzenRon), result.Details);
        Contains(new(PairWait), result.Details);
        Equal(40, result.Total);
    }

    [Fact]
    public void OpenPonFuTest()
    {
        var config = new HandConfig(rules_, East, East, false);
        var hand = TileList.Parse(man: "123456", pin: "11", sou: "222678");
        var winTile = Tile.Parse(sou: "6");
        var dividedHand = DivideHand(hand)[0];
        var winGroup = GetWinGroup(dividedHand, winTile);
        var melds = new[] { MakeMeld(Pon, sou: "222") };
        var result = CalcFu(dividedHand, winTile.Kind, winGroup, config, melds);

        Equal(2, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(OpenPon), result.Details);
        Equal(30, result.Total);
    }

    [Fact]
    public void ClosedPonFuTest()
    {
        var config = new HandConfig(rules_, East, East, false);
        var hand = TileList.Parse(man: "123456", pin: "11", sou: "222678");
        var winTile = Tile.Parse(sou: "6");
        var dividedHand = DivideHand(hand)[0];
        var winGroup = GetWinGroup(dividedHand, winTile);
        var result = CalcFu(dividedHand, winTile.Kind, winGroup, config);

        Equal(3, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(MenzenRon), result.Details);
        Contains(new(ClosedPon), result.Details);
        Equal(40, result.Total);
    }

    [Fact]
    public void OpenYaochuPonFuTest()
    {
        var config = new HandConfig(rules_, East, East, false);
        var hand = TileList.Parse(man: "123456", pin: "11", sou: "111678");
        var winTile = Tile.Parse(sou: "6");
        var dividedHand = DivideHand(hand)[0];
        var winGroup = GetWinGroup(dividedHand, winTile);
        var melds = new[] { MakeMeld(Pon, sou: "111") };
        var result = CalcFu(dividedHand, winTile.Kind, winGroup, config, melds);

        Equal(2, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(OpenYaochuPon), result.Details);
        Equal(30, result.Total);
    }

    [Fact]
    public void ClosedYaochuPonFuTest()
    {
        var config = new HandConfig(rules_, East, East, false);
        var hand = TileList.Parse(man: "123456", pin: "11", sou: "111678");
        var winTile = Tile.Parse(sou: "6");
        var dividedHand = DivideHand(hand)[0];
        var winGroup = GetWinGroup(dividedHand, winTile);
        var result = CalcFu(dividedHand, winTile.Kind, winGroup, config);

        Equal(3, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(MenzenRon), result.Details);
        Contains(new(ClosedYaochuPon), result.Details);
        Equal(40, result.Total);

        hand = TileList.Parse(man: "123456", pin: "11", sou: "678", honor: "111");
        winTile = Tile.Parse(sou: "6");
        dividedHand = DivideHand(hand)[0];
        winGroup = GetWinGroup(dividedHand, winTile);
        result = CalcFu(dividedHand, winTile.Kind, winGroup, config);

        Equal(3, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(MenzenRon), result.Details);
        Contains(new(ClosedYaochuPon), result.Details);
        Equal(40, result.Total);
    }

    [Fact]
    public void OpenKanFuTest()
    {
        var config = new HandConfig(rules_, East, East, false);
        var hand = TileList.Parse(man: "123456", pin: "11", sou: "222678");
        var winTile = Tile.Parse(sou: "6");
        var dividedHand = DivideHand(hand)[0];
        var winGroup = GetWinGroup(dividedHand, winTile);
        var melds = new[] { MakeMeld(Shouminkan, sou: "2222") };
        var result = CalcFu(dividedHand, winTile.Kind, winGroup, config, melds);

        Equal(2, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(OpenKan), result.Details);
        Equal(30, result.Total);
    }

    [Fact]
    public void ClosedKanFuTest()
    {
        var config = new HandConfig(rules_, East, East, false);
        var hand = TileList.Parse(man: "123456", pin: "11", sou: "222678");
        var winTile = Tile.Parse(sou: "6");
        var dividedHand = DivideHand(hand)[0];
        var winGroup = GetWinGroup(dividedHand, winTile);
        var melds = new[] { MakeMeld(Ankan, sou: "2222") };
        var result = CalcFu(dividedHand, winTile.Kind, winGroup, config, melds);

        Equal(3, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(MenzenRon), result.Details);
        Contains(new(ClosedKan), result.Details);
        Equal(50, result.Total);
    }

    [Fact]
    public void OpenYaochuKanFuTest()
    {
        var config = new HandConfig(rules_, East, East, false);
        var hand = TileList.Parse(man: "123456", pin: "11", sou: "111678");
        var winTile = Tile.Parse(sou: "6");
        var dividedHand = DivideHand(hand)[0];
        var winGroup = GetWinGroup(dividedHand, winTile);
        var melds = new[] { MakeMeld(Shouminkan, sou: "1111") };
        var result = CalcFu(dividedHand, winTile.Kind, winGroup, config, melds);

        Equal(2, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(OpenYaochuKan), result.Details);
        Equal(40, result.Total);
    }

    [Fact]
    public void ClosedYaochuKanFuTest()
    {
        var config = new HandConfig(rules_, East, East, false);
        var hand = TileList.Parse(man: "123456", pin: "11", sou: "678", honor: "111");
        var winTile = Tile.Parse(sou: "6");
        var dividedHand = DivideHand(hand)[0];
        var winGroup = GetWinGroup(dividedHand, winTile);
        var melds = new[] { MakeMeld(Ankan, honor: "1111") };
        var result = CalcFu(dividedHand, winTile.Kind, winGroup, config, melds);

        Equal(3, result.Details.Count());
        Contains(new(Base), result.Details);
        Contains(new(MenzenRon), result.Details);
        Contains(new(ClosedYaochuKan), result.Details);
        Equal(70, result.Total);
    }

    private static TileKindList GetWinGroup(IEnumerable<TileKindList> devidedHand, Tile winTile)
    {
        return devidedHand.Where(x => x.Contains(winTile.Kind)).First();
    }

    private static IEnumerable<TileKindList> GetWinGroups(IEnumerable<TileKindList> devidedHand, Tile winTile)
    {
        return devidedHand.Where(x => x.Contains(winTile.Kind));
    }

    private static Meld MakeMeld(MeldType meldType, string man = "", string pin = "", string sou = "", string honor = "")
    {
        return new(meldType, TileList.Parse(man, pin, sou, honor));
    }
}