namespace Mahjong.Model.Tiles;

/// <summary>
/// 牌 <para/>
/// 全34種類の牌を表現するクラス
/// 0～33までのIdを持つ
/// 同種の牌の区別はライブラリ使用側が行えばいい
/// </summary>
public record Tile(TileType Type) : IComparable<Tile>
{
    #region シングルトンプロパティ

    /// <summary>
    /// 一萬
    /// </summary>
    public static Tile Man1 { get; } = new(TileType.Man1);
    /// <summary>
    /// 二萬
    /// </summary>
    public static Tile Man2 { get; } = new(TileType.Man2);
    /// <summary>
    /// 三萬
    /// </summary>
    public static Tile Man3 { get; } = new(TileType.Man3);
    /// <summary>
    /// 四萬
    /// </summary>
    public static Tile Man4 { get; } = new(TileType.Man4);
    /// <summary>
    /// 五萬
    /// </summary>
    public static Tile Man5 { get; } = new(TileType.Man5);
    /// <summary>
    /// 六萬
    /// </summary>
    public static Tile Man6 { get; } = new(TileType.Man6);
    /// <summary>
    /// 七萬
    /// </summary>
    public static Tile Man7 { get; } = new(TileType.Man7);
    /// <summary>
    /// 八萬
    /// </summary>
    public static Tile Man8 { get; } = new(TileType.Man8);
    /// <summary>
    /// 九萬
    /// </summary>
    public static Tile Man9 { get; } = new(TileType.Man9);
    /// <summary>
    /// 一筒
    /// </summary>
    public static Tile Pin1 { get; } = new(TileType.Pin1);
    /// <summary>
    /// 二筒
    /// </summary>
    public static Tile Pin2 { get; } = new(TileType.Pin2);
    /// <summary>
    /// 三筒
    /// </summary>
    public static Tile Pin3 { get; } = new(TileType.Pin3);
    /// <summary>
    /// 四筒
    /// </summary>
    public static Tile Pin4 { get; } = new(TileType.Pin4);
    /// <summary>
    /// 五筒
    /// </summary>
    public static Tile Pin5 { get; } = new(TileType.Pin5);
    /// <summary>
    /// 六筒
    /// </summary>
    public static Tile Pin6 { get; } = new(TileType.Pin6);
    /// <summary>
    /// 七筒
    /// </summary>
    public static Tile Pin7 { get; } = new(TileType.Pin7);
    /// <summary>
    /// 八筒
    /// </summary>
    public static Tile Pin8 { get; } = new(TileType.Pin8);
    /// <summary>
    /// 九筒
    /// </summary>
    public static Tile Pin9 { get; } = new(TileType.Pin9);
    /// <summary>
    /// 一索
    /// </summary>
    public static Tile Sou1 { get; } = new(TileType.Sou1);
    /// <summary>
    /// 二索
    /// </summary>
    public static Tile Sou2 { get; } = new(TileType.Sou2);
    /// <summary>
    /// 三索
    /// </summary>
    public static Tile Sou3 { get; } = new(TileType.Sou3);
    /// <summary>
    /// 四索
    /// </summary>
    public static Tile Sou4 { get; } = new(TileType.Sou4);
    /// <summary>
    /// 五索
    /// </summary>
    public static Tile Sou5 { get; } = new(TileType.Sou5);
    /// <summary>
    /// 六索
    /// </summary>
    public static Tile Sou6 { get; } = new(TileType.Sou6);
    /// <summary>
    /// 七索
    /// </summary>
    public static Tile Sou7 { get; } = new(TileType.Sou7);
    /// <summary>
    /// 八索
    /// </summary>
    public static Tile Sou8 { get; } = new(TileType.Sou8);
    /// <summary>
    /// 九索
    /// </summary>
    public static Tile Sou9 { get; } = new(TileType.Sou9);
    /// <summary>
    /// 東
    /// </summary>
    public static Tile Ton { get; } = new(TileType.Ton);
    /// <summary>
    /// 南
    /// </summary>
    public static Tile Nan { get; } = new(TileType.Nan);
    /// <summary>
    /// 西
    /// </summary>
    public static Tile Sha { get; } = new(TileType.Sha);
    /// <summary>
    /// 北
    /// </summary>
    public static Tile Pei { get; } = new(TileType.Pei);
    /// <summary>
    /// 白
    /// </summary>
    public static Tile Haku { get; } = new(TileType.Haku);
    /// <summary>
    /// 發
    /// </summary>
    public static Tile Hatsu { get; } = new(TileType.Hatsu);
    /// <summary>
    /// 中
    /// </summary>
    public static Tile Chun { get; } = new(TileType.Chun);

