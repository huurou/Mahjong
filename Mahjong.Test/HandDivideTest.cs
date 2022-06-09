using Mahjong.Domain.Models.Tiles;
using Mahjong.Domain.Services;

namespace Mahjong.Test
{
    public class HandDivideTest
    {
        [Fact]
        public void SimpleHandDivideTest()
        {
            var result = HandDivideService.DivideHand(
                TileList.Parse(man: "234567", sou: "23455", honor: "777"));
            Single(result);
            Equal(new[]
            {
                TileKindList.Parse(man:"234"),
                TileKindList.Parse(man:"567"),
                TileKindList.Parse(sou:"234"),
                TileKindList.Parse(sou:"55"),
                TileKindList.Parse(honor:"777"),
            }, result[0]);
        }
    }
}