namespace Mahjong.Domain.Models.HandCalculatings;

/// <summary>
/// 点数に関わるルール
/// </summary>
internal class OptionalRules : ValueObject<OptionalRules>
{
    /// <summary>
    /// 喰いタンあり/なし
    /// </summary>
    public bool HasOpenTanyao { get; init; }

    /// <summary>
    /// 赤ドラ(1枚ずつ)あり/なし
    /// </summary>
    public bool HasAkaDora { get; init; }

    /// <summary>
    /// ダブル役満あり/なし
    /// </summary>
    public bool HasDoubleYakuman { get; }

    /// <summary>
    /// 数え役満
    /// </summary>
    public Kazoe KazoeLimit { get; }

    /// <summary>
    /// 切り上げ満貫あり/なし
    /// </summary>
    public bool KiriageMangan { get; }

    /// <summary>
    /// 食い平和2符追加あり/なし
    /// </summary>
    public bool OpenPinfu { get; }
    /// <summary>
    /// ピンヅモあり/なし
    /// ピンヅモあり：平和 ツモ 20符 2翻
    /// ピンヅモなし：ツモのみ 30符 1翻
    /// </summary>
    public bool PinfuTsumo { get; }

    /// <summary>
    /// 人和役満扱いかどうか
    /// </summary>
    public bool RenhouAsYakuman { get; }

    /// <summary>
    /// 大車輪あり/なし
    /// </summary>
    public bool HasDaisharin { get; }

    public OptionalRules(
        bool hasOpenTanyao = false,
        bool hasAkaDora = false,
        bool hasDoubleYakuman = true,
        Kazoe kazoeLimit = Kazoe.Limited,
        bool kiriageMangan = false,
        bool openPinfu = true,
        bool pinfuTsumo = true,
        bool renhouAsYakuman = false,
        bool hasDaisharin = false)
    {
        HasOpenTanyao = hasOpenTanyao;
        HasAkaDora = hasAkaDora;
        HasDoubleYakuman = hasDoubleYakuman;
        KazoeLimit = kazoeLimit;
        KiriageMangan = kiriageMangan;
        OpenPinfu = openPinfu;
        PinfuTsumo = pinfuTsumo;
        RenhouAsYakuman = renhouAsYakuman;
        HasDaisharin = hasDaisharin;
    }

    public override bool Equals(ValueObject<OptionalRules>? other)
    {
        return other is OptionalRules rules &&
            HasOpenTanyao == rules.HasOpenTanyao &&
            HasAkaDora == rules.HasAkaDora &&
            HasDoubleYakuman == rules.HasDoubleYakuman &&
            KazoeLimit == rules.KazoeLimit &&
            KiriageMangan == rules.KiriageMangan &&
            OpenPinfu == rules.OpenPinfu &&
            PinfuTsumo == rules.PinfuTsumo &&
            RenhouAsYakuman == rules.RenhouAsYakuman &&
            HasDaisharin == rules.HasDaisharin;
    }

    public override int GetHashCodeCore()
    {
        return new
        {
            HasOpenTanyao,
            HasAkaDora,
            HasDoubleYakuman,
            KazoeLimit,
            KiriageMangan,
            OpenPinfu,
            PinfuTsumo,
            RenhouAsYakuman,
            HasDaisharin
        }.GetHashCode();
    }
}