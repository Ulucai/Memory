using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;


namespace MemoryBlock
{
    public class Cell
    {
        Rectangle bounds;
        public Vector2 position;
        public TextureIndex tile;

        public Cell(int width, int height, Vector2 cellPosition, TextureIndex texture)
        {
            tile = texture;
            position = cellPosition;
            bounds = new Rectangle((int)position.X, (int)position.Y, width, height);
        }

        public bool Intersects(Point p)
        {
            Rectangle click = new Rectangle(p.X, p.Y, 1, 1);
            if (click.Intersects(bounds))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
