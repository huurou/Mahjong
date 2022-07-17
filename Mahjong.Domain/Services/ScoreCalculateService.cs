using Mahjong.Domain.Models.HandCalculatings;

namespace Mahjong.Domain.Services;

internal static class ScoreCalculateService
{
    /// <summary>
    /// 翻と符から点数を計算する
    /// </summary>
    /// <param name="han">翻</param>
    /// <param name="fu">符</param>
    /// <param name="config">点数にかかわる設定・場の状況</param>
    /// <param name="isYakuman">役満かどうか</param>
    /// <returns></returns>
    public static Score CalculateScore(int han, int fu, HandConfig config, bool isYakuman = false)
    {
        // 数え役満
        if (han >= 13 && !isYakuman)
        {
            if (config.Rurles.KazoeLimit == Kazoe.Limited)
            {
                han = 13;
            }
            else if (config.Rurles.KazoeLimit == Kazoe.Sanbaiman)
            {
                han = 12;
            }
        }

        // rounded: 一家あたりの点数 跳満(子):12000なら3000点
        int rounded, doubleRounded, fourRounded, sixRounded;
        if (han >= 5)
        {
            rounded = han switch
            {
                >= 78 => 48000,
                >= 65 => 40000,
                >= 52 => 32000,
                >= 39 => 24000,
                >= 26 => 16000,
                >= 13 => 8000,
                >= 11 => 6000,
                >= 8 => 4000,
                >= 6 => 3000,
                _ => 2000,
            };
            doubleRounded = rounded * 2;
            fourRounded = doubleRounded * 2;
            sixRounded = doubleRounded * 3;
        }
        else
        {
            var basePoint = fu * Math.Pow(2, 2 + han);
            rounded = (int)((basePoint + 99) / 100) * 100;
            doubleRounded = (int)((2 * basePoint + 99) / 100) * 100;
            fourRounded = (int)((4 * basePoint + 99) / 100) * 100;
            sixRounded = (int)((6 * basePoint + 99) / 100) * 100;

            var isKiriage = false;
            if (config.Rurles.KiriageMangan)
            {
                if (han == 4 && fu == 30)
                {
                    isKiriage = true;
                }
                if (han == 3 && fu == 60)
                {
                    isKiriage = true;
                }
            }

            // 満貫
            if (rounded > 2000 || isKiriage)
            {
                rounded = 2000;
                doubleRounded = rounded * 2;
                fourRounded = doubleRounded * 2;
                sixRounded = doubleRounded * 3;
            }
        }

        return config.IsTsumo
            ? new Score(doubleRounded, config.IsDealer ? doubleRounded : rounded)
            : new Score(config.IsDealer ? sixRounded : fourRounded, 0);
    }
}