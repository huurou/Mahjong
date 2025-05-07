using Mahjong.Model.Tiles;

namespace Mahjong.Model.Shantens;

public record ShantenContext(TileList TileList)
{
    public Tile Tile { get; init; } = Tile.Man1;
    public int MentsuCount { get; init; }
    public int ToitsuCount { get; init; }
    public int TatsuCount { get; init; }
    public int KantsuCount { get; init; }
    public IsolationSet IsolationSet { get; init; } = [];
    public List<Tile> KantsuNumbers { get; init; } = [];

    public ShantenContext ScanHonor()
    {
        var context = this;
        foreach (var honor in Tile.Honors)
        {
            context = context.TileList.CountOf(honor) switch
            {
                1 => context with { IsolationSet = context.IsolationSet.Add(honor) },
                2 => context with { ToitsuCount = context.ToitsuCount + 1 },
                3 => context with { MentsuCount = context.MentsuCount + 1 },
                4 => context with
                {
                    MentsuCount = context.MentsuCount + 1,
                    KantsuCount = context.KantsuCount + 1,
                    IsolationSet = context.IsolationSet.Add(honor),
                },
                _ => context,
            };
        }
        if (context.KantsuCount != 0 && context.TileList.Count % 3 == 2)
        {
            context = context with { KantsuCount = context.KantsuCount - 1 };
        }
        return context;
    }

    public int ScanNumber()
    {
        var context = this;
        while (context.TileList.CountOf(context.Tile) == 0)
        {
            context = context with { Tile = new Tile(context.Tile.Type + 1) };
            if (context.Tile.IsHonor)
            {
                return context.CalcShanten();
            }
        }
        return context.TileList.CountOf(context.Tile) switch
        {
            1 => context.ScanNumber1(),
            2 => context.ScanNumber2(),
            3 => context.ScanNumber3(),
            4 => context.ScanNumber4(),
            _ => throw new InvalidOperationException(),
        };
    }

    private int ScanNumber1()
    {
        List<int> shantens = [];
        if (Tile.Number <= 6 &&
            TileList.CountOf(Tile + 1) == 1 &&
            TileList.CountOf(Tile + 2) > 0 &&
            TileList.CountOf((Tile + 3)) != 4)
        {
            shantens.Add(RemoveShuntsu().ScanNumber());
        }
        else
        {
            shantens.Add(RemoveIsolation().ScanNumber());
            if (Tile.Number <= 7 && TileList.CountOf(Tile + 2) > 0)
            {
                if (TileList.CountOf(Tile + 1) > 0)
                {
                    shantens.Add(RemoveShuntsu().ScanNumber());
                }
                shantens.Add(RemoveKanchan().ScanNumber());
            }
            if (Tile.Number <= 8 && TileList.CountOf(Tile + 1) > 0)
            {
                shantens.Add(RemoveRyanmen().ScanNumber());
            }
        }
        return shantens.Min();
    }

    private int ScanNumber2()
    {
        List<int> shantens = [];
        shantens.Add(RemoveToitsu().ScanNumber());
        if (Tile.Number <= 7 && TileList.CountOf(Tile + 1) > 0 && TileList.CountOf(Tile + 2) > 0)
        {
            shantens.Add(RemoveShuntsu().ScanNumber());
        }
        return shantens.Min();
    }

    private int ScanNumber3()
    {
        List<int> shantens = [];
        shantens.Add(RemoveKoutsu().ScanNumber());
        var toitsuRemoved = RemoveToitsu();
        if (Tile.Number <= 7 && toitsuRemoved.TileList.CountOf(Tile + 1) > 0 && toitsuRemoved.TileList.CountOf(Tile + 2) > 0)
        {
            shantens.Add(toitsuRemoved.RemoveShuntsu().ScanNumber());
        }
        else
        {
            if (Tile.Number <= 7 && toitsuRemoved.TileList.CountOf(Tile + 2) > 0)
            {
                shantens.Add(toitsuRemoved.RemoveKanchan().ScanNumber());
            }
            if (Tile.Number <= 8 && toitsuRemoved.TileList.CountOf(Tile + 1) > 0)
            {
                shantens.Add(toitsuRemoved.RemoveRyanmen().ScanNumber());
            }
        }
        if (Tile.Number <= 7 && TileList.CountOf(Tile + 1) >= 2 && TileList.CountOf(Tile + 2) >= 2)
        {
            shantens.Add(RemoveShuntsu().RemoveShuntsu().ScanNumber());
        }
        return shantens.Min();
    }

