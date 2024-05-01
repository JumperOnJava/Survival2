using Survival.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Survival.Entites
{
    public class Dwarf : Monster
    {
        public Dwarf(Vector2 pos) : base(pos, SlimeMonster.runFrames, SlimeMonster.idleFrames, SlimeMonster.attackFrames, SlimeMonster.hitFrames, SlimeMonster.deathFrames, 64, 100, 150, new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\dwarf.png")))
        {
            this.currentAnimation = 0;
            this.isDead = false;
            this.speed = 2;
        }
        public override void SetAnimationConfiguration(int currentAnimation)
        {
            this.currentAnimation = currentAnimation;

            switch (currentAnimation)
            {
                case 0:
                    currentLimit = idleFrames;
                    break;
                case 2:
                    currentLimit = runFrames;
                    break;
                case 1:
                    currentLimit = attackFrames;
                    break;
                case 3:
                    currentLimit = hitFrames;
                    break;
                case 4:
                    currentLimit = deathFrames;
                    break;
            }
        }


    }
}
