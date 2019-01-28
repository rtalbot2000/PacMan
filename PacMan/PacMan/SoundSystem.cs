using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PacMan
{
    class SoundSystem
    {
        public static SoundEffect Begin, Chomp, Death, EatFruit, EatGhost, ExtraLife, Intermission;

        public static void LoadSounds(ContentManager manager)
        {
            Begin = manager.Load<SoundEffect>("beginning");
            Chomp = manager.Load<SoundEffect>("chomp");
            Death = manager.Load<SoundEffect>("death");
            EatFruit = manager.Load<SoundEffect>("eatfruit");
            EatGhost = manager.Load<SoundEffect>("eatghost");
            ExtraLife = manager.Load<SoundEffect>("extrapac");
            Intermission = manager.Load<SoundEffect>("intermission");
        }
    }
}
