using Mahjong.Model.Shantens;
using Mahjong.Model.Tiles;

namespace Mahjong.Test;

public class ShantenTest()
{
    [Fact]
    public void 通常の形のシャンテン()
    {
        var hand = new TileList(man: "567", pin: "11", sou: "111234567");
        var expected = Shanten.AGARI_SHANTEN;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(man: "567", pin: "11", sou: "111345677");
        expected = 0;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(man: "567", pin: "15", sou: "111345677");
        expected = 1;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(man: "1578", pin: "15", sou: "11134567");
        expected = 2;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(man: "1358", pin: "1358", sou: "113456");
        expected = 3;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(man: "1358", pin: "13588", sou: "1589", honor: "1");
        expected = 4;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(man: "1358", pin: "13588", sou: "159", honor: "12");
        expected = 5;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(man: "1358", pin: "258", sou: "1589", honor: "123");
        expected = 6;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(sou: "11123456788999");
        expected = Shanten.AGARI_SHANTEN;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(sou: "11122245679999");
        expected = 0;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(man: "8", pin: "1367", sou: "4566677", honor: "12");
        expected = 2;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(man: "3678", pin: "3356", sou: "15", honor: "2567");
        expected = 4;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(man: "359", pin: "17", sou: "159", honor: "123567");
        expected = 7;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(man: "1111222235555", honor: "1");
        expected = 0;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(man: "1358", pin: "13588", sou: "589", honor: "11");
        expected = 3;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(man: "1358", pin: "13588", sou: "59", honor: "111");
        expected = 3;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(man: "1358", pin: "1388", sou: "59", honor: "1111");
        expected = 3;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(pin: "11", sou: "345677788899");
        expected = Shanten.AGARI_SHANTEN;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));
    }

    [Fact]
    public void 通常の形のシャンテン手牌13枚()
    {
        var hand = new TileList(man: "567", pin: "1", sou: "111345677");
        var expected = 1;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(man: "567", sou: "111345677");
        expected = 1;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(man: "56", sou: "111345677");
        expected = 0;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));
    }

    [Fact]
    public void 七対子のシャンテン()
    {
        var hand = new TileList(man: "77", pin: "114477", sou: "114477");
        var expected = Shanten.AGARI_SHANTEN;
        Assert.Equal(expected, Shanten.CalculateForChiitoitsu(hand));

        hand = new TileList(man: "76", pin: "114477", sou: "114477");
        expected = 0;
        Assert.Equal(expected, Shanten.CalculateForChiitoitsu(hand));

        hand = new TileList(man: "76", pin: "114479", sou: "114477");
        expected = 1;
        Assert.Equal(expected, Shanten.CalculateForChiitoitsu(hand));

        hand = new TileList(man: "76", pin: "14479", sou: "114477", honor: "1");
        expected = 2;
        Assert.Equal(expected, Shanten.CalculateForChiitoitsu(hand));

        hand = new TileList(man: "76", pin: "13479", sou: "114477", honor: "1");
        expected = 3;
        Assert.Equal(expected, Shanten.CalculateForChiitoitsu(hand));

        hand = new TileList(man: "76", pin: "13479", sou: "114467", honor: "1");
        expected = 4;
        Assert.Equal(expected, Shanten.CalculateForChiitoitsu(hand));

        hand = new TileList(man: "76", pin: "13479", sou: "113467", honor: "1");
        expected = 5;
        Assert.Equal(expected, Shanten.CalculateForChiitoitsu(hand));

        hand = new TileList(man: "76", pin: "13479", sou: "123467", honor: "1");
        expected = 6;
        Assert.Equal(expected, Shanten.CalculateForChiitoitsu(hand));
    }

    [Fact]
    public void 国士無双のシャンテン()
    {
        var hand = new TileList(man: "19", pin: "19", sou: "19", honor: "12345677");
        var expected = Shanten.AGARI_SHANTEN;
        Assert.Equal(expected, Shanten.CalculateForKokushi(hand));

        hand = new TileList(man: "19", pin: "19", sou: "129", honor: "1234567");
        expected = 0;
        Assert.Equal(expected, Shanten.CalculateForKokushi(hand));

        hand = new TileList(man: "19", pin: "129", sou: "129", honor: "123456");
        expected = 1;
        Assert.Equal(expected, Shanten.CalculateForKokushi(hand));

        hand = new TileList(man: "129", pin: "129", sou: "129", honor: "12345");
        expected = 2;
        Assert.Equal(expected, Shanten.CalculateForKokushi(hand));

        hand = new TileList(man: "129", pin: "129", sou: "1239", honor: "2345");
        expected = 3;
        Assert.Equal(expected, Shanten.CalculateForKokushi(hand));

        hand = new TileList(man: "129", pin: "1239", sou: "1239", honor: "345");
        expected = 4;
        Assert.Equal(expected, Shanten.CalculateForKokushi(hand));

        hand = new TileList(man: "1239", pin: "1239", sou: "1239", honor: "45");
        expected = 5;
        Assert.Equal(expected, Shanten.CalculateForKokushi(hand));

        hand = new TileList(man: "1239", pin: "1239", sou: "12349", honor: "5");
        expected = 6;
        Assert.Equal(expected, Shanten.CalculateForKokushi(hand));

        hand = new TileList(man: "1239", pin: "12349", sou: "12349");
        expected = 7;
        Assert.Equal(expected, Shanten.CalculateForKokushi(hand));
    }

    [Fact]
    public void 四枚持ちのシャンテン()
    {
        var hand = new TileList(man: "123456789", honor: "1111");
        var expected = 1;
        Assert.Equal(expected, Shanten.Calculate(hand));

        hand = new TileList(man: "123456789", pin: "1111");
        expected = 1;
        Assert.Equal(expected, Shanten.Calculate(hand));
    }

    [Fact]
    public void 鳴いている手牌のシャンテン()
    {
        var hand = new TileList(pin: "222567", sou: "44467778");
        var expected = Shanten.AGARI_SHANTEN;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(pin: "222567", sou: "44468");
        expected = 0;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(pin: "222567", sou: "68");
        expected = 0;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(pin: "222567", sou: "68");
        expected = 0;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(sou: "68");
        expected = 0;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));

        hand = new TileList(sou: "88");
        expected = Shanten.AGARI_SHANTEN;
        Assert.Equal(expected, Shanten.CalculateForRegular(hand));
    }

    [Fact]
    public void 手牌が14枚より多い_失敗()
    {
        var hand = new TileList(man: "567", pin: "11", sou: "1112345678");
        var ex = Record.Exception(() => _ = Shanten.Calculate(hand));
        Assert.IsType<ArgumentException>(ex);
    }
}

// Arrange

// Action

// Assert
