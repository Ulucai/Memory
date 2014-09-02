using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MemoryBlock
{
    static class RandomTextureIndexTool // não usei ainda. Esquanta não VS, brow.
    {
        static Random _random = new Random();

        public static TextureIndex[] RandomizeStrings(TextureIndex[] TI)
        {
            List<KeyValuePair<int, TextureIndex>> list = new List<KeyValuePair<int, TextureIndex>>();
            // Add all strings from array
            // Add new random int each time
            foreach (TextureIndex s in TI)
            {
                list.Add(new KeyValuePair<int, TextureIndex>(_random.Next(), s));
            }
            // Sort the list by the random number
            var sorted = from item in list
                         orderby item.Key
                         select item;
            // Allocate new string array
            TextureIndex[] result = new TextureIndex[TI.Length];
            // Copy values to array
            int index = 0;
            foreach (KeyValuePair<int, TextureIndex> pair in sorted)
            {
                result[index] = pair.Value;
                index++;
            }
            // Return copied array
            return result;
        }
    }
}
