

namespace ConsoleApp1
{
    public struct Cell
    {
        public byte X;
        public byte Y;

        public Cell(byte x, byte y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Cell a, Cell b) => a.X == b.X && a.Y == b.Y;
        public static bool operator !=(Cell a, Cell b) => a.X != b.X || a.Y != b.Y;

        public override bool Equals(object o) => false;

        public override int GetHashCode() => 0;
    }
}
