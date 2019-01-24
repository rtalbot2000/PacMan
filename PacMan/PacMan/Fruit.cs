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
        Rectangle spriteSheetRect = new Rectangle(0, 0, 227, 160);
        private Rectangle[] fruitRects = new Rectangle[] {
            new Rectangle(36, 48, 15, 15),
            new Rectangle(52, 48, 15, 15),
            new Rectangle(68, 48, 15, 15),
            new Rectangle(84, 48, 15, 15),
            new Rectangle(100, 48, 15, 15),
            new Rectangle(116, 48, 15, 15),
            new Rectangle(132, 48, 15, 15),
            new Rectangle(148, 48, 15, 15)
        };
        private int[] time = new int[] {10, 9, 8, 7, 6, 5, 4, 2};
        int choice;
        public Fruit(int choice)
        {
            fruitRect = fruitRects[choice];
            this.choice = choice;
        }
        public void setFruit(int choice)
        {
            fruitRect = fruitRects[choice];
            this.choice = choice;
        }
        public Rectangle getFruitRect()
        {
            return fruitRect;
        }
        public int getTime()
        {
            return time[choice];
        }
    }
}
