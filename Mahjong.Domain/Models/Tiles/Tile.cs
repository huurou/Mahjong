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

        public static Tile Parse(string man = "", string pin = "", string sou = "", string honor = "")
        {
            return TileList.Parse(man, pin, sou, honor)[0];
        }

        public override bool Equals(ValueObject<Tile>? other)
        {
            return other is Tile tile && Id == tile.Id;
        }

        public override int GetHashCodeCore()
        {
            return new { Id }.GetHashCode();
        }

        public string ToString(bool printAkaDora)
        {
            return Kind.ToString(printAkaDora);
        }

        public override string ToString()
        {
            return Kind.ToString(false);
        }
    }
}