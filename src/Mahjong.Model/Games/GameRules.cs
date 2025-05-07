namespace Mahjong.Model.Games;

/// <summary>
/// 点数に関わるルール
/// </summary>
public record GameRules
{
    /// <summary>
    /// 喰いタンあり/なし
    /// </summary>
    public bool KuitanEnabled { get; init; } = true;

    /// <summary>
    /// ダブル役満あり/なし
    /// </summary>
    public bool DaburuYakumanEnabled { get; init; } = true;

    /// <summary>
    /// 数え役満
    /// </summary>
    public Kazoe KazoeLimit { get; init; } = Kazoe.Limited;

    /// <summary>
    /// 切り上げ満貫あり/なし
    /// </summary>
    public bool KiriageEnabled { get; init; } = false;

    /// <summary>
    /// ピンヅモあり/なし
    /// </summary>
    public bool PinzumoEnabled { get; init; } = true;

    /// <summary>
    /// 人和役満あり/なし
    /// </summary>
    public bool RenhouAsYakumanEnabled { get; init; } = false;

    /// <summary>
    /// 大車輪あり/なし
    /// </summary>
    public bool DaisharinEnabled { get; init; } = false;
}
