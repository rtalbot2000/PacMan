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
        public int currentFrame;
//        public Boolean visible;
//        public Boolean width;
        }
        SprtieStruct Sprite;
        int currentFrame;
        
        public Ghost(Texture2D enemie, Rectangle enemieSource, Vector2 enemiePosition, Color enemieColor)
        {
            Sprite.texutre = enemie;
            Sprite.source = enemieSource;
            Sprite.color = enemieColor;
            Sprite.scale = 3;
            Sprite.rotation = 0;
            Sprite.position = enemiePosition;
            Sprite.effect = SpriteEffects.None;
            Sprite.currentFrame = currentFrame;
            Sprite.origin = new Vector2(0, 0);
            for (int k = 0; k > 4; k++)
            {
                currentFrame++;
    
                if (currentFrame > 4)
                    currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite.texutre, Sprite.position, Sprite.source, Sprite.color, Sprite.rotation, Sprite.origin, Sprite.scale, Sprite.effect, 0);
        }
    }
}
