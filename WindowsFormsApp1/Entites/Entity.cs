using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Survival.Entites
{
    public abstract class Entity
    {
        public Vector2 pos;
        public Vector2 dir;
        public abstract float hitboxSize { get; }
        public bool isMoving { get; set; }
        public int direction;
        public int health;

        public int currentAnimation;
        public int currentFrame;
        public int currentLimit;

        public int runFrames;
        public int idleFrames;
        public int attackFrames;
        public int hitFrames;
        public int deathFrames;

        public int spriteSize;

        public Image spriteSheet;

        public Entity(Vector2 pos, int runFrames, int idleFrames, int attackFrames, int hitFrames, int deathFrames, int size, int health, Image spriteSheet)
        {
            this.pos = pos;
            this.runFrames = runFrames;
            this.idleFrames = idleFrames;
            this.attackFrames = attackFrames;
            this.hitFrames = hitFrames;
            this.deathFrames = deathFrames;
            this.spriteSheet = spriteSheet;
            this.spriteSize = size;
            currentLimit = idleFrames;
            this.health = health;
        }

        
        public virtual void InputMove(Vector2 movement)
        {
            isMoving = movement.Length() != 0;
            pos += movement;
        }


        public virtual void PlayAnimation(Graphics g)
        {
            if (currentFrame < currentLimit - 1)
                currentFrame++;
            else currentFrame = 0;
            g.DrawImage(spriteSheet, new Rectangle(new Point((int)pos.X, (int)pos.Y), new Size(spriteSize, spriteSize)), spriteSize * currentFrame, spriteSize * currentAnimation, spriteSize, spriteSize, GraphicsUnit.Pixel);
        }
   


        public bool IntersectsWith(Entity entity)
        {
            if (this != null 
                && entity.pos.X < this.pos.X + this.hitboxSize 
                && this.pos.X < entity.pos.X + entity.hitboxSize 
                && entity.pos.Y < this.pos.Y + this.hitboxSize
                && this.pos.Y < entity.pos.Y + entity.hitboxSize)
            {
                return true;
            }

            return false;
        }

        public abstract void SetAnimationConfiguration(int currentAnimation);
    }
}
