using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MemoryBlock
{
    public class Map
    {
        /// <summary>
        /// [Rows, Cols]
        /// </summary>
        Dictionary<Tuple<int, int>, Cell> grid;
        Vector2 position;
        int nRows, nCols;
        public TileSet tiles;
        int size; // vai funcionar apenas com quadrados.

        public Map()
        {

        }

        public Map( int rows, int cols, Vector2 mapPosition)
        {
            grid = new Dictionary<Tuple<int, int>, Cell>();
            tiles = new TileSet();
            nRows = rows;
            nCols = cols;
            size = 47;
            position = mapPosition;

            TextureIndex RandomIndex;
            Random r = new Random();

            for (int i = 0; i < nRows; i++)
            {
                
                for (int j = 0; j < nCols; j++)
                {                    
                    if (r.Next(2) == 1)
                    {
                        RandomIndex = TextureIndex.White;
                    }
                    else
                    {
                        RandomIndex = TextureIndex.Black;
                    }

                    grid.Add(new Tuple<int, int>(j, i), 
                             new Cell(size, 
                                      size, 
                                      new Vector2(position.X + (j*size), position.Y + (i * size)), 
                                      //TextureIndex.Black));
                                      RandomIndex));


                }
            }
        }


        public void RandomizeTiles()
        {            
        }


        public void Draw(SpriteBatch sp)
        {
            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nCols; j++)
                {
                    // TODO: find a better alternative for Dictionary + Tuple
                    Cell c = grid[new Tuple<int,int>(j,i)];
                    sp.Draw(tiles.texture[c.tile], c.position, Color.White);                    
                }
            }
        }


    }
}
