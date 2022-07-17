using Mahjong.Domain.Models.Tiles;

namespace Mahjong.Domain.Models.HandCalculatings;

/// <summary>
/// 点数に関わる場の状況
/// </summary>
internal class HandConfig : ValueObject<HandConfig>
{
    /// <summary>
    /// ルール
    /// </summary>
    public OptionalRules Rurles { get; }
    /// <summary>
    /// 場風
    /// </summary>
    public TileKind RoundWind { get; }
    /// <summary>
    /// 自風
    /// </summary>
    public TileKind PlayerWind { get; }
    /// <summary>
    /// ツモ上がり/出上がり
    /// </summary>
    public bool IsTsumo { get; }
    /// <summary>
    /// リーチ
    /// </summary>
    public bool IsRiichi { get; }
    /// <summary>
    /// 一発
    /// </summary>
    public bool IsIppatsu { get; }
    /// <summary>
    /// 嶺上開花
    /// </summary>
    public bool IsRinshan { get; }
    /// <summary>
    /// 槍槓
    /// </summary>
    public bool IsChankan { get; }
    /// <summary>
    /// 海底撈月
    /// </summary>
    public bool IsHaitei { get; }
    /// <summary>
    /// 河底撈魚
    /// </summary>
    public bool IsHoutei { get; }
    /// <summary>
    /// ダブル立直
    /// </summary>
    public bool IsDaburuRiichi { get; }
    /// <summary>
    /// 流し満貫
    /// </summary>
    public bool IsNagashiMangan { get; }
    /// <summary>
    /// 天和
    /// </summary>
    public bool IsTenhou { get; }
    /// <summary>
    /// 地和
    /// </summary>
    public bool IsChiihou { get; }
    /// <summary>
    /// 人和
    /// </summary>
    public bool IsRenhou { get; }
    /// <summary>
    /// 親
    /// </summary>
    public bool IsDealer => PlayerWind == TileKind.East;

    public HandConfig(
        OptionalRules rules,
        TileKind roundWind,
        TileKind playerWind,
        bool isTsumo,
        bool isRiichi = false,
        bool isIppatsu = false,
        bool isRinshan = false,
        bool isChankan = false,
        bool isHaitei = false,
        bool isHoutei = false,
        bool isDaburuRiichi = false,
        bool isNagashiMangan = false,
        bool isTenhou = false,
        bool isChiihou = false,
        bool isRenhou = false)
    {
        Rurles = rules;
        RoundWind = roundWind;
        PlayerWind = playerWind;
        IsTsumo = isTsumo;
        IsRiichi = isRiichi;
        IsIppatsu = isIppatsu;
        IsRinshan = isRinshan;
        IsChankan = isChankan;
        IsHaitei = isHaitei;
        IsHoutei = isHoutei;
        IsDaburuRiichi = isDaburuRiichi;
        IsNagashiMangan = isNagashiMangan;
        IsTenhou = isTenhou;
        IsChiihou = isChiihou;
        IsRenhou = isRenhou;
    }

    public override bool Equals(ValueObject<HandConfig>? other)
    {
        return other is HandConfig config &&
            Rurles == config.Rurles &&
            RoundWind == config.RoundWind &&
            PlayerWind == config.PlayerWind &&
            IsTsumo == config.IsTsumo &&
            IsRiichi == config.IsRiichi &&
            IsIppatsu == config.IsIppatsu &&
            IsRinshan == config.IsRinshan &&
            IsChankan == config.IsChankan &&
            IsHaitei == config.IsHaitei &&
            IsHoutei == config.IsHoutei &&
            IsDaburuRiichi == config.IsDaburuRiichi &&
            IsNagashiMangan == config.IsNagashiMangan &&
            IsTenhou == config.IsTenhou &&
            IsChiihou == config.IsChiihou &&
            IsRenhou == config.IsRenhou;
    }

    public override int GetHashCodeCore()
    {
        return new
        {
            Rurles,
            RoundWind,
            PlayerWind,
            IsTsumo,
            IsRiichi,
            IsIppatsu,
            IsRinshan,
            IsChankan,
            IsHaitei,
            IsHoutei,
            IsDaburuRiichi,
            IsNagashiMangan,
            IsTenhou,
            IsChiihou,
            IsRenhou
        }.GetHashCode();
    }
}