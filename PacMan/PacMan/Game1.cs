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

        Rectangle[] Rectangles;
        Rectangle[] Origin;
        Rectangle backgroundRect;

        Rectangle[] collisions;

        MouseState oldMouse;

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

            Rectangles = new Rectangle[]
            {

            };

            this.IsMouseVisible = true;

            oldMouse = Mouse.GetState();

            collisions = new Rectangle[]
            {
                new Rectangle(50, 0, 14, 246),
                new Rectangle(50, 242, 156, 106),
                new Rectangle(0, 397, 206, 107),
                new Rectangle(50, 489, 15, 311),
                new Rectangle(50, 0, 800, 12),
                new Rectangle(433, 0, 32, 112),
                new Rectangle(835, 0, 14, 256),
                new Rectangle(692, 244, 158, 104),
                new Rectangle(693, 397, 157, 107),
                new Rectangle(835, 488, 15, 311),
                new Rectangle(50, 784, 800, 16),
                new Rectangle(119, 62, 87, 56),
                new Rectangle(261, 62, 118, 56),
                new Rectangle(520, 62, 116, 56),
                new Rectangle(692, 62, 89, 56),
                new Rectangle(20, 165, 186, 30),
                new Rectangle(282, 165, 12, 182),
                new Rectangle(290, 240, 89, 30),
                new Rectangle(348, 166, 204, 29),
                new Rectangle(433, 188, 33, 82),
                new Rectangle(605, 166, 33, 182),
                new Rectangle(520, 244, 117, 30),
                new Rectangle(347, 321, 206, 106),
                new Rectangle(261, 398, 32, 106),
                new Rectangle(431, 474, 35, 107),
                new Rectangle(347, 474, 204, 30),
                new Rectangle(776, 630, 73, 32),
                new Rectangle(50, 630, 72, 30),
                new Rectangle(120, 552, 86, 31),
                new Rectangle(178, 581, 28, 78),
                new Rectangle(263, 552, 116, 30),
                new Rectangle(519, 554, 116, 28),
                new Rectangle(692, 553, 86, 28),
                new Rectangle(692, 553, 30, 106),
                new Rectangle(120, 708, 259, 28),
                new Rectangle(262, 631, 30, 77),
                new Rectangle(346, 631, 205, 30),
                new Rectangle(432, 631, 35, 105),
                new Rectangle(519, 708, 259, 28),
                new Rectangle(605, 631, 31, 79)
            };

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
            MouseState mouse = Mouse.GetState();

            if(mouse.LeftButton == ButtonState.Pressed &&
                oldMouse.LeftButton != ButtonState.Pressed)
            {
                Console.WriteLine(mouse.X + " " + mouse.Y);
            }

            oldMouse = mouse;

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
            

            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
