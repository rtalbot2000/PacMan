using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PacMan
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D spriteSheet, background;
        Rectangle backgroundRect;
        Pellet[] pelletArray;
        int j, i;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 900;
            graphics.PreferredBackBufferHeight = 800;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = true;
            backgroundRect = new Rectangle(50, 0, 800, 800);

            pelletArray = new Pellet[243];

            for (i = 0; i < 13; i++)
            {
                pelletArray[i] = new Pellet(Content.Load<Texture2D>("white"), new Rectangle(83 + 27 * i, 30, 7, 7), true);
            }
            for (i = 13; i < 26; i++)
            {
                pelletArray[i] = new Pellet(Content.Load<Texture2D>("white"), new Rectangle(135 + 27 * i, 30, 7, 7), true);
            }
            if (i == 26)
            {
                pelletArray[i] = new Pellet(Content.Load<Texture2D>("spritesheet"), new Rectangle(80, 60, 20, 20), false);
            }
            for (i = 27; i < 34; i++)
            {
                pelletArray[i] = new Pellet(Content.Load<Texture2D>("white"), new Rectangle(83, -675 + 27 * i, 7, 7), true);
            }
            for (i = 34; i < 37; i++)
            {
                pelletArray[i] = new Pellet(Content.Load<Texture2D>("white"), new Rectangle(230, -860 + 27 * i, 7, 7), true);
            }
            for (i = 37; i < 40; i++)
            {
                pelletArray[i] = new Pellet(Content.Load<Texture2D>("white"), new Rectangle(407, -943 + 27 * i, 7, 7), true);
            }
            for (i = 40; i < 43; i++)
            {
                pelletArray[i] = new Pellet(Content.Load<Texture2D>("white"), new Rectangle(486, -1024 + 27 * i, 7, 7), true);
            }
            for (i = 43; i < 50; i++)
            {
                pelletArray[i] = new Pellet(Content.Load<Texture2D>("white"), new Rectangle(810, -1105 + 27 * i, 7, 7), true);
            }
            for (i = 50; i < 53; i++)
            {
                pelletArray[i] = new Pellet(Content.Load<Texture2D>("white"), new Rectangle(660, -1293 + 27 * i, 7, 7), true);
            }
            for (i = 53; i < 77; i++)
            {
                pelletArray[i] = new Pellet(Content.Load<Texture2D>("white"), new Rectangle(400 + 27 * i, 30, 7, 7), true);
            }
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

            // TODO: use this.Content to load your game content here
            background = this.Content.Load<Texture2D>("better");
            spriteSheet = this.Content.Load<Texture2D>("spritesheet");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here

            //for (i = 0; i < 13; i++)
            //{
            //    pelletArray[i].Update(gameTime);
            //}

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(background, backgroundRect, Color.White);
            for (i = 0; i < 77; i++)
            {
                spriteBatch.Draw(pelletArray[i].PelletText, pelletArray[i].PelletRect, Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
