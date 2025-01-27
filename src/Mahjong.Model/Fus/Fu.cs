namespace Mahjong.Model.Fus;

public abstract record Fu
{
    #region シングルトンプロパティ

    public static Base Base { get; } = new();
    public static Menzen Menzen { get; } = new();
    public static Chiitoitsu Chiitoitsu { get; } = new();
    public static OpenPinfuBase OpenPinfuBase { get; } = new();
    public static Tsumo Tsumo { get; } = new();

    // 待ち
    public static Kanchan Kanchan { get; } = new();
    public static Penchan Penchan { get; } = new();
    public static Tanki Tanki { get; } = new();

    // 雀頭
    public static PlayerWindToitsu PlayerWindToitsu { get; } = new();
    public static RoundWindToitsu RoundWindToitsu { get; } = new();
    public static DragonToitsu DragonToitsu { get; } = new();

    // 面子
    public static ChuuchanMinko ChuuchanMinko { get; } = new();
    public static YaochuuMinko YaochuuMinko { get; } = new();
    public static ChuuchanAnko ChuuchanAnko { get; } = new();
    public static YaochuuAnko YaochuuAnko { get; } = new();
    public static ChuuchanMinkan ChuuchanMinkan { get; } = new();
    public static YaochuuMinkan YaochuuMinkan { get; } = new();
    public static ChuuchanAnkan ChuuchanAnkan { get; } = new();
    public static YaochuuAnkan YaochuuAnkan { get; } = new();

    #endregion シングルトンプロパティ

    public abstract string Name { get; }
    public abstract int Value { get; }

    public override string ToString()
    {
        return $"{Name}:{Value}符";
    }
}

public record Base : Fu
{
    public override string Name => "副底";
    public override int Value => 20;
}

public record Menzen : Fu
{
    public override string Name => "面前加符";
    public override int Value => 10;
}

public record Chiitoitsu : Fu
{
    public override string Name => "七対子";
    public override int Value => 25;
}

public record OpenPinfuBase : Fu
{
    public override string Name => "副底(食い平和)";
    public override int Value => 30;
}

public record Tsumo : Fu
{
    public override string Name => "自摸";
    public override int Value => 2;
}

public record Kanchan : Fu
{
    public override string Name => "嵌張待ち";
    public override int Value => 2;
}

public record Penchan : Fu
{
    public override string Name => "辺張待ち";
    public override int Value => 2;
}

public record Tanki : Fu
{
    public override string Name => "単騎待ち";
    public override int Value => 2;
}

public record PlayerWindToitsu : Fu
{
    public override string Name => "自風雀頭";
    public override int Value => 2;
}

public record RoundWindToitsu : Fu
{
    public override string Name => "場風雀頭";
    public override int Value => 2;
}

public record DragonToitsu : Fu
{
    public override string Name => "三元牌雀頭";
    public override int Value => 2;
}

public record ChuuchanMinko : Fu
{
    public override string Name => "中張明刻";
    public override int Value => 2;
}

public record YaochuuMinko : Fu
{
    public override string Name => "么九明刻";
    public override int Value => 4;
}

public record ChuuchanAnko : Fu
{
    public override string Name => "中張暗刻";
    public override int Value => 4;
}

public record YaochuuAnko : Fu
{
    public override string Name => "么九暗刻";
    public override int Value => 8;
}

public record ChuuchanMinkan : Fu
{
    public override string Name => "中張明槓";
    public override int Value => 8;
}

public record YaochuuMinkan : Fu
{
    public override string Name => "么九明槓";
    public override int Value => 16;
}

public record ChuuchanAnkan : Fu
{
    public override string Name => "中張暗槓";
    public override int Value => 16;
}

public record YaochuuAnkan : Fu
{
    public override string Name => "么九暗槓";
    public override int Value => 32;
}
