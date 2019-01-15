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
            VALUE_KEY
        };

        int mainScore = 0;
        //pac-dot
        Boolean isPacDotCollected = false;

        //fruit
        Boolean isCherryCollected = false;
        Boolean isStrawberryCollected = false;
        Boolean isOrangeCollected = false;
        Boolean isAppleCollected = false;
        Boolean isMellonCollected = false;
        Boolean isPineappleCollected = false;
        //Extra items
        Boolean isBellCollected = false;
        Boolean isKeyCollected = false;
        //PowPellet
        Boolean isPowePelletActive = false;

        int ghostIncrementor;
        
        public void collectItem(int item)
        {
            mainScore += scores[item];

            if (item == POWER_PELLET)
                ghostIncrementor = 0;
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

        }
    }
}
