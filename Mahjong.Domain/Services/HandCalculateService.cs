using Mahjong.Domain.Models.HandCalculatings;
using static Mahjong.Domain.Services.ScoreCalculateService;
using static Mahjong.Domain.Services.AgariService;
using Mahjong.Domain.Models.HandCalculatings.Yaku;
using Mahjong.Domain.Models.Melds;
using Mahjong.Domain.Models.Tiles;

namespace Mahjong.Domain.Services;

internal class HandResponse
{
    public Score Score { get; }
    public int Han { get; }
    public int Fu { get; }
    public List<YakuBase> Yaku { get; }
    public string? Error { get; }
    public List<FuDetail> FuDetailSet { get; }

    public HandResponse(Score? socre = null,
        int han = 0,
        int fu = 0,
        List<YakuBase>? yaku = null,
        string? error = null,
        List<FuDetail>? fuDetails = null)
    {
        Score = socre ?? new(0, 0);
        Han = han;
        Fu = fu;
        Yaku = yaku ?? new();
        Error = error;
        FuDetailSet = fuDetails ?? new();
    }
}

internal static class HandCalculateService
{
    private static HandConfig? config_;

    public static HandResponse EstimateHandValue(
        TileList tiles,
        Tile? winTile,
        HandConfig config,
        List<Meld>? melds = null,
        TileList? doraIndicators = null)
    {
        config_ = config;
        melds ??= new();
        doraIndicators ??= new();

        var handYaku = new List<YakuBase>();
        var tileArray = tiles.ToTileArray();
        var openedMelds = melds.Where(x => x.IsOpen).Select(x => x.Tiles);
        var allMelds = melds.Select(x => x.Tiles);
        var isOpenHand = openedMelds.Any();

        if (config_.IsNagashiMangan)
        {
            handYaku.Add(new NagashiMangan());
            var fu = 30;
            var han = new NagashiMangan().HanClosed;
            var cost = CalculateScore(han, fu, config_, false);
            return new HandResponse(cost, han, fu, handYaku);
        }
        if (winTile is null) throw new ArgumentException(null, nameof(winTile));

        if (!IsAgari(tiles, allMelds))
        {
            return new HandResponse(error: "Hand is not winning");
        }



    }
}