namespace Mahjong.Model.Tiles;

/// <summary>
/// 牌タイプ
/// </summary>
public enum TileType
{
    /// <summary>
    /// 一萬
    /// </summary>
    Man1,
    /// <summary>
    /// 二萬
    /// </summary>
    Man2,
    /// <summary>
    /// 三萬
    /// </summary>
    Man3,
    /// <summary>
    /// 四萬
    /// </summary>
    Man4,
    /// <summary>
    /// 五萬
    /// </summary>
    Man5,
    /// <summary>
    /// 六萬
    /// </summary>
    Man6,
    /// <summary>
    /// 七萬
    /// </summary>
    Man7,
    /// <summary>
    /// 八萬
    /// </summary>
    Man8,
    /// <summary>
    /// 九萬
    /// </summary>
    Man9,
    /// <summary>
    /// 一筒
    /// </summary>
    Pin1,
    /// <summary>
    /// 二筒
    /// </summary>
    Pin2,
    /// <summary>
    /// 三筒
    /// </summary>
    Pin3,
    /// <summary>
    /// 四筒
    /// </summary>
    Pin4,
    /// <summary>
    /// 五筒
    /// </summary>
    Pin5,
    /// <summary>
    /// 六筒
    /// </summary>
    Pin6,
    /// <summary>
    /// 七筒
    /// </summary>
    Pin7,
    /// <summary>
    /// 八筒
    /// </summary>
    Pin8,
    /// <summary>
    /// 九筒
    /// </summary>
    Pin9,
    /// <summary>
    /// 一索
    /// </summary>
    Sou1,
    /// <summary>
    /// 二索
    /// </summary>
    Sou2,
    /// <summary>
    /// 三索
    /// </summary>
    Sou3,
    /// <summary>
    /// 四索
    /// </summary>
    Sou4,
    /// <summary>
    /// 五索
    /// </summary>
    Sou5,
    /// <summary>
    /// 六索
    /// </summary>
    Sou6,
    /// <summary>
    /// 七索
    /// </summary>
    Sou7,
    /// <summary>
    /// 八索
    /// </summary>
    Sou8,
    /// <summary>
    /// 九索
    /// </summary>
    Sou9,
    /// <summary>
    /// 東
    /// </summary>
    Ton,
    /// <summary>
    /// 南
    /// </summary>
    Nan,
    /// <summary>
    /// 西
    /// </summary>
    Sha,
    /// <summary>
    /// 北
    /// </summary>
    Pei,
    /// <summary>
    /// 白
    /// </summary>
    Haku,
    /// <summary>
    /// 發
    /// </summary>
    Hatsu,
    /// <summary>
    /// 中
    /// </summary>
    Chun,
}

public static class TileTypeExtensions
{
    public static string ToStr(this TileType tileType)
    {
        return tileType switch
        {
            TileType.Man1 => "一",
            TileType.Man2 => "二",
            TileType.Man3 => "三",
            TileType.Man4 => "四",
            TileType.Man5 => "五",
            TileType.Man6 => "六",
            TileType.Man7 => "七",
            TileType.Man8 => "八",
            TileType.Man9 => "九",
            TileType.Pin1 => "(1)",
            TileType.Pin2 => "(2)",
            TileType.Pin3 => "(3)",
            TileType.Pin4 => "(4)",
            TileType.Pin5 => "(5)",
            TileType.Pin6 => "(6)",
            TileType.Pin7 => "(7)",
            TileType.Pin8 => "(8)",
            TileType.Pin9 => "(9)",
            TileType.Sou1 => "1",
            TileType.Sou2 => "2",
            TileType.Sou3 => "3",
            TileType.Sou4 => "4",
            TileType.Sou5 => "5",
            TileType.Sou6 => "6",
            TileType.Sou7 => "7",
            TileType.Sou8 => "8",
            TileType.Sou9 => "9",
            TileType.Ton => "東",
            TileType.Nan => "南",
            TileType.Sha => "西",
            TileType.Pei => "北",
            TileType.Haku => "白",
            TileType.Hatsu => "發",
            TileType.Chun => "中",
            _ => throw new NotSupportedException()
        };
    }
}
