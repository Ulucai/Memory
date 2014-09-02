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
        Tuple<int, int> VisibleCellOne, VisibleCellTwo;


        public Map()
        {

        }

        public Map(int rows, int cols, Vector2 mapPosition)
        {
            VisibleCellOne = VisibleCellTwo = Tuple.Create(-1, -1);
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

                    //grid.Add(new Tuple<int, int>(j, i), 
                    grid.Add(Tuple.Create(j, i), 
                             new Cell(size, 
                                      size, 
                                      new Vector2(position.X + (j*size), position.Y + (i * size)), 
                                      //TextureIndex.Black));
                                      RandomIndex));
                }
            }
        }

        public Tuple<int, int, bool> CheckCellUnderClick(Point p )
        {
            int row, col;            
            col = row = -1;            
            
            for (int i = 0; i < nRows; i++)
            {

                if (grid[Tuple.Create(0, i)].Bounds.Bottom >= p.Y && grid[Tuple.Create(0, i)].Bounds.Top <= p.Y)
                {
                    
                    for (int j = 0; j < nCols; j++)
                    {
                        if (grid[Tuple.Create(j, i)].Bounds.Right >= p.X && grid[Tuple.Create(j, i)].Bounds.Left <= p.X)
                        {                            
                            row = j;
                            col = i;
                            return Tuple.Create(row, col, true);   
                        }
                    }
                    return Tuple.Create(row, col, false);
                }
            }
            return Tuple.Create(row, col, false);
        }

        public void ChangeTileColor(int row, int col)
        {
            grid[Tuple.Create(row, col)].NextTileTexture();
        }

        public void ShowCell(int row, int col)
        {
            if (VisibleCellOne.Item1.Equals(-1))
            {
                grid[Tuple.Create(row, col)].isVisible = true;
                VisibleCellOne = Tuple.Create(row, col);
            }
            else if (!VisibleCellOne.Equals(Tuple.Create(row, col))  && 
                (VisibleCellTwo.Item1.Equals(-1) ))
            {
                grid[Tuple.Create(row, col)].isVisible = true;
                VisibleCellTwo = Tuple.Create(row, col);
            }
            else if (!VisibleCellTwo.Item1.Equals(-1))
            {
                // TODO: Colocar esta parte em outro Metodo e chama-lo no Update por Delay ou por Input               
                if (grid[VisibleCellOne].tile.Equals(grid[VisibleCellTwo].tile))
                {
                    grid[VisibleCellOne].tile = grid[VisibleCellTwo].tile = TextureIndex.Empty;
                }
                else
                {
                    grid[VisibleCellOne].isVisible = false;
                    grid[VisibleCellTwo].isVisible = false;                    
                }
                VisibleCellOne = VisibleCellTwo = Tuple.Create(-1, -1);                
            }            

        }

        public void DestroyTile(int row, int col)
        {
            //grid.Remove(Tuple.Create(row, col));
            grid[Tuple.Create(row, col)].tile = TextureIndex.Empty;
        }

        public void RandomizeTiles()
        {
            TextureIndex[] tex = new TextureIndex[grid.Count];
            int ind = 0;
            TextureIndex[] excluded = { TextureIndex.Black, TextureIndex.Empty, TextureIndex.White };            
            foreach (TextureIndex item in tiles.texture.Keys.Except(excluded))
            {
                tex[ind] = item;
                tex[ind+6] = item;
                ind++;
            }
            
            ind = 0;
            tex = RandomTextureIndexTool.RandomizeStrings(tex);

            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nCols; j++)
                {
                    grid[Tuple.Create(j, i)].tile = tex[ind];
                    ind++;
                }                
            }
        }


        public void Draw(SpriteBatch sp)
        {
            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nCols; j++)
                {
                    

                    Cell c = grid[Tuple.Create(j,i)];
                    if (c.isVisible)
                    {
                        sp.Draw(tiles.texture[c.tile], c.position, Color.White);
                    }
                    else
                    {
                        sp.Draw(tiles.texture[TextureIndex.Black], c.position, Color.White);
                    }                                            
                }
            }
        }


    }
}
