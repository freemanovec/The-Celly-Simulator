﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Celly_Simulator
{
    public class World
    {
        private WorldArea[,] _matrix;
        public World(Vector2 scale)
        {
            _matrix = new WorldArea[(int)scale.x, (int)scale.y];
        }
    }
}
