using Mahjong.Domain.Models.Tiles;
using static Mahjong.Domain.Models.Tiles.TileKind;
using static Xunit.Assert;

namespace Mahjong.Test
{
    public class IsolatedTest
    {
        [Fact]
        public void FindIsolatedKindListTest()
        {
            var hand = TileList.Parse(man: "25", pin: "15678", sou: "1369", honors: "124");
            var isoKinds = hand.FindIsolatedKindList();
            DoesNotContain(Man1, isoKinds);
            DoesNotContain(Man2, isoKinds);
            DoesNotContain(Man3, isoKinds);
            DoesNotContain(Man4, isoKinds);
            DoesNotContain(Man5, isoKinds);
            DoesNotContain(Man6, isoKinds);
            Contains(Man7, isoKinds);
            Contains(Man8, isoKinds);
            Contains(Man9, isoKinds);
            DoesNotContain(Pin1, isoKinds);
            DoesNotContain(Pin2, isoKinds);
            Contains(Pin3, isoKinds);
            DoesNotContain(Pin4, isoKinds);
            DoesNotContain(Pin5, isoKinds);
            DoesNotContain(Pin6, isoKinds);
            DoesNotContain(Pin7, isoKinds);
            DoesNotContain(Pin8, isoKinds);
            DoesNotContain(Pin9, isoKinds);
            DoesNotContain(Sou1, isoKinds);
            DoesNotContain(Sou2, isoKinds);
            DoesNotContain(Sou3, isoKinds);
            DoesNotContain(Sou4, isoKinds);
            DoesNotContain(Sou5, isoKinds);
            DoesNotContain(Sou6, isoKinds);
            DoesNotContain(Sou7, isoKinds);
            DoesNotContain(Sou8, isoKinds);
            DoesNotContain(Sou9, isoKinds);
            DoesNotContain(East, isoKinds);
            DoesNotContain(South, isoKinds);
            Contains(West, isoKinds);
            DoesNotContain(North, isoKinds);
            Contains(Haku, isoKinds);
            Contains(Hatsu, isoKinds);
            Contains(Chun, isoKinds);
        }
    }
}