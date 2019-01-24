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
                pelletArray[i] = new Pellet(new Rectangle(83 + 27 * i, 30, 7, 7), true);
            }
            for (i = 13; i < 26; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(490 + 27 * (i - 13), 30, 7, 7), true);
            }
            if (i == 26)
            {
                pelletArray[i] = new Pellet(new Rectangle(80, 55, 18, 18), false);
            }
            for (i = 27; i < 33; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(85, 90 + 27 * (i - 27), 7, 7), true);
            }
            for (i = 33; i < 36; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(407, 84 + 27 * (i - 34), 7, 7), true);
            }
            for (i = 36; i < 39; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(490, 84 + 27 * (i - 37), 7, 7), true);
            }
            for (i = 39; i < 42; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(660, 84 + 27 * (i - 40), 7, 7), true);
            }
            for (i = 42; i < 49; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(814, 84 + 27 * (i - 43), 7, 7), true);
            }
            for (i = 49; i < 52; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(230, 84 + 27 * (i - 50), 7, 7), true);
            }
            for (i = 52; i < 78; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(147 + 27 * (i - 53), 138, 7, 7), true);
            }
            for (i = 78; i < 99; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(230, 160 + 27 * (i - 78), 7, 7), true);
            }
            for (i = 99; i < 120; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(660, 160 + 27 * (i - 99), 7, 7), true);
            }
            for (i = 120; i < 124; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(120 + 27 * (i - 120), 225, 7, 7), true);
            }
            for (i = 124; i < 128; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(700 + 27 * (i - 124), 220, 7, 7), true);
            }
            for (i = 128; i < 132; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(320 + 27 * (i - 128), 220, 7, 7), true);
            }
            for (i = 132; i < 136; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(490 + 27 * (i - 132), 220, 7, 7), true);
            }
            for (i = 136; i < 138; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(320, 165 + 27 * (i - 136), 7, 7), true);
            }
            for (i = 138; i < 140; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(570, 165 + 27 * (i - 138), 7, 7), true);
            }
            for (i = 140; i < 145; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(84 + 27 * (i - 140), 524, 7, 7), true);
            }
            for (i = 145; i < 151; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(260 + 27 * (i - 145), 524, 7, 7), true);
            }
            for (i = 151; i < 157; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(485 + 27 * (i - 151), 524, 7, 7), true);
            }
            for (i = 157; i < 162; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(700 + 27 * (i - 157), 524, 7, 7), true);
            }
            for (i = 162; i < 167; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(485 + 27 * (i - 162), 685, 7, 7), true);
            }
            for (i = 167; i < 172; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(700 + 27 * (i - 167), 685, 7, 7), true);
            }
            for (i = 172; i < 177; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(84 + 27 * (i - 172), 685, 7, 7), true);
            }
            for (i = 177; i < 182; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(305 + 27 * (i - 177), 685, 7, 7), true);
            }
            for (i = 182; i < 188; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(260 + 27 * (i - 182), 600, 7, 7), true);
            }
            for (i = 188; i < 194; i++)
            {
                pelletArray[i] = new Pellet(new Rectangle(490 + 27 * (i - 188), 600, 7, 7), true);
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

            Texture2D pelletText = this.Content.Load<Texture2D>("white");

            foreach(Pellet p in pelletArray)
            {
                if (p == null)
                {
                    continue;
                }

                p.LoadTexture(pelletText);
            }
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
            for (i = 0; i < 194; i++)
            {
                spriteBatch.Draw(pelletArray[i].PelletText, pelletArray[i].PelletRect, Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