    private int ScanNumber4()
    {
        List<int> shantens = [];
        var koutsuRemoved = RemoveKoutsu();
        if (Tile.Number <= 7 && koutsuRemoved.TileList.CountOf(Tile + 2) > 0)
        {
            if (koutsuRemoved.TileList.CountOf(Tile + 1) > 0)
            {
                shantens.Add(koutsuRemoved.RemoveShuntsu().ScanNumber());
            }
            shantens.Add(koutsuRemoved.RemoveKanchan().ScanNumber());
        }
        if (Tile.Number <= 8 && koutsuRemoved.TileList.CountOf(Tile + 1) > 0)
        {
            shantens.Add(koutsuRemoved.RemoveRyanmen().ScanNumber());
        }
        shantens.Add(koutsuRemoved.RemoveIsolation().ScanNumber());
        var toitsuRemoved = RemoveToitsu();
        if (Tile.Number <= 7 && toitsuRemoved.TileList.CountOf(Tile + 2) > 0)
        {
            if (toitsuRemoved.TileList.CountOf(Tile + 1) > 0)
            {
                shantens.Add(toitsuRemoved.RemoveShuntsu().ScanNumber());
            }
            shantens.Add(toitsuRemoved.RemoveKanchan().ScanNumber());
        }
        if (Tile.Number <= 8 && toitsuRemoved.TileList.CountOf(Tile + 1) > 0)
        {
            shantens.Add(toitsuRemoved.RemoveRyanmen().ScanNumber());
        }
        return shantens.Min();
    }

    private int CalcShanten()
    {
        var shanten = 8 - MentsuCount * 2 - ToitsuCount - TatsuCount;
        var mentsuKouho = MentsuCount + TatsuCount;
        if (ToitsuCount != 0)
        {
            mentsuKouho += ToitsuCount - 1;
        }
        // 同種の数牌を4枚持っているときに刻子&単騎待ちとみなされないようにする
        else if (IsolationSet.Count > 0 && KantsuNumbers.Count > 0 &&
            IsolationSet.All(KantsuNumbers.Contains))
        {
            shanten++;
        }
        if (mentsuKouho > 4)
        {
            shanten += mentsuKouho - 4;
        }
        if (shanten != ShantenCalculator.AGARI_SHANTEN && shanten < KantsuCount)
        {
            shanten = KantsuCount;
        }
        return shanten;
    }

    private ShantenContext RemoveKoutsu()
    {
        return this with
        {
            TileList = TileList.Remove(Tile, 3),
            MentsuCount = MentsuCount + 1,
        };
    }

    private ShantenContext RemoveShuntsu()
    {
        return this with
        {
            TileList = TileList.Remove(Tile).Remove(new Tile(Tile.Type + 1)).Remove(new Tile(Tile.Type + 2)),
            MentsuCount = MentsuCount + 1,
        };
    }

    private ShantenContext RemoveToitsu()
    {
        return this with
        {
            TileList = TileList.Remove(Tile, 2),
            ToitsuCount = ToitsuCount + 1,
        };
    }

    private ShantenContext RemoveRyanmen()
    {
        return this with
        {
            TileList = TileList.Remove(Tile).Remove(new Tile(Tile.Type + 1)),
            TatsuCount = TatsuCount + 1,
        };
    }

    private ShantenContext RemoveKanchan()
    {
        return this with
        {
            TileList = TileList.Remove(Tile).Remove(new Tile(Tile.Type + 2)),
            TatsuCount = TatsuCount + 1,
        };
    }

    private ShantenContext RemoveIsolation()
    {
        return this with
        {
            TileList = TileList.Remove(Tile),
            IsolationSet = IsolationSet.Add(Tile),
        };
    }
}
