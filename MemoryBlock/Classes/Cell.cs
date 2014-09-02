using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;


namespace MemoryBlock
{
    public class Cell
    {
        protected Rectangle bounds;
        public Vector2 position;
        public TextureIndex tile;
        public bool isVisible;

        public Cell(int width, int height, Vector2 cellPosition, TextureIndex texture)
        {
            tile = texture;
            position = cellPosition;
            bounds = new Rectangle((int)position.X, (int)position.Y, width, height);
            isVisible = false;
        }

        public void NextTileTexture()
        {
            if (!tile.Equals(TextureIndex.Empty))
            {
                if (tile.Equals(TextureIndex.White))
                {
                    tile = TextureIndex.Black;
                }
                else
                {
                    tile = TextureIndex.White;
                }                
            }            
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


        public Rectangle Bounds 
        {
            get{ return bounds; }
        }


    }
}
