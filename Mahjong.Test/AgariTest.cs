using Mahjong.Domain.Models.Tiles;
using static Mahjong.Domain.Services.AgariService;

namespace Mahjong.Test
{
    public class AgariTest
    {
        [Fact]
        public void IsAgariTest()
        {
            True(IsAgari(TileList.Parse(man: "33", pin: "123", sou: "123456789")));
            True(IsAgari(TileList.Parse(pin: "11123", sou: "123456789")));
            True(IsAgari(TileList.Parse(sou: "123456789", honor: "11777")));
            True(IsAgari(TileList.Parse(sou: "12345556778899")));
            True(IsAgari(TileList.Parse(sou: "11112345678999")));
            True(IsAgari(TileList.Parse(man: "345", pin: "789", sou: "233334", honor: "55")));

            False(IsAgari(TileList.Parse(pin: "12345", sou: "123456789")));
            False(IsAgari(TileList.Parse(pin: "11145", sou: "111222444")));
            False(IsAgari(TileList.Parse(sou: "11122233356888")));
        }

        [Fact]
        public void IsChitoitsuAgariTest()
        {
            True(IsAgari(TileList.Parse(pin: "1199", sou: "1133557799")));
            True(IsAgari(TileList.Parse(man: "11", pin: "1199", sou: "2244", honor: "2277")));
            True(IsAgari(TileList.Parse(man: "11223344556677")));
        }

        [Fact]
        public void IsKokushimusouAgariTest()
        {
            True(IsAgari(TileList.Parse(man: "199", pin: "19", sou: "19", honor: "1234567")));
            True(IsAgari(TileList.Parse(man: "19", pin: "19", sou: "19", honor: "11234567")));
            True(IsAgari(TileList.Parse(man: "19", pin: "19", sou: "19", honor: "12345677")));
            False(IsAgari(TileList.Parse(man: "19", pin: "19", sou: "129", honor: "1234567")));
            False(IsAgari(TileList.Parse(man: "19", pin: "19", sou: "19", honor: "11134567")));
        }

        [Fact]
        public void IsOpenAgariTest()
        {
            True(IsAgari(TileList.Parse(man: "345", pin: "22", sou: "234555567"),
                new[] { TileList.Parse(man: "345"), TileList.Parse(sou: "555") }));
            False(IsAgari(TileList.Parse(man: "345", pin: "222", sou: "23455567"),
                new[] { TileList.Parse(man: "345"), TileList.Parse(sou: "555") }));
        }
    }
}