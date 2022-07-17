namespace Mahjong.Domain.Models.HandCalculatings;

/// <summary>
/// 点数
/// </summary>
internal class Score
{
    public int Main { get; }
    public int Additional { get; }

    public Score(int main, int additional)
    {
        Main = main;
        Additional = additional;
    }
}