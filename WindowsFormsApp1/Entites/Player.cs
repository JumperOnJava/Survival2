using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Survival.Entites
{
    public class Player : Entity
    {
        public int countKill { get; set; }

        public override float hitboxSize => 32;

        public float AttackCooldown = 0;
        public Player(Vector2 pos, int runFrames, int idleFrames, int attackFrames, int hitFrames, int deathFrames, int size, int health, Image spriteSheet) 
            : base(pos, runFrames, idleFrames, attackFrames, hitFrames, deathFrames, size, health, spriteSheet)
        {
            currentAnimation = 4;
            currentFrame = 0;
            countKill = 0;
        }

        

        public void PlayerAttack(Monster monster)
        {
            if (this.IntersectsWith(monster) && monster.health > 0)
            {
                monster.isMoving = false;
                monster.dir = new Vector2(0,0);
                monster.health -= 20;
                monster.SetAnimationConfiguration(12);
            }
        }

        public override void SetAnimationConfiguration(int currentAnimation)
        {
            this.currentAnimation = currentAnimation;

            switch (currentAnimation)
            {
                case 4:
                case 5:
                case 6:
                case 7:
                    currentLimit = idleFrames;
                    break;
                case 0:
                case 1:
                case 2:
                case 3:
                    currentLimit = runFrames;
                    break;
                case 8:
                case 9:
                case 10:
                case 11:
                    currentLimit = attackFrames;
                    break;
                case 12:
                case 13:
                case 14:
                case 15:
                    currentLimit = hitFrames;
                    break;
                case 16:
                    currentLimit = deathFrames;
                    break;
            }
        }
    }
}
