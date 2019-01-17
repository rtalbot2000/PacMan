using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacMan
{
    class Ghost
    {
        Texture2D enemies;//Set this up as an array of Textures for enemies
        Rectangle enemiesRect;//Set this up as an array of Rects for enemies
        Color enemiesColor;


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
            public Boolean visible;
            public Boolean width;
        }
        SprtieStruct Sprite;
        SprtieStruct Blinky;//Red
        SprtieStruct Pinky;//Pink
        SprtieStruct Inky;//Blue
        SprtieStruct Clyde;//Orange
        public Ghost(Texture2D enemies, Rectangle enemiesRect, Color enemiesColor)
        {
            this.enemies = enemies;
            this.enemiesRect = enemiesRect;
            this.enemiesColor = enemiesColor;
        }
        public void Initialize()
        {
            Blinky.position = new Vector2(0,0);
            Blinky.source = new Rectangle(3,64,14,15);
            Blinky.color = Color.White;
            Blinky.rotation = 0;
            Blinky.origin = new Vector2(0,0);
            Blinky.scale = 1;
            Blinky.effect = SpriteEffects.None;

            Pinky.position = new Vector2();
            Pinky.source = new Rectangle();
            Pinky.color = Color.White;
            Pinky.rotation = 0;
            Pinky.origin = new Vector2();
            Pinky.scale = 1;
            Pinky.effect = SpriteEffects.None;

            Inky.position = new Vector2();
            Inky.source = new Rectangle();
            Inky.color = Color.White;
            Inky.rotation = 0;
            Inky.origin = new Vector2();
            Inky.scale = 1;
            Inky.effect = SpriteEffects.None;

            Clyde.position = new Vector2();
            Clyde.source = new Rectangle();
            Clyde.color = Color.White;
            Clyde.rotation = 0;
            Clyde.origin = new Vector2();
            Clyde.scale = 1;
            Clyde.effect = SpriteEffects.None;
        }
       
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Blinky.texture, Blinky.position, Blinky.source, Blinky.color, Blinky.rotation, Blinky.origin, Blinky.scale, Blinky.effect);
            spriteBatch.Draw(Pinky.texture, Pinky.position, Pinky.source, Pinky.color, Pinky.rotation, Pinky.origin, Pinky.scale, Pinky.effect);
            spriteBatch.Draw(Inky.texture, Inky.position, Inky.source, Inky.color, Inky.rotation, Inky.origin, Inky.scale, Inky.effect);
            spriteBatch.Draw(Clyde.texture, Clyde.position, Clyde.source, Clyde.color, Clyde.rotation, Clyde.origin, Clyde.scale, Clyde.effect);
        }
    }
}
