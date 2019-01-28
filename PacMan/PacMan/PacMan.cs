using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacMan
{
    class PacMan
    {
        Direction dir;
        Rectangle rect, source, ahead, left, right;
        Texture2D text;
        Rectangle[] coll;
        int state, timer, lives;
        bool dead;

        SoundEffectInstance chomp; 

        public PacMan(Rectangle rect, Texture2D text, Rectangle[] collisions,
            Rectangle left, Rectangle right)
        {
            this.rect = rect;
            this.text = text;
            this.coll = collisions;
            this.left = left;
            this.right = right;

            this.source = Rectangle.Empty;
            this.dir = Direction.LEFT;
            this.ahead = Rectangle.Empty;
            this.dead = false;
            this.lives = 3;

            this.chomp = SoundSystem.Chomp.CreateInstance();

            state = 0;
            timer = 0;
        }

        public void Update(GameTime gameTime, KeyboardState key, 
            KeyboardState oldKey)
        {
            if(dead)
            {
                timer++;

                if(timer == 6)
                {
                    timer = 0;
                    if(state < 11)
                    {
                        state++;
                    }
                }

                source = new Rectangle(36 + 16 * state, 1, 14, 14);

                if (state > 8)
                    source.Height++;

                return;
            }

            if(key.IsKeyDown(Keys.Right) && !oldKey.IsKeyDown(Keys.Right))
            {
                switchDir(Direction.RIGHT);
            }
            else if(key.IsKeyDown(Keys.Left) && !oldKey.IsKeyDown(Keys.Left)) 
            {
                switchDir(Direction.LEFT);
            }
            else if(key.IsKeyDown(Keys.Up) && !oldKey.IsKeyDown(Keys.Up))
            {
                switchDir(Direction.UP);
            }
            else if(key.IsKeyDown(Keys.Down) && !oldKey.IsKeyDown(Keys.Down))
            {
                switchDir(Direction.DOWN);
            }

            Rectangle moveRect = rect;

            int velo = 2;

            switch(dir)
            {
                case Direction.RIGHT:
                    moveRect.X += velo;
                    break;
                case Direction.LEFT:
                    moveRect.X -= velo;
                    break;
                case Direction.UP:
                    moveRect.Y -= velo;
                    break;
                case Direction.DOWN:
                    moveRect.Y += velo;
                    break;
            }

            bool willCollide = false;

            foreach(Rectangle r in coll)
            {
                if(r.Intersects(moveRect))
                {
                    willCollide = true;
                    break;
                }
            }

            if(!willCollide)
            {
                rect = moveRect;
                if(chomp.State == SoundState.Stopped)
                {
                    chomp.Play();
                }
            } else
            {
                if (chomp.State == SoundState.Playing)
                {
                    chomp.Stop();
                }
            }

            Rectangle c1 = Rectangle.Empty, c2 = Rectangle.Empty, off1 = rect, off2 = rect;

            if (dir == Direction.UP || dir == Direction.DOWN)
            {
                off1.X -= rect.Width / 2;
                off2.X += rect.Width / 2;

                for (int i = 0; i < coll.Length; i++)
                {
                    Rectangle r = coll[i];
                    if (off1.Intersects(r))
                    {
                        c1 = r;
                    }
                    if (off2.Intersects(r))
                    {
                        c2 = r;
                    }

                    if (!c1.IsEmpty && !c2.IsEmpty)
                    {
                        int diff = c2.X - (c1.X + c1.Width);

                        rect.X = c2.X - diff / 2 - rect.Width / 2;
                        break;
                    }
                }
            }
            else
            {
                off1.Y -= rect.Height / 2;
                off2.Y += rect.Height / 2;
                for (int i = 0; i < coll.Length; i++)
                {
                    Rectangle r = coll[i];
                    if (off1.Intersects(r))
                    {
                        c1 = r;
                    }
                    if (off2.Intersects(r))
                    {
                        c2 = r;
                    }

                    if (!c1.IsEmpty && !c2.IsEmpty)
                    {
                        int diff = c2.Y - (c1.Y + c1.Height);

                        rect.Y = c2.Y - diff / 2 - rect.Height / 2;
                        break;
                    }
                }

            }

            if(rect.X + rect.Width < left.X + left.Width && dir == Direction.LEFT)
            {
                rect.X = right.X;
            } else if(rect.X > right.X)
            {
                rect.X = left.X;
            }

            timer++;

            if(timer >= 15)
            {
                timer = 0;

                if(state == 0)
                {
                    state = 1;
                } else
                {
                    state = 0;
                }
            }
            source = new Rectangle(3 + 16 * state, 1 + (16 * (int)dir), 14, 14);
        }

        public bool Kill()
        {
            this.dead = true;

            timer = 0;
            state = 0;

            SoundSystem.Death.Play();

            this.lives--;

            return lives <= 0;
        }

        public void switchDir(Direction dir)
        {
            if (this.dir == dir)
            {
                return;
            }

            this.ahead = new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);

            switch (dir)
            {
                case Direction.RIGHT:
                    ahead.X += 15;
                    break;
                case Direction.LEFT:
                    ahead.X -= 15;
                    break;
                case Direction.UP:
                    ahead.Y -= 15;
                    break;
                case Direction.DOWN:
                    ahead.Y += 15;
                    break;
            }

            bool canTurn = true;

            foreach (Rectangle r in coll)
            {
                if (ahead.Intersects(r))
                {
                    canTurn = false;
                    break;
                }
            }

            if (canTurn)
            {
                this.dir = dir;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if(Game1.TEST)
            {
                spriteBatch.Draw(text, ahead, source, Color.DarkRed);
            }

            spriteBatch.Draw(text, rect, source, Color.White);
        }
    }
}
