namespace Mahjong.Model.Settings;

public record Setting()
{
    public static Setting Default { get; } = new();
}