using Mahjong.Domain.Models.Tiles;
using static Mahjong.Domain.Services.ShantenService;

namespace Mahjong.Test
{
    public class ShantenTest
    {
        [Fact]
        public void CalcShantenTest()
        {
            Equal(-1, CalcShanten(TileList.Parse(man: "567", pin: "11", sou: "111234567")));
            Equal(0, CalcShanten(TileList.Parse(man: "567", pin: "11", sou: "111345677")));
            Equal(1, CalcShanten(TileList.Parse(man: "567", pin: "15", sou: "111345677")));
            Equal(2, CalcShanten(TileList.Parse(man: "1578", pin: "15", sou: "11134567")));
            Equal(3, CalcShanten(TileList.Parse(man: "1358", pin: "1358", sou: "113456")));
            Equal(4, CalcShanten(TileList.Parse(man: "1358", pin: "13588", sou: "1589", honor: "1")));
            Equal(5, CalcShanten(TileList.Parse(man: "1358", pin: "13588", sou: "159", honor: "12")));
            Equal(6, CalcShanten(TileList.Parse(man: "1358", pin: "258", sou: "1589", honor: "123")));
            Equal(-1, CalcShanten(TileList.Parse(sou: "11123456788999")));
            Equal(0, CalcShanten(TileList.Parse(sou: "1112345678999")));
            Equal(0, CalcShanten(TileList.Parse(sou: "11122245679999")));
        }

        [Fact]
        public void CalcChitoitsuShanteTest()
        {
            Equal(-1, CalcShanten(TileList.Parse(man: "77", pin: "114477", sou: "114477")));
            Equal(0, CalcShanten(TileList.Parse(man: "76", pin: "114477", sou: "114477")));
            Equal(1, CalcShanten(TileList.Parse(man: "76", pin: "114479", sou: "114477")));
            Equal(2, CalcShanten(TileList.Parse(man: "76", pin: "14479", sou: "114477", honor: "1")));
        }

        [Fact]
        public void CalcKokushimusouShantenTest()
        {
            Equal(-1, CalcShanten(TileList.Parse(man: "19", pin: "19", sou: "19", honor: "12345677")));
            Equal(0, CalcShanten(TileList.Parse(man: "19", pin: "19", sou: "129", honor: "1234567")));
            Equal(0, CalcShanten(TileList.Parse(man: "19", pin: "19", sou: "19", honor: "1234567")));
            Equal(1, CalcShanten(TileList.Parse(man: "19", pin: "19", sou: "129", honor: "123456")));
            Equal(2, CalcShanten(TileList.Parse(man: "129", pin: "129", sou: "129", honor: "12345")));
        }

        [Fact]
        public void CalcOpenShantenTest()
        {
            Equal(-1, CalcShanten(TileList.Parse(pin: "222567", sou: "44467778")));
            Equal(0, CalcShanten(TileList.Parse(pin: "222567", sou: "44467778"),
                new[] { TileList.Parse(sou: "777") }));
            Equal(0, CalcShanten(TileList.Parse(man: "345", pin: "222", sou: "23455567"),
                new[] { TileList.Parse(man: "345"), TileList.Parse(sou: "555") }));
        }
    }
}