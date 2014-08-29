using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;

namespace MemoryBlock
{
    public class TileSet
    {
        public Dictionary<TextureIndex, Texture2D> texture;

        public TileSet()
        {
            texture = new Dictionary<TextureIndex, Texture2D>();
        }
    }
}
