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

        KeyboardState oldKey;

        Rectangle left, right;

        ScoringSystem score;

        int beginTimer;
        bool play, gameOver;

        public static bool TEST;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 900;
            graphics.PreferredBackBufferHeight = 900;
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
            backgroundRect = new Rectangle(50, 95, 800, 800);

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
                new Rectangle(262, 552, 117, 30), // 30
                new Rectangle(519, 553, 118, 30),
                new Rectangle(692, 553, 86, 28),
                new Rectangle(692, 553, 30, 107),
                new Rectangle(120, 708, 259, 28),
                new Rectangle(262, 631, 32, 77), // 35
                new Rectangle(346, 631, 205, 30),
                new Rectangle(432, 631, 35, 105),
                new Rectangle(519, 708, 259, 28),
                new Rectangle(605, 631, 31, 79),
                new Rectangle(692, 166, 89, 29), // 40
                new Rectangle(348, 321, 74, 13),
                new Rectangle(422, 321, 56, 13),
                new Rectangle(478, 321, 74, 13),
                new Rectangle(534, 321, 18, 105),
                new Rectangle(347, 411, 205, 16), // 45
                new Rectangle(347, 322, 18, 89)
            };

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
                collisions[i].Y += backgroundRect.Y;
            }

            left = new Rectangle(0, 0, 50, graphics.PreferredBackBufferHeight);
            right = new Rectangle(graphics.PreferredBackBufferWidth - 50, 0, 50,
                graphics.PreferredBackBufferHeight);

            TEST = false;
            oldKey = Keyboard.GetState();

            score = new ScoringSystem(new Vector2(350, 20), null, Color.White);

            beginTimer = 240;
            play = false;
            gameOver = false;
            
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
            testPixel = this.Content.Load<Texture2D>("pixel");
            font = this.Content.Load<SpriteFont>("SpriteFont1");

            SoundSystem.LoadSounds(this.Content);
            SoundSystem.Begin.Play();

            score.LoadFont(font);
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

            if(gameOver)
            {
                base.Update(gameTime);
            }

            if(!play)
            {
                beginTimer--;

                if(beginTimer <= 0)
                {
                    play = true;
                    
                }

                pacMan = new PacMan(new Rectangle(432, 520, 38, 38), spriteSheet,
                collisions, left, right);

                base.Update(gameTime);
            }

            if(mouse.LeftButton == ButtonState.Pressed &&
                oldMouse.LeftButton != ButtonState.Pressed)
            {
                Console.WriteLine(mouse.X + " " + mouse.Y);
            }

            if(key.IsKeyDown(Keys.X) && !oldKey.IsKeyDown(Keys.X))
            {
                TEST = !TEST;
            }

            if(key.IsKeyDown(Keys.M) && !oldKey.IsKeyDown(Keys.M))
            {
                gameOver = pacMan.Kill();
                Console.WriteLine(gameOver);
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
            
            if(TEST)
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

            if (gameOver)
            {
                Vector2 measure = font.MeasureString("GAME OVER!");

                spriteBatch.DrawString(font, "GAME OVER!", new Vector2(450 - measure.X / 2, 525),
                    Color.DarkRed);
                
            }
            else if (play)
            {
                pacMan.Draw(gameTime, spriteBatch);
                score.Draw(spriteBatch);
            }
            else
            {
                Vector2 measure = font.MeasureString("READY!");

                spriteBatch.DrawString(font, "READY!", new Vector2(450 - measure.X / 2, 525),
                    Color.Yellow);
            }

            spriteBatch.Draw(testPixel, left, Color.Black);
            spriteBatch.Draw(testPixel, right, Color.Black);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
