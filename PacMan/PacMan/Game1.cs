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
        Texture2D spriteSheet, background, testPixel;

        Rectangle backgroundRect;

        PacMan pacMan;

        Rectangle[] collisions;

        MouseState oldMouse;

        SpriteFont font;

        bool test;

        KeyboardState oldKey;

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

            this.IsMouseVisible = true;

            oldMouse = Mouse.GetState();

            collisions = new Rectangle[]
            {
                new Rectangle(50, 0, 14, 246), // 0
                new Rectangle(0, 242, 208, 106),
                new Rectangle(0, 397, 208, 107),
                new Rectangle(50, 489, 15, 311),
                new Rectangle(50, 0, 800, 12),
                new Rectangle(433, 0, 33, 118), // 5
                new Rectangle(835, 0, 14, 256),
                new Rectangle(692, 244, 900 - 692, 104),
                new Rectangle(692, 398, 900 - 692, 107),
                new Rectangle(835, 488, 15, 311),
                new Rectangle(50, 784, 800, 16), // 10
                new Rectangle(119, 62, 89, 56),
                new Rectangle(261, 62, 118, 56),
                new Rectangle(520, 62, 116, 56),
                new Rectangle(692, 62, 89, 56),
                new Rectangle(119, 165, 89, 30), // 15
                new Rectangle(262, 166, 31, 182),
                new Rectangle(290, 242, 91, 31),
                new Rectangle(348, 166, 204, 29),
                new Rectangle(433, 188, 33, 85),
                new Rectangle(605, 166, 33, 182), // 20
                new Rectangle(520, 242, 91, 31),
                new Rectangle(261, 397, 32, 107),
                new Rectangle(606, 398, 32, 106),
                new Rectangle(431, 474, 35, 107),
                new Rectangle(347, 474, 204, 30), // 25
                new Rectangle(776, 630, 73, 31),
                new Rectangle(50, 630, 72, 30),
                new Rectangle(120, 552, 86, 31),
                new Rectangle(178, 581, 28, 78),
                new Rectangle(263, 552, 116, 30), // 30
                new Rectangle(519, 553, 118, 30),
                new Rectangle(692, 553, 86, 28),
                new Rectangle(692, 553, 30, 107),
                new Rectangle(120, 708, 259, 28),
                new Rectangle(263, 631, 31, 77), // 35
                new Rectangle(346, 631, 205, 30),
                new Rectangle(432, 631, 35, 105),
                new Rectangle(519, 708, 259, 28),
                new Rectangle(605, 631, 31, 79),
                new Rectangle(692, 166, 87, 29), // 40
                new Rectangle(348, 321, 74, 13),
                new Rectangle(422, 321, 56, 13),
                new Rectangle(478, 321, 74, 13),
                new Rectangle(534, 321, 18, 105),
                new Rectangle(347, 411, 205, 16), // 45
                new Rectangle(347, 322, 18, 89)
            };

            test = false;
            oldKey = Keyboard.GetState();

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
            testPixel = this.Content.Load<Texture2D>("pixel");
            font = this.Content.Load<SpriteFont>("SpriteFont1");

            pacMan = new PacMan(new Rectangle(450, 427, 46, 46), testPixel, 
                collisions);
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
            KeyboardState key = Keyboard.GetState();

            if(mouse.LeftButton == ButtonState.Pressed &&
                oldMouse.LeftButton != ButtonState.Pressed)
            {
                Console.WriteLine(mouse.X + " " + mouse.Y);
            }

            if(key.IsKeyDown(Keys.X) && !oldKey.IsKeyDown(Keys.X))
            {
                test = !test;
            }

            pacMan.Update(gameTime, key, oldKey);

            oldMouse = mouse;
            oldKey = key;

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
            
            if(test)
            {
                for (int i = 0; i < collisions.Length; i++)
                {
                    Rectangle r = collisions[i];

                    spriteBatch.Draw(testPixel, r, Color.White);

                    Vector2 measure = font.MeasureString(i + "");
                    measure = new Vector2(r.Center.X - measure.X / 2, r.Center.Y - measure.Y / 2);
                    spriteBatch.DrawString(font, i + "", measure, Color.LightGreen);
                }
            }

            pacMan.Draw(gameTime, spriteBatch);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
