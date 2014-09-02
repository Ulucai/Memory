#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
//using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace MemoryBlock
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Map gMap;
        



        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            
            graphics.PreferredBackBufferHeight = 726;
            graphics.PreferredBackBufferWidth = 1024;

            IsMouseVisible = true;

            Content.RootDirectory = "Content";
                        
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            
            gMap = new Map(3, 4, new Vector2(250, 150));

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);                        
           
           
            gMap.tiles.texture.Add(TextureIndex.Black, Content.Load<Texture2D>("blackBlock"));
            gMap.tiles.texture.Add(TextureIndex.White, Content.Load<Texture2D>("whiteBlock"));
            gMap.tiles.texture.Add(TextureIndex.Empty, Content.Load<Texture2D>("empty"));
            gMap.tiles.texture.Add(TextureIndex.RedArrowLeft, Content.Load<Texture2D>("redArrowLeft"));
            gMap.tiles.texture.Add(TextureIndex.RedArrowRight, Content.Load<Texture2D>("redArrowRight"));
            gMap.tiles.texture.Add(TextureIndex.RedBall, Content.Load<Texture2D>("redBall"));
            gMap.tiles.texture.Add(TextureIndex.RedHexagon, Content.Load<Texture2D>("redHexagon"));
            gMap.tiles.texture.Add(TextureIndex.RedSquare, Content.Load<Texture2D>("redSquare"));
            gMap.tiles.texture.Add(TextureIndex.RedStar, Content.Load<Texture2D>("redStar"));

            gMap.RandomizeTiles();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            


            

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.P))
                gMap.RandomizeTiles();
            Input.ClickCheck(gMap);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            

            spriteBatch.Begin();

            gMap.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
