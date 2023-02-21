
using System;
using System.Numerics;
using static System.Console;
namespace BoardGame
{
    public class Game : IGame
    {
        const int TOTAL_TREASURE_COUNT = 5;
        private readonly IBoard _board;
        private readonly IPlayer _player1;
        private readonly IPlayer _player2;

        public Game(IBoard board, IPlayer player1, IPlayer player2)
        {
            _board = board ?? throw new ArgumentNullException(nameof(board));
            _player1 = player1 ?? throw new ArgumentNullException(nameof(player1));
            _player2 = player2 ?? throw new ArgumentNullException(nameof(player2));
        }

        public void StartGame()
        {
            _board.InitialiseBoard();
            PositionPlayers();
            PlaceHiddenTreasure();
            WriteLine("Enter Player1's name");
            _player1.Name = ReadLine();
            WriteLine("Enter Player2's name");
            _player2.Name = ReadLine();
            NextTurn(_player1);
        }

        private void NextTurn(IPlayer player)
        {

            if (!Move(player))
                WriteLine($"{(player == _player1 ? _player2 : _player1)} wins!");
            else if (player.TreasureInventory.Count == 3)
            {
                WriteLine($"{player.Name} wins!");
            }
            else
            {
                NextTurn(player == _player1 ? _player2 : _player1);
            }
        }

        private bool Move(IPlayer player)
        {
            WriteLine($"{player.Name}'s turn");
            WriteLine("Press c to rotate 90 degrees clockwise");
            WriteLine("Press a to rotate 90 degrees anti-clockwise");
            WriteLine("Press f to move forward");
            WriteLine("Press t to lay a trap");
            var keyPressed = ReadKey();
            switch (keyPressed.Key.ToString().ToLower())
            {
                case "c":
                    TurnClockwise(player);
                    break;
                case "a":
                    TurnAntiClockwise(player);
                    break;
                case "t":
                    LayTrap(player);
                    break;
                case "f":
                    if (!MoveForward(player))
                        return false;
                    break;
                default:
                    {
                        WriteLine("Invalid key entered");
                        Move(player);
                        break;
                    }
            }
            return true;

        }

        private bool MoveForward(IPlayer player)
        {
            if (!_board.MovePlayer(player))
                WriteLine("Connot move player to new square");
            else
            {
                var square = _board.GetPlayerSquare(player);
                if (square.containsTrap)
                    return false;
            }

            return true;
            
        }

        private void LayTrap(IPlayer player)
        {
            player.LayTrap(_board);
        }

        private void TurnAntiClockwise(IPlayer player)
        {
            switch (player.Facing)
            {
                case Facing.North:
                    player.Facing = Facing.West;
                    break;
                case Facing.East:
                    player.Facing = Facing.North;
                    break;
                case Facing.South:
                    player.Facing = Facing.East;
                    break;
                case Facing.West:
                    player.Facing = Facing.South;
                    break;
                default:
                    player.Facing = Facing.North;
                    break;
            }
        }

        private void TurnClockwise(IPlayer player)
        {
            switch (player.Facing)
            {
                case Facing.North:
                    player.Facing = Facing.East;
                    break;
                case Facing.East:
                    player.Facing = Facing.South;
                    break;
                case Facing.South:
                    player.Facing = Facing.West;
                    break;
                case Facing.West:
                    player.Facing = Facing.North;
                    break;
                default:
                    player.Facing = Facing.North;
                    break;
            }
        }

        private void PlaceHiddenTreasure()
        {
            for (int i=0; i< TOTAL_TREASURE_COUNT; i++)
            {
                var square = GetRandonSquare();
                while(square.containsTreasure || square.Player != null)
                {
                    square = GetRandonSquare();
                }
                square.containsTreasure = true;
            }
        }

        private void PositionPlayers()
        {
            var square = GetRandonSquare();
            square.Player = _player1;
            
            while (square.Player != null)
            {
                square = GetRandonSquare();
            }
            square.Player = _player2;

        }

        private Square GetRandonSquare()
        {
            Random randon = new Random();

            int x = randon.Next(0, 4);
            int y = randon.Next(0, 4);

            return _board.GetSquare(x, y);            
        }
    }
}
