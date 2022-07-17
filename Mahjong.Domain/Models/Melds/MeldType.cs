namespace Mahjong.Domain.Models.Melds;

internal enum MeldType
{
    None,

    /// <summary>
    /// チー
    /// </summary>
    Chi,
    /// <summary>
    /// ポン
    /// </summary>
    Pon,
    /// <summary>
    /// 暗槓
    /// </summary>
    Ankan,
    /// <summary>
    /// 小明槓
    /// </summary>
    Shouminkan,
    /// <summary>
    /// 大明槓
    /// </summary>
    Daiminkan,
    /// <summary>
    /// 抜き
    /// </summary>
    Nuki,
}