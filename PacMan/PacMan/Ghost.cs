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

        public Ghost(Texture2D enemie, Rectangle enemieSource, Vector2 enemiePosition, Color enemieColor)
        {
            Sprite.texutre = enemie;
            Sprite.source = enemieSource;
            Sprite.color = enemieColor;
            Sprite.scale = 3;
            Sprite.rotation = 0;
            Sprite.position = enemiePosition;
            Sprite.effect = SpriteEffects.None;
            Sprite.origin = new Vector2(0, 0);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite.texutre, Sprite.position, Sprite.source, Sprite.color, Sprite.rotation, Sprite.origin, Sprite.scale, Sprite.effect, 0);
            //spriteBatch.Draw(Blinky.texture, Blinky.position, Blinky.source, Blinky.color, Blinky.rotation, Blinky.origin, Blinky.scale, Blinky.effect);
            //spriteBatch.Draw(Pinky.texture, Pinky.position, Pinky.source, Pinky.color, Pinky.rotation, Pinky.origin, Pinky.scale, Pinky.effect);
            //spriteBatch.Draw(Inky.texture, Inky.position, Inky.source, Inky.color, Inky.rotation, Inky.origin, Inky.scale, Inky.effect);
            //spriteBatch.Draw(Clyde.texture, Clyde.position, Clyde.source, Clyde.color, Clyde.rotation, Clyde.origin, Clyde.scale, Clyde.effect);
        }
    }
}
