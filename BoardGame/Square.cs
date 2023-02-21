

namespace BoardGame
{
    public class Square
    {
        private int _x;
        private int _y;
        public Square(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X { get { return _x; } }
        public int Y { get { return _y; } }

        public IPlayer Player { get; set; }

        public bool containsTrap { get; set; }

        public bool containsTreasure { get; set; }



    }
}
