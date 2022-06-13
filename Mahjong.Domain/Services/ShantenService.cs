using Mahjong.Domain.Models.Tiles;
using static Mahjong.Domain.Models.Tiles.TileKind;

namespace Mahjong.Domain.Services;

public static class ShantenService
{
    /// <summary>
    /// シャンテン数を計算する
    /// テンパイ:0 あがり:-1
    /// </summary>
    /// <param name="list">手牌</param>
    /// <param name="openSets">副露</param>
    /// <param name="chiitoitsu">七対子込かどうか</param>
    /// <param name="kokushimusou">国士無双込かどうか</param>
    /// <returns></returns>
    public static int CalcShanten(TileList hand, IEnumerable<TileList>? openSets = null,
        bool chiitoitsu = true, bool kokushimusou = true)
    {
        if (hand.Count is not (13 or 14)) throw new ArgumentException("手牌の数が13or14個でないです。", nameof(hand));
        var array = hand.ToTileArray();
        var shanten = 8;
        var meldsCount = 0;
        var tatsuCount = 0;
        var pairsCount = 0;
        var jidahaiCount = 0;
        var honorBits = 0;
        var isolatedBits = 0;
        if (openSets is not null && openSets.Any())
        {
            var isolated = hand.FindIsolatedKindList();
            if (isolated.Any())
            {
                foreach (var meld in openSets)
                {
                    if (meld.Count is not (3 or 4)) throw new ArgumentException("openSetsに3or4個でない組が含まれています。", nameof(openSets));
                    array[meld[0].Kind]--;
                    array[meld[1].Kind]--;
                    array[meld[2].Kind]--;
                    if (meld.Count == 4) array[meld[3].Kind]--; // 槓
                    array[isolated[^1]] = 3;
                    isolated.RemoveAt(isolated.Count - 1);
                }
            }
        }
        else
        {
            // 七対子 国士無双の判定
            // 七対子のシャンテン数: 6-対子
            if (chiitoitsu) shanten = Math.Min(shanten, 6 - TileKindList.AllKinds.Count(x => array[x] == 2));
            // 国士無双のシャンテン数: 13-么九牌
            if (kokushimusou) shanten = Math.Min(shanten, 13 - TileKindList.YaochuList.Count(x => array[x] != 0) 
                                                             - (TileKindList.YaochuList.Any(x => array[x] >= 2) ? 1 : 0));
        }
        RemoveHonor(hand.Count);
        honorBits = 0;
        for (var kind = Man1; kind <= Sou9; kind++)
        {
            honorBits |= array[kind] == 4 ? 1 << (int)kind : 0;
        }
        meldsCount += (14 - hand.Count) / 3;
        Run(Man1);
        return shanten;

        void RemoveHonor(int tileCount)
        {
            var number = 0;
            var isolated = 0;
            for (var kind = East; kind <= Chun; kind++)
            {
                switch (array[kind])
                {
                    case 1:
                        isolated |= 1 << kind - East;
                        break;

                    case 2:
                        pairsCount++;
                        break;

                    case 3:
                        meldsCount++;
                        break;

                    case 4:
                        meldsCount++;
                        jidahaiCount++;
                        number |= 1 << kind - East;
                        isolated |= 1 << kind - East;
                        break;

                    default:
                        break;
                }
            }
            if (jidahaiCount != 0 && hand.Count % 3 == 2) jidahaiCount--;
            if (isolated != 0)
            {
                isolated |= 1 << (int)East;
                if ((number | isolated) == number) honorBits |= 1 << 27;
            }
        }

        void Run(TileKind kind)
        {
            if (shanten == -1) return;

            //牌が存在するインデックスまで移動
            while (array[kind] == 0)
            {
                kind++;
                if (kind >= East) break;
            }
            if (kind >= East)
            {
                UpdateResult();
                return;
            }
            var i = (int)kind;
            i -= i > 18 ? 18 : i > 9 ? 9 : 0;
            switch (array[kind])
            {
                case 1:
                    if (i < 7 && array[kind + 1] == 1 && array[kind + 2] != 0 && array[kind + 3] != 4)
                    {
                        IncreaseSyuntsu(kind);
                        Run(kind + 2);
                        DecreaseSyuntsu(kind);
                    }
                    else
                    {
                        IncreaseIsolatedTile(kind);
                        Run(kind + 1);
                        DecreaseIsolatedTile(kind);
                        if (i < 8 && array[kind + 2] != 0)
                        {
                            if (array[kind + 1] != 0)
                            {
                                IncreaseSyuntsu(kind);
                                Run(kind + 1);
                                DecreaseSyuntsu(kind);
                            }
                            IncreaseTatsuSecond(kind);
                            Run(kind + 1);
                            DecreaseTatsuSecond(kind);
                        }
                        if (i < 9 && array[kind + 1] != 0)
                        {
                            IncreaseTatsuFirst(kind);
                            Run(kind + 1);
                            DecreaseTatsuFirst(kind);
                        }
                    }
                    break;

                case 2:
                    IncreasePair(kind);
                    Run(kind + 1);
                    DecreasePair(kind);
                    if (i < 8 && array[kind + 2] != 0 && array[kind + 1] != 0)
                    {
                        IncreaseSyuntsu(kind);
                        Run(kind);
                        DecreaseSyuntsu(kind);
                    }
                    break;

                case 3:
                    IncreaseSet(kind);
                    Run(kind + 1);
                    DecreaseSet(kind);
                    IncreasePair(kind);
                    if (i < 8 && array[kind + 1] != 0 && array[kind + 2] != 0)
                    {
                        IncreaseSyuntsu(kind);
                        Run(kind + 1);
                        DecreaseSyuntsu(kind);
                    }
                    else
                    {
                        if (i < 8 && array[kind + 2] != 0)
                        {
                            IncreaseTatsuSecond(kind);
                            Run(kind + 1);
                            DecreaseTatsuSecond(kind);
                        }
                        if (i < 9 && array[kind + 1] != 0)
                        {
                            IncreaseTatsuFirst(kind);
                            Run(kind + 1);
                            DecreaseTatsuFirst(kind);
                        }
                    }
                    DecreasePair(kind);

                    if (i < 8 && array[kind + 2] >= 2 && array[kind + 1] >= 2)
                    {
                        IncreaseSyuntsu(kind);
                        IncreaseSyuntsu(kind);
                        Run(kind);
                        DecreaseSyuntsu(kind);
                        DecreaseSyuntsu(kind);
                    }
                    break;

                case 4:
                    IncreaseSet(kind);
                    if (i < 8 && array[kind + 2] != 0)
                    {
                        if (array[kind + 1] != 0)
                        {
                            IncreaseSyuntsu(kind);
                            Run(kind + 1);
                            DecreaseSyuntsu(kind);
                        }
                        IncreaseTatsuSecond(kind);
                        Run(kind + 1);
                        DecreaseTatsuSecond(kind);
                    }
                    if (i < 9 && array[kind + 1] != 0)
                    {
                        IncreaseTatsuFirst(kind);
                        Run(kind + 1);
                        DecreaseTatsuFirst(kind);
                    }
                    IncreaseIsolatedTile(kind);
                    Run(kind + 1);
                    DecreaseIsolatedTile(kind);
                    DecreaseSet(kind);
                    IncreasePair(kind);

                    if (i < 8 && array[kind + 2] != 0)
                    {
                        if (array[kind + 1] != 0)
                        {
                            IncreaseSyuntsu(kind);
                            Run(kind);
                            DecreaseSyuntsu(kind);
                        }
                        IncreaseTatsuSecond(kind);
                        Run(kind + 1);
                        DecreaseTatsuSecond(kind);
                    }
                    if (i < 9 && array[kind + 1] != 0)
                    {
                        IncreaseTatsuFirst(kind);
                        Run(kind + 1);
                        DecreaseTatsuFirst(kind);
                    }
                    DecreasePair(kind);
                    break;

                default:
                    break;
            }
        }

        void UpdateResult()
        {
            var retShanten = 8 - meldsCount * 2 - tatsuCount - pairsCount;
            var nMentsuKouho = meldsCount + tatsuCount;
            if (pairsCount != 0)
            {
                nMentsuKouho += pairsCount - 1;
            }
            else if (honorBits != 0 && isolatedBits != 0)
            {
                if ((honorBits | isolatedBits) == honorBits)
                {
                    retShanten++;
                }
            }
            if (nMentsuKouho > 4)
            {
                retShanten += nMentsuKouho - 4;
            }
            if (retShanten != -1 && retShanten < jidahaiCount)
            {
                retShanten = jidahaiCount;
            }
            if (retShanten < shanten)
            {
                shanten = retShanten;
            }
        }

        void IncreaseSet(TileKind k)
        {
            array[k] -= 3;
            meldsCount++;
        }

        void DecreaseSet(TileKind k)
        {
            array[k] += 3;
            meldsCount--;
        }

        void IncreasePair(TileKind k)
        {
            array[k] -= 2;
            pairsCount++;
        }

        void DecreasePair(TileKind k)
        {
            array[k] += 2;
            pairsCount--;
        }

        void IncreaseSyuntsu(TileKind k)
        {
            array[k]--;
            array[k + 1]--;
            array[k + 2]--;
            meldsCount++;
        }

        void DecreaseSyuntsu(TileKind k)
        {
            array[k]++;
            array[k + 1]++;
            array[k + 2]++;
            meldsCount--;
        }

        void IncreaseTatsuFirst(TileKind k)
        {
            array[k]--;
            array[k + 1]--;
            tatsuCount++;
        }

        void DecreaseTatsuFirst(TileKind k)
        {
            array[k]++;
            array[k + 1]++;
            tatsuCount--;
        }

        void IncreaseTatsuSecond(TileKind k)
        {
            array[k]--;
            array[k + 2]--;
            tatsuCount++;
        }

        void DecreaseTatsuSecond(TileKind k)
        {
            array[k]++;
            array[k + 2]++;
            tatsuCount--;
        }

        void IncreaseIsolatedTile(TileKind k)
        {
            array[k]--;
            isolatedBits |= 1 << (int)k;
        }

        void DecreaseIsolatedTile(TileKind k)
        {
            array[k]++;
            isolatedBits |= 1 << (int)k;
        }
    }
}