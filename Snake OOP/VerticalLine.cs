﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_OOP
{
    class VerticalLine : Figure
    {

        public VerticalLine(int yTop, int yDown, int x, char sym)
        {
            plist = new List<Point>();
            for (int y = yTop; y <= yDown; y++)
            {
                Point p = new Point(x, y, sym);
                plist.Add(p);
            }
        }
    }
}
