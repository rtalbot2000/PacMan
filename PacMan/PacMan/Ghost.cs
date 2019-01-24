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
        public enum Directions { RIGHT = 0, LEFT = 2, UP = 4, DOWN = 6 };
        public enum States { NORMAL, VUNERABLE, TRANSITION, EATEN };

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
//        public Boolean visible;
//        public Boolean width;
        }
        SprtieStruct Sprite;
        private int sourceOffset;
        private int phase;

        private Directions direction;

        private States state;

        private Rectangle normalSource;
        private Rectangle vunerableSource;
        private Rectangle eatenSource;
        private Rectangle transitionSource;

        public Vector2 Position
        {
            get { return Sprite.position; }
            set { Sprite.position = value; }
        }

        public Directions Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public States State
        {
            get { return state; }
            set { state = value; }
        }

        public Ghost(Texture2D enemie, Rectangle enemieSource, Rectangle vunerableSource, Rectangle transitionSource, Rectangle eatenSource, Vector2 enemiePosition, Color enemiesColor)
        {
            direction = Directions.RIGHT;
            phase = 0;
            state = States.NORMAL;

            normalSource = enemieSource;
            this.vunerableSource = vunerableSource;
            this.eatenSource = eatenSource;
            this.transitionSource = transitionSource;

            Sprite.texutre = enemie;
            Sprite.source = enemieSource;
            sourceOffset = Sprite.source.X;
            Sprite.color = enemiesColor;
            Sprite.scale = 3;
            Sprite.rotation = 0;
            Sprite.position = enemiePosition;
            Sprite.effect = SpriteEffects.None;
            Sprite.origin = new Vector2(0, 0);
            
        }
        public void Update(int Timer)
        {
            if (Timer % 10 == 0)
            {
                if (phase == 1)
                    phase = 0;
                else
                    phase = 1;
            }
            switch (state)
            {
                case States.NORMAL:
                    Sprite.source = normalSource;
                    Sprite.source.X = ((int)direction + phase) * Sprite.source.Width + sourceOffset;
                    break;
                case States.VUNERABLE:
                    Sprite.source.X = vunerableSource.X;
                    Sprite.source.Y = vunerableSource.Y;
                    Sprite.source.X = phase * Sprite.source.Width + vunerableSource.X + sourceOffset;
                    break;
                case States.EATEN:
                    int eyesDirection = 0;
                    switch (direction)
                    {
                        case Directions.RIGHT:
                            eyesDirection = 0;
                            break;
                        case Directions.LEFT:
                            eyesDirection = 1;
                            break;
                        case Directions.UP:
                            eyesDirection = 2;
                            break;
                        case Directions.DOWN:
                            eyesDirection = 3;
                            break;
                    }
                    Sprite.source = eatenSource;
                    Sprite.source.X = (eyesDirection) * Sprite.source.Width + sourceOffset + eatenSource.X;
                    break;
                case States.TRANSITION:
                    break;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Sprite.texutre, Sprite.position, Sprite.source, Sprite.color, Sprite.rotation, Sprite.origin, Sprite.scale, Sprite.effect, 0);
        }
    }
}
