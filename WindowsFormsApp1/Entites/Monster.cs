using Survival.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Survival.Entites
{
    public abstract class Monster : Entity
    {
        public bool isDead;
        public int speed;

        public override float hitboxSize => 32;

        public Monster(Vector2 pos, int runFrames, int idleFrames, int attackFrames, int hitFrames, int deathFrames, int spriteSize, int health, int speed, Image spriteSheet) : base(pos, runFrames, idleFrames, attackFrames, hitFrames, deathFrames, spriteSize, health, speed, spriteSheet)
        {
            this.isDead = false;
            this.speed = 1;
        }

        public virtual void DetermineMonsterAnimation(Player player) { }
        public override void Draw(Graphics g)
        {
            if (!isDead)
            {
                if (currentFrame < currentLimit - 1)
                    currentFrame++;
                else
                {
                    if (currentAnimation == 16)
                        isDead = true;
                    else
                        currentFrame = 0;
                }
            }
            g.DrawImage(spriteSheet, new Rectangle(new Point((int)pos.X, (int)pos.Y), new Size(spriteSize, spriteSize)), spriteSize * currentFrame, spriteSize * currentAnimation, spriteSize, spriteSize, GraphicsUnit.Pixel);
        }

        

        public override void Update()
        {
            if (this.health <= 0)
            {

                this.isMoving = false;
                this.SetAnimationConfiguration(16);

                this.isDead = true;
            }
            else
            {
                this.isMoving = true;
            }
            if (this.isMoving)
            {
                this.DetermineMonsterAnimation(Form1.player);
            }
        }
    }
}
