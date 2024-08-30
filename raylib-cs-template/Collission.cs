using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace raylib_cs_template
{
    internal class Collission
    {

        public Collission(Rectangle platform, Rectangle player)
        {
            collided(platform, player);

        }
        public bool collided(Rectangle platform, Rectangle player)
        {
            if ((player.Position.Y + 80) == (platform.Position.Y + 80))
            {
                return true;
            }
            else
            {
                return false;
            }
            return false;
        }
    }
}
