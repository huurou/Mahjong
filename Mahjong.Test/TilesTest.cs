using Mahjong.Domain.Models.Tiles;

namespace Mahjong.Test
{
    public class TilesTest
    {
        [Fact]
        public void ParseTest()
        {
            Equal(new TileList(new[] { 0, 32, 36, 68, 72, 104, 108, 112, 116, 120, 124, 128, 132 }),
                TileList.Parse(man: "19", pin: "19", sou: "19", honor: "1234567"));

            Equal(new TileList(new[] { 0, 32, 36, 68, 72, 104, 108, 112, 116, 120, 124, 128, 132 }),
                TileList.Parse(str: "19m19p19s1234567z"));

            Equal(TileList.Parse(man: "789", pin: "456", sou: "555", honor: "11222"),
                TileList.Parse(str: "789m456p555s11222z"));
        }
    }
}