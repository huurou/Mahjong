using static Mahjong.Domain.Models.Tiles.TileKind;

namespace Mahjong.Domain.Models.Tiles
{
    public class Tile : ValueObject<Tile>
    {
        public static Tile FIVE_RED_MAN => new(16);
        public static Tile FIVE_RED_PIN => new(52);
        public static Tile FIVE_RED_SOU => new(88);

        public TileId Id { get; }
        public TileKind Kind => Id.Value is >= 0 and <= 135
            ? (TileKind)(Id.Value / 4 + 1)
            : None;

        public Tile(int id)
            : this(new TileId(id)) { }

        public Tile(TileId id)
        {
            Id = id;
        }

        public static Tile Parse(string man = "", string pin = "", string sou = "",
            string honors = "", bool hasAkaDora = false)
        {
            return TileList.Parse(man, pin, sou, honors, hasAkaDora)[0];
        }

        public override bool Equals(ValueObject<Tile>? other)
        {
            return other is Tile tile && Id == tile.Id;
        }

        public override int GetHashCodeCore()
        {
            return new { Id }.GetHashCode();
        }

        public string ToOneLineString(bool printAkaDora = false)
        {
            return printAkaDora && Id == FIVE_RED_MAN.Id ? "[五]"
                : printAkaDora && Id == FIVE_RED_PIN.Id ? "[⑤]"
                : printAkaDora && Id == FIVE_RED_SOU.Id ? "[５]"
                : ToString();
        }

        public override string ToString()
        {
            return Kind switch
            {
                Man1 => "一",
                Man2 => "二",
                Man3 => "三",
                Man4 => "四",
                Man5 => "五",
                Man6 => "六",
                Man7 => "七",
                Man8 => "八",
                Man9 => "九",
                Pin1 => "①",
                Pin2 => "②",
                Pin3 => "③",
                Pin4 => "④",
                Pin5 => "⑤",
                Pin6 => "⑥",
                Pin7 => "⑦",
                Pin8 => "⑧",
                Pin9 => "⑨",
                Sou1 => "１",
                Sou2 => "２",
                Sou3 => "３",
                Sou4 => "４",
                Sou5 => "５",
                Sou6 => "６",
                Sou7 => "７",
                Sou8 => "８",
                Sou9 => "９",
                East => "東",
                South => "南",
                West => "西",
                North => "北",
                Haku => "白",
                Hatsu => "發",
                Chun => "中",
                None or _ => "-",
            };
        }
    }
}