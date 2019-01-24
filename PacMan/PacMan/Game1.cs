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

namespace PacMan//The Actual Workspace
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D spriteSheet, background, testPixel;

        Rectangle[] Rectangles;
        Rectangle[] Origin;
        Rectangle backgroundRect;

        Rectangle[] collisions;

        MouseState oldMouse;

        SpriteFont font;

        bool test;

        int timer;
        int directionPinky = 0;
        int directionBlinky = 0;
        int directionClyde = 0;
        int directionInky = 0;

        KeyboardState oldKey;

        struct SprtieStruct
        {
            public Texture2D texutre;
            public Vector2 position;
            public Rectangle source;
            public Color color;
            public float rotation;
            public Vector2 origin;
            public float scale;
            public SpriteEffects effect;
        }
        SprtieStruct Sprite;
        SprtieStruct Blinky;//Red

        Ghost Blinky2;
        Ghost Pinky;
        Ghost Clyde;
        Ghost Inky;

        Random rand = new Random();
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
            timer = 0;
            backgroundRect = new Rectangle(50, 0, 800, 800);

            Rectangles = new Rectangle[]
            {

            };

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
                new Rectangle(692, 166, 87, 29), // 40
                new Rectangle(348, 321, 74, 13),
                new Rectangle(422, 321, 56, 13),
                new Rectangle(478, 321, 74, 13),
                new Rectangle(534, 321, 18, 105),
                new Rectangle(347, 411, 205, 16), // 45
                new Rectangle(347, 322, 18, 89)
            };

            test = false;
            
            Blinky.position = new Vector2(0, 0);
            Blinky.source = new Rectangle(4, 65, 14, 14);
            Blinky.color = Color.White;
            Blinky.rotation = 0;
            Blinky.origin = new Vector2(0, 0);
            Blinky.scale = 2;
            Blinky.effect = SpriteEffects.None;
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
            Texture2D spriteSheet = this.Content.Load<Texture2D>("spritesheet");
            testPixel = this.Content.Load<Texture2D>("pixel");
            font = this.Content.Load<SpriteFont>("SpriteFont1");

            Blinky.texutre = spriteSheet;

            Blinky2 = new Ghost(spriteSheet, new Rectangle(4, 65, 16, 16), new Rectangle(128, 64, 16, 16), new Rectangle(160, 64, 16, 16), new Rectangle(128, 80, 16, 16), new Vector2(430, 270), Color.White);

            Pinky = new Ghost(spriteSheet, new Rectangle(3, 80, 16, 16), new Rectangle(128, 64, 16, 16), new Rectangle(160, 64, 16, 16), new Rectangle(128, 80, 16, 16), new Vector2(370, 350), Color.White);

            Clyde = new Ghost(spriteSheet, new Rectangle(4, 113, 16, 16), new Rectangle(128, 64, 16, 16), new Rectangle(160, 64, 16, 16), new Rectangle(128, 80, 16, 16), new Vector2(425, 350), Color.White);

            Inky = new Ghost(spriteSheet, new Rectangle(4, 97, 16, 16), new Rectangle(128, 64, 16, 16), new Rectangle(160, 64, 16, 16), new Rectangle(128, 80, 16, 16), new Vector2(480, 350), Color.White);
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
            timer++;
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

            oldMouse = mouse;
            oldKey = key;

            if (timer % 100 == 0)
            {
                switch (Pinky.State)
                {
                    case Ghost.States.NORMAL:
                        Pinky.State = Ghost.States.VUNERABLE;
                        break;
                    case Ghost.States.VUNERABLE:
                        Pinky.State = Ghost.States.EATEN;
                        break;
                    case Ghost.States.EATEN:
                        Pinky.State = Ghost.States.NORMAL;
                        break;
                }
                switch (Blinky2.State)
                {
                    case Ghost.States.NORMAL:
                        Blinky2.State = Ghost.States.VUNERABLE;
                        break;
                    case Ghost.States.VUNERABLE:
                        Blinky2.State = Ghost.States.EATEN;
                        break;
                    case Ghost.States.EATEN:
                        Blinky2.State = Ghost.States.NORMAL;
                        break;
                }
                switch (Inky.State)
                {
                    case Ghost.States.NORMAL:
                        Inky.State = Ghost.States.VUNERABLE;
                        break;
                    case Ghost.States.VUNERABLE:
                        Inky.State = Ghost.States.EATEN;
                        break;
                    case Ghost.States.EATEN:
                        Inky.State = Ghost.States.NORMAL;
                        break;
                }
                switch (Clyde.State)
                {
                    case Ghost.States.NORMAL:
                        Clyde.State = Ghost.States.VUNERABLE;
                        break;
                    case Ghost.States.VUNERABLE:
                        Clyde.State = Ghost.States.EATEN;
                        break;
                    case Ghost.States.EATEN:
                        Clyde.State = Ghost.States.NORMAL;
                        break;
                }
            }
            if (timer % 30 == 0)
            {
                switch (Pinky.Direction)
                {
                    case Ghost.Directions.RIGHT:
                        Pinky.Direction = Ghost.Directions.LEFT;
                        break;
                    case Ghost.Directions.LEFT:
                        Pinky.Direction = Ghost.Directions.UP;
                        break;
                    case Ghost.Directions.UP:
                        Pinky.Direction = Ghost.Directions.DOWN;
                        break;
                    case Ghost.Directions.DOWN:
                        Pinky.Direction = Ghost.Directions.RIGHT;
                        break;
                }
                switch (Blinky2.Direction)
                {
                    case Ghost.Directions.RIGHT:
                        Blinky2.Direction = Ghost.Directions.LEFT;
                        break;
                    case Ghost.Directions.LEFT:
                        Blinky2.Direction = Ghost.Directions.UP;
                        break;
                    case Ghost.Directions.UP:
                        Blinky2.Direction = Ghost.Directions.DOWN;
                        break;
                    case Ghost.Directions.DOWN:
                        Blinky2.Direction = Ghost.Directions.RIGHT;
                        break;
                }
                switch (Inky.Direction)
                {
                    case Ghost.Directions.RIGHT:
                        Inky.Direction = Ghost.Directions.LEFT;
                        break;
                    case Ghost.Directions.LEFT:
                        Inky.Direction = Ghost.Directions.UP;
                        break;
                    case Ghost.Directions.UP:
                        Inky.Direction = Ghost.Directions.DOWN;
                        break;
                    case Ghost.Directions.DOWN:
                        Inky.Direction = Ghost.Directions.RIGHT;
                        break;
                }
                switch (Clyde.Direction)
                {
                    case Ghost.Directions.RIGHT:
                        Clyde.Direction = Ghost.Directions.LEFT;
                        break;
                    case Ghost.Directions.LEFT:
                        Clyde.Direction = Ghost.Directions.UP;
                        break;
                    case Ghost.Directions.UP:
                        Clyde.Direction = Ghost.Directions.DOWN;
                        break;
                    case Ghost.Directions.DOWN:
                        Clyde.Direction = Ghost.Directions.RIGHT;
                        break;
                }
            }
            Vector2 PinkyX = Pinky.Position;
//            PinkyX.X++;
            Vector2 PinkyY = Pinky.Position;
//            PinkyY.Y++;
            if (rand.Next(1000) < 200)
            {
                PinkyX.X++;
                Pinky.Position = PinkyX;
            }
                        
            if (rand.Next(1000) > 201 && rand.Next(1000) < 400 )
            {
                PinkyX.X--;
                
            }
            if (rand.Next(1000) > 401 && rand.Next(1000) < 600)
            {
                PinkyY.Y++;
                Pinky.Position = PinkyY;
            }
            if (rand.Next(1000) > 601 && rand.Next(1000) < 800)
            {
                PinkyY.Y--;
                Pinky.Position = PinkyY;
            }
                
            if (rand.Next(1000) == 1000 )
            {
                PinkyX.X -= 0;
                PinkyY.Y -= 0;
                Pinky.Position = PinkyX;
                Pinky.Position = PinkyY;
            }
            Pinky.Update(timer);
            Blinky2.Update(timer);
            Inky.Update(timer);
            Clyde.Update(timer);
            Console.WriteLine("{PinkyX} let's check " + PinkyX);
            Console.WriteLine("{PinkyY} let's check " + PinkyY);
            Console.WriteLine("{Rand} let's check " + rand.Next(1000));
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
            

            if (test)
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
            Blinky2.Draw(spriteBatch);
            Pinky.Draw(spriteBatch);
            Clyde.Draw(spriteBatch);
            Inky.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
