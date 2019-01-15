using Microsoft.Xna.Framework;
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
        Rectangle rect;
        Texture2D text;
        Rectangle[] coll;

        public PacMan(Rectangle rect, Texture2D text, Rectangle[] collisions)
        {
            this.rect = rect;
            this.text = text;
            this.coll = collisions;

            this.dir = Direction.LEFT;
        }

        public void switchDir(Direction dir)
        {
            if(this.dir == dir)
            {
                return;
            }

            Rectangle ahead = new Rectangle(rect.Center.X, rect.Center.Y, 1, 1);

            switch(dir)
            {
                case Direction.RIGHT:
                    ahead.X += 4;
                    break;
                case Direction.LEFT:
                    ahead.X -= 4;
                    break;
                case Direction.UP:
                    ahead.Y -= 4;
                    break;
                case Direction.DOWN:
                    ahead.Y += 4;
                    break;
            }

            bool canTurn = true;

            foreach(Rectangle r in coll)
            {
                if(ahead.Intersects(r))
                {
                    canTurn = false;
                    break;
                }
            }

            if(canTurn)
            {
                this.dir = dir;
            }
        }

        public void Update(GameTime gameTime, KeyboardState key, 
            KeyboardState oldKey)
        {
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

            switch(dir)
            {
                case Direction.RIGHT:
                    moveRect.X += 1;
                    break;
                case Direction.LEFT:
                    moveRect.X -= 1;
                    break;
                case Direction.UP:
                    moveRect.Y -= 1;
                    break;
                case Direction.DOWN:
                    moveRect.Y += 1;
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
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(text, rect, Color.DarkGoldenrod);
        }
    }
}
