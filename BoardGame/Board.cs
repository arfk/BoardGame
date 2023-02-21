using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{

    
    public class Board : IBoard
    {
        const int MAX_X_AXIS = 5;
        const int MAX_Y_AXIS = 5;

        private Square[,] _board;

        public void InitialiseBoard()
        {
            _board = new Square[MAX_X_AXIS, MAX_Y_AXIS];
            for (int i=0; i<MAX_X_AXIS; i++)
            {
                for(int j=0; j<MAX_Y_AXIS; j++)
                {
                    _board[i, j] = new Square(i, j);
                }
            }
        }

        public bool MovePlayer(IPlayer player)
        {
            var square = GetPlayerSquare(player);
            
            
            int x = square.X;
            int y = square.Y;
            int newX = 0;
            int newY = 0;

            if (player.Facing == Facing.North)
            {
                if (y > 0)
                {
                    newX = square.X;
                    newY = square.Y - 1;
                }
                else
                    return false;
            }
            else if (player.Facing == Facing.East)
            {
                if (x < 4)
                {
                    newX = square.X + 1;
                    newY = square.Y;
                }
                else
                    return false;
            }
            else if (player.Facing == Facing.South)
            {
                if (y < 4)
                {
                    newX = square.X;
                    newY = square.Y+ 1;
                }
                else
                    return false;
            }
            else if (player.Facing == Facing.South)
            {
                if (y < 4)
                {
                    newX = square.X;
                    newY = square.Y + 1;
                }
                else
                    return false;
            }
            else if (player.Facing == Facing.West)
            {
                if (x > 0)
                {
                    newX = square.X -1;
                    newY = square.Y;
                }
                else
                    return false;
            }


            if (_board[newX, newY].containsTreasure)
                player.TreasureInventory.Add(new Treasure());
            _board[x,y].Player = null;
            _board[newX, newY].Player = player;



            return true;
        }

        public Square GetPlayerSquare(IPlayer player)
        {
            for (int i = 0; i < MAX_X_AXIS; i++)
            {
                for (int j = 0; j < MAX_Y_AXIS; j++)
                {
                    if (_board[i, j].Player == player)
                    {
                        return _board[i, j];
                    }
                }
            }
            return null;
        }

        public Square GetSquare(int x, int y)
        {
            return _board[x, y];
        }

    }
}
