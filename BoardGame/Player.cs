using static System.Console;

namespace BoardGame
{

    public enum Facing {
        North,
        South,
        East,
        West
    }
    public class Player : IPlayer
    {
        private List<Treasure> _treasureInventory;
        private int _LaidTrapCount;

        public string Name { get; set; }
        public Facing Facing { get; set; }

        private int LaidTrapCount { get { return _LaidTrapCount; } }

        public Player()
        {
            _treasureInventory = new List<Treasure>();
            _LaidTrapCount = 0;
        }
        public List<Treasure> TreasureInventory 
        {  
            get { return _treasureInventory; }
        } 

        public void LayTrap(IBoard board)
        {
            if (_LaidTrapCount <= 3)
            {
                _LaidTrapCount++;
                if (!board.GetPlayerSquare(this).containsTrap &&
                    !board.GetPlayerSquare(this).containsTreasure)
                    board.GetPlayerSquare(this).containsTrap = true;
                else
                    WriteLine("Cannot lay trap here");

            }
            else
            {
                WriteLine("Max number of traps laid already");
            }
        }
    }
}
