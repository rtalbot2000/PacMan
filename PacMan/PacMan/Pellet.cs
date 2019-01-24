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
    class Pellet
    {
        private Texture2D pellet;
        private Rectangle pelletRect;
        private int pelletXLocation, pelletYLocation;
        private bool power;

        public Texture2D PelletText
        {
            get
            {
                return pellet;
            }
        }

        public int PelletYLocation
        {
            get
            {
                return pelletYLocation;
            }
        }

        public int PelletXLocation
        {
            get
            {
                return pelletXLocation;
            }

        }
        public Rectangle PelletRect
        {
            get
            {
                return pelletRect;
            }
        }

        public Pellet(Rectangle pr, bool power)
        {
            pelletRect = pr;
            pelletXLocation = pr.X;
            pelletYLocation = pr.Y;
            this.power = power;
        }

        public void LoadTexture(Texture2D texture)
        {
            this.pellet = texture;
        }

        public void Update(GameTime gametime)
        {

        }
    }
}
