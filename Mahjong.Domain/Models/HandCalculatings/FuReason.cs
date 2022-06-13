namespace Mahjong.Domain.Models.HandCalculatings;

public enum FuReason
{
    None,
    /// <summary>
    /// 副底 20符(※七対子のみ25符)
    /// </summary>
    Base,
    /// <summary>
    /// 符なし(喰い平和) 2符
    /// </summary>
    HandWithoutHu,
    /// <summary>
    /// ツモ 2符
    /// </summary>
    Tsumo,
    /// <summary>
    /// 面前ロン 10符
    /// </summary>
    MenzenRon,
    /// <summary>
    /// ペンチャン待ち 2符
    /// </summary>
    Penchan,
    /// <summary>
    /// カンチャン待ち 2符
    /// </summary>
    Kanchan,
    /// <summary>
    /// 単騎待ち 2符
    /// </summary>
    PairWait,
    /// <summary>
    /// 役牌の雀頭 2符
    /// </summary>
    ValuedPair,
    /// <summary>
    /// 明刻 2符
    /// </summary>
    OpenPon,
    /// <summary>
    /// 暗刻 4符
    /// </summary>
    ClosedPon,
    /// <summary>
    /// 么九明刻 4符
    /// </summary>
    OpenYaochuPon,
    /// <summary>
    /// 么九暗刻 8符
    /// </summary>
    ClosedYaochuPon,
    /// <summary>
    /// 明槓 8符
    /// </summary>
    OpenKan,
    /// <summary>
    /// 暗槓 16符
    /// </summary>
    ClosedKan,
    /// <summary>
    /// 么九明槓 16符
    /// </summary>
    OpenYaochuKan,
    /// <summary>
    /// 么九暗槓 32符
    /// </summary>
    ClosedYaochuKan
}