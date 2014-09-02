using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Input;


namespace MemoryBlock
{
    public static class Input
    {
        static bool LeftMouseButtonPressed = false;
        static bool RightMouseButtonPressed = false;
        static MouseState ms;
        static KeyboardState ks;

        public static void ClickCheck(Map map)
        {

            ms = Mouse.GetState();
            switch (ms.LeftButton)
            {
                case ButtonState.Pressed:
                    if (!LeftMouseButtonPressed)
                    {
                        LeftMouseButtonPressed = true;
                        Tuple<int, int, bool> cellClicked = map.CheckCellUnderClick(ms.Position);
                        if (cellClicked.Item3)
                        {
                            map.ChangeTileColor(cellClicked.Item1, cellClicked.Item2);
                        }
                    }
                    break;
                case ButtonState.Released:
                    if (LeftMouseButtonPressed)
                    {
                        LeftMouseButtonPressed = false;
                    }
                    break;                
            }

            switch (ms.RightButton)
            {
                case ButtonState.Pressed:
                    if (!RightMouseButtonPressed)
                    {
                        RightMouseButtonPressed = true;
                        Tuple<int, int, bool> cellClicked = map.CheckCellUnderClick(ms.Position);
                        if (cellClicked.Item3)
                        {
                            map.DestroyTile(cellClicked.Item1, cellClicked.Item2);
                        }
                    }
                    break;
                case ButtonState.Released:
                    if (RightMouseButtonPressed)
                    {
                        RightMouseButtonPressed = false;
                    }
                    break;
            }            
        }

        public static void RandomizeColors(Map map)
        {
            ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.R))
            {
                map.RandomizeTiles();
            }
        }

    }
}
