using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacMan
{
    class ScoringSystem
    {
        public const int PAC_DOT = 0;
        public const int POWER_PELLET = 1;
        public const int VULNERABLE_GHOST = 2;
        public const int CHERRY = 3;
        public const int STRAWBERRY = 4;
        public const int ORANGE = 5;
        public const int APPLE = 6;
        public const int MELLON = 7;
        public const int PINEAPPLE = 8;
        public const int GALAGICA_BOSS = 9;
        public const int BELL = 10;
        public const int KEY = 11;
        public const int DEATH = 12;

        private const int VALUE_PAC_DOT = 10;
        private const int VALUE_POWER_PELLET = 50;
        private const int VALUE_VULNERABLE_GHOST = 200;
        private const int VALUE_CHERRY = 100;
        private const int VALUE_STRAWBERRY = 300;
        private const int VALUE_ORANGE = 500;
        private const int VALUE_APPLE = 700;
        private const int VALUE_MELLON = 1000;
        private const int VALUE_PINEAPPLE = 1500;
        private const int VALUE_GALAGICA_BOSS = 2000;
        private const int VALUE_BELL = 3000;
        private const int VALUE_KEY = 5000;
        private const int VALUE_DEATH = -500;

        private int[] scores = {
            VALUE_PAC_DOT,
            VALUE_POWER_PELLET,
            VALUE_VULNERABLE_GHOST,
            VALUE_CHERRY,
            VALUE_STRAWBERRY,
            VALUE_ORANGE,
            VALUE_APPLE,
            VALUE_MELLON,
            VALUE_PINEAPPLE,
            VALUE_GALAGICA_BOSS,
            VALUE_BELL,
            VALUE_KEY,
            VALUE_DEATH
        };

        int mainScore = 0;
        int lives;
        int extraLifeCon = 0;

        int ghostIncrementor;

        Vector2 scoreDisplay;

        SpriteFont scoreFont;

        Color scoreColor;

        public ScoringSystem(Vector2 scoreDisplay, SpriteFont scoreFont, Color scoreColor)
        {
            this.scoreDisplay = scoreDisplay;
            this.scoreFont = scoreFont;
            this.scoreColor = scoreColor;
            extraLifeCon = 0;
            lives = 3;
        }

        public Boolean collectItem(int item)
        {
            mainScore += scores[item];

            if (item == POWER_PELLET)
                ghostIncrementor = 0;
            if (item == DEATH)
                lives--;
            if(item == VALUE_VULNERABLE_GHOST)
            {
                
                switch (ghostIncrementor)
                {
                    case 0:
                       //first ghost score is already scored at 200
                        break;
                    case 1:
                        mainScore += 200;
                        break;
                    case 2:
                        mainScore += 600;
                        break;
                    case 3:
                        mainScore += 1400;
                        break;
                }
            }

                switch (item)
            {
                case PAC_DOT:
                    mainScore += VALUE_PAC_DOT;
                    break;
                case POWER_PELLET:
                    mainScore += VALUE_POWER_PELLET;
                    break;
                case VULNERABLE_GHOST:
                    mainScore += VALUE_VULNERABLE_GHOST;
                    break;
                
            }

            Boolean extralife = false;
            if (lives < 5)
            {
                if (mainScore / 10000 > extraLifeCon)
                {
                    extraLifeCon = mainScore / 10000;
                    extralife = true;
                    lives++;
                }
            }
            return extralife;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(scoreFont, "HighScore"+mainScore,  scoreDisplay, scoreColor);
        }
    }
}
