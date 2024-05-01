using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Survival.Entites
{
    public class Dwarf : Monster
    {
        public Dwarf(Vector2 pos, int runFrames, int idleFrames, int attackFrames, int hitFrames, int deathFrames, int size, int health, Image spriteSheet) : base(pos, runFrames, idleFrames, attackFrames, hitFrames, deathFrames, size, health, spriteSheet)
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