    #endregion シングルトンプロパティ

    public static IEnumerable<Tile> All { get; } = Enum.GetValues<TileType>().Select(x => new Tile(x));
    public static IEnumerable<Tile> Mans { get; } = All.Where(x => x.IsMan);
    public static IEnumerable<Tile> Pins { get; } = All.Where(x => x.IsPin);
    public static IEnumerable<Tile> Sous { get; } = All.Where(x => x.IsSou);
    public static IEnumerable<Tile> Honors { get; } = All.Where(x => x.IsHonor);
    public static IEnumerable<Tile> Chuuchans { get; } = All.Where(x => x.IsChuuchan);
    public static IEnumerable<Tile> Yaochuus { get; } = All.Where(x => x.IsYaochuu);

    /// <summary>
    /// 牌に書かれている番号 萬子・筒子・索子は1～9 字牌は東南西北白發中の順に1～7
    /// </summary>
    public int Number =>
        IsMan ? (int)Type + 1
        : IsPin ? (int)Type - 8
        : IsSou ? (int)Type - 17
        : IsHonor ? (int)Type - 26
        : throw new InvalidOperationException();
    /// <summary>
    /// 萬子かどうか
    /// </summary>
    public bool IsMan => Type is >= TileType.Man1 and <= TileType.Man9;
    /// <summary>
    /// 筒子かどうか
    /// </summary>
    public bool IsPin => Type is >= TileType.Pin1 and <= TileType.Pin9;
    /// <summary>
    /// 索子かどうか
    /// </summary>
    public bool IsSou => Type is >= TileType.Sou1 and <= TileType.Sou9;
    /// <summary>
    /// 風牌かどうか
    /// </summary>
    public bool IsWind => Type is >= TileType.Ton and <= TileType.Pei;
    /// <summary>
    /// 三元牌かどうか
    /// </summary>
    public bool IsDragon => Type is >= TileType.Haku and <= TileType.Chun;
    /// <summary>
    /// 数牌かどうか
    /// </summary>
    public bool IsSuit => IsMan || IsPin || IsSou;
    /// <summary>
    /// 字牌かどうか
    /// </summary>
    public bool IsHonor => IsWind || IsDragon;
    /// <summary>
    /// 中張牌かどうか
    /// </summary>
    public bool IsChuuchan => !IsYaochuu;
    /// <summary>
    /// 么九牌かどうか
    /// </summary>
    public bool IsYaochuu => IsRoutou || IsHonor;
    /// <summary>
    /// 老頭牌かどうか
    /// </summary>
    public bool IsRoutou => Type is TileType.Man1 or TileType.Man9 or TileType.Pin1 or TileType.Pin9 or TileType.Sou1 or TileType.Sou9;

    public Tile(int num) : this((TileType)num)
    {
        Type = num is >= (int)TileType.Man1 and <= (int)TileType.Chun ? (TileType)num : throw new ArgumentException($"牌種別IDは{0}～{33}です。{nameof(num)}:{num}", nameof(num));
    }

    public int CompareTo(Tile? other)
    {
        return other is not null ? Type.CompareTo(other.Type) : throw new ArgumentNullException(nameof(other));
    }

    public static bool operator <(Tile? left, Tile? right)
    {
        return left is null ? right is not null : left.CompareTo(right) < 0;
    }

    public static bool operator <=(Tile? left, Tile? right)
    {
        return left is null || left.CompareTo(right) <= 0;
    }

    public static bool operator >(Tile? left, Tile? right)
    {
        return left is not null && left.CompareTo(right) > 0;
    }

    public static bool operator >=(Tile? left, Tile? right)
    {
        return left is null ? right is null : left.CompareTo(right) >= 0;
    }

    public override string ToString()
    {
        return Type.ToStr();
    }
}
