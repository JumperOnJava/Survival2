using Survival.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Util;

namespace Survival.Entites
{
    public class Player : Entity
    {
        public int countKill { get; set; }
        public Vector2 dir = Vector2.Zero;

        public override float hitboxSize => 32;

        public float AttackCooldown = 0;
        public Player(Vector2 pos) 
            : base(pos, Hero.runFrames, Hero.idleFrames, Hero.attackFrames, Hero.hitFrames, Hero.deathFrames, 128, 100, 200, new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\player.png")))
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
                //monster.health -= 20;
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
        public override void InputMove(Vector2 movement)
        {
            base.InputMove(movement);
            if(movement != Vector2.Zero)
            {
                dir = movement;
            }
        }
        public override void Update()
        {
            Vector2 playerMovement = new Vector2(
                (Form1.PressedKeys[Keys.D] ? 0 : -1) +
                (Form1.PressedKeys[Keys.A] ? 0 : 1),

                (Form1.PressedKeys[Keys.W] ? 0 : 1) +
                (Form1.PressedKeys[Keys.S] ? 0 : -1)
            );
            this.InputMove(playerMovement.Normalized());
            this.AttackCooldown -= Form1.deltaTime;
            this.UpdateAnimation();
        }

        private void UpdateAnimation()
        {
            float angle = (float)((float)Math.Atan2(dir.Y, dir.X)*(180/Math.PI));
            Console.WriteLine((int)(angle/90));
            switch (angle / 90)
            {
                case -1:
                    this.SetAnimationConfiguration(5);
                    break;
                case 1:
                    this.SetAnimationConfiguration(4);
                    break;
                case 0.5f:
                case -0.5f:
                case 0:
                    this.SetAnimationConfiguration(6);
                    break;
                case 1.5f:
                case -1.5f:
                case 2:
                    this.SetAnimationConfiguration(7);
                    break;
            }
        }
    }
}
