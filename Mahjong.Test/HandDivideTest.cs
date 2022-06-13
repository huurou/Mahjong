using Mahjong.Domain.Models.Melds;
using Mahjong.Domain.Models.Tiles;
using Mahjong.Domain.Services;

namespace Mahjong.Test;

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

        result = HandDivideService.DivideHand(
            TileList.Parse(man: "123", pin: "123", sou: "123", honor: "11222"));
        Single(result);
        Equal(new[]
        {
            TileKindList.Parse(man:"123"),
            TileKindList.Parse(pin:"123"),
            TileKindList.Parse(sou:"123"),
            TileKindList.Parse(honor:"11"),
            TileKindList.Parse(honor:"222"),
        }, result[0]);
    }

    [Fact]
    public void HandWithPairDivideTest()
    {
        var result = HandDivideService.DivideHand(
            TileList.Parse(man: "23444", pin: "344556", sou: "333"));
        Single(result);
        Equal(new[]
        {
            TileKindList.Parse(man:"234"),
            TileKindList.Parse(man:"44"),
            TileKindList.Parse(pin:"345"),
            TileKindList.Parse(pin:"456"),
            TileKindList.Parse(sou:"333"),
        }, result[0]);
    }

    [Fact]
    public void OneSuitHandDivideTest()
    {
        var result = HandDivideService.DivideHand(
            TileList.Parse(man: "11122233388899"));
        Equal(2, result.Count);
        Equal(new[]
        {
            TileKindList.Parse(man:"111"),
            TileKindList.Parse(man:"222"),
            TileKindList.Parse(man:"333"),
            TileKindList.Parse(man:"888"),
            TileKindList.Parse(man:"99"),
        }, result[0]);
        Equal(new[]
        {
            TileKindList.Parse(man:"123"),
            TileKindList.Parse(man:"123"),
            TileKindList.Parse(man:"123"),
            TileKindList.Parse(man:"888"),
            TileKindList.Parse(man:"99"),
        }, result[1]);

        result = HandDivideService.DivideHand(
            TileList.Parse(sou: "111123666789", honor: "11"));
        Single(result);
        Equal(new[]
        {
            TileKindList.Parse(sou:"111"),
            TileKindList.Parse(sou:"123"),
            TileKindList.Parse(sou:"666"),
            TileKindList.Parse(sou:"789"),
            TileKindList.Parse(honor:"11"),
        }, result[0]);
    }

    [Fact]
    public void OneSuitHandWithMeldDivideTest()
    {
        var melds = new[]
        {
            new Meld(MeldType.Chi,TileList.Parse(pin:"234")),
            new Meld(MeldType.Chi,TileList.Parse(pin:"789")),
        };
        var result = HandDivideService.DivideHand(
            TileList.Parse(pin: "234777888999", honor: "22"), melds);
        Single(result);
        Equal(new[]
        {
            TileKindList.Parse(pin:"234"),
            TileKindList.Parse(pin:"789"),
            TileKindList.Parse(pin:"789"),
            TileKindList.Parse(pin:"789"),
            TileKindList.Parse(honor:"22"),
        }, result[0]);
    }

    [Fact]
    public void ChiitoitsuLikeHandDivideTest()
    {
        var result = HandDivideService.DivideHand(
            TileList.Parse(man: "112233", pin: "99", sou: "445566"));
        Equal(2, result.Count);
        Equal(new[]
        {
            TileKindList.Parse(man:"11"),
            TileKindList.Parse(man:"22"),
            TileKindList.Parse(man:"33"),
            TileKindList.Parse(pin:"99"),
            TileKindList.Parse(sou:"44"),
            TileKindList.Parse(sou:"55"),
            TileKindList.Parse(sou:"66"),
        }, result[0]);
        Equal(new[]
        {
            TileKindList.Parse(man:"123"),
            TileKindList.Parse(man:"123"),
            TileKindList.Parse(pin:"99"),
            TileKindList.Parse(sou:"456"),
            TileKindList.Parse(sou:"456"),
        }, result[1]);
    }
}