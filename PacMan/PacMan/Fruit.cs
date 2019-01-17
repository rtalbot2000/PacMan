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
    class Fruit : Microsoft.Xna.Framework.Game
    {
        Rectangle fruitRect;
        Texture2D image;
        private Rectangle[] fruitRects = new Rectangle[] {
            new Rectangle(32, 48, 16, 16),
            new Rectangle(48, 48, 16, 16),
            new Rectangle(64, 48, 16, 16),
            new Rectangle(80, 48, 16, 16),
            new Rectangle(96, 48, 16, 16),
            new Rectangle(112, 48, 16, 16),
            new Rectangle(128, 48, 16, 16),
            new Rectangle(144, 48, 16, 16)
        };
        public Fruit(int level)
        {
            fruitRect = fruitRects[level];
        }
        public void setRect(int level)
        {
            fruitRect = fruitRects[level];
        }
    }
}
