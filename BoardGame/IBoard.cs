using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    public interface IBoard 
    {
        void InitialiseBoard();
        Square GetSquare(int x, int y);

        Square GetPlayerSquare(IPlayer player);
        bool MovePlayer(IPlayer player);
    }
}
