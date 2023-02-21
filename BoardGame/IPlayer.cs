using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame
{
    public interface IPlayer
    {
        string Name { get; set; }
        Facing Facing { get; set; }

        List<Treasure> TreasureInventory { get; }

        void LayTrap(IBoard board);
    }
}
