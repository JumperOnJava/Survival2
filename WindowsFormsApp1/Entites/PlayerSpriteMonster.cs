using Survival;
using Survival.Entites;
using Survival.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Entites
{
    internal class PlayerSpriteMonster : Monster
    {
        public PlayerSpriteMonster(Vector2 pos) : base(pos,Hero.runFrames, Hero.idleFrames, Hero.attackFrames, Hero.hitFrames, Hero.deathFrames, 128, 100, 100, new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\player.png")))
        {
        }
        public void TryAttack(Player player)
        {
            if (this.IntersectsWith(player) && !this.isDead)
            {
                player.health -= 1;

                switch (player.direction)
                {
                    case 0:
                        player.SetAnimationConfiguration(13);
                        break;
                    case 1:
                        player.SetAnimationConfiguration(12);
                        break;
                    case 2:
                        player.SetAnimationConfiguration(14);
                        break;
                    case 3:
                        player.SetAnimationConfiguration(15);
                        break;
                }
            }
        }public override void SetAnimationConfiguration(int currentAnimation)
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
        public override void Update()
        {
            base.Update();
            UpdateMonsterMovement(Form1.player);
            this.TryAttack(Form1.player);
        }
        public override void DetermineMonsterAnimation(Player player)
        {
            // Отримати різницю між координатами створіння та гравця
            float dx = player.pos.X - this.pos.X;
            float dy = player.pos.Y - this.pos.Y;
            if (Math.Abs(dx) <= this.spriteSize / 4 && Math.Abs(dy) <= this.spriteSize / 4)
            {
                switch (this.direction)
                {
                    case 0:
                        this.SetAnimationConfiguration(4);
                        break;
                    case 1:
                        this.SetAnimationConfiguration(5);
                        break;
                    case 2:
                        this.SetAnimationConfiguration(6);
                        break;
                    case 3:
                        this.SetAnimationConfiguration(7);
                        break;
                }
            }
            else
            {
                // Визначити напрямок руху створіння
                if (dx == 0 && dy < 0)
                {
                    this.SetAnimationConfiguration(1); // Рух вверх
                }
                else if (dx > 0 && dy < 0)
                {
                    this.SetAnimationConfiguration(2); // Рух по діагоналі вправо вгору
                }
                else if (dx > 0 && dy == 0)
                {
                    this.SetAnimationConfiguration(2); // Рух вправо
                }
                else if (dx > 0 && dy > 0)
                {
                    this.SetAnimationConfiguration(2); // Рух по діагоналі вправо вниз
                }
                else if (dx == 0 && dy > 0)
                {
                    this.SetAnimationConfiguration(0); // Рух вниз
                }
                else if (dx < 0 && dy > 0)
                {
                    this.SetAnimationConfiguration(3); // Рух по діагоналі вліво вниз (той самий що й вниз)
                }
                else if (dx < 0 && dy == 0)
                {
                    this.SetAnimationConfiguration(3); // Рух вліво
                }
                else if (dx < 0 && dy < 0)
                {
                    this.SetAnimationConfiguration(3); // Рух по діагоналі вліво вгору (той самий що й вгору)
                }
            }
        }
        public virtual void UpdateMonsterMovement(Player player)
        {

            float dx = player.pos.X - this.pos.X;
            float dy = player.pos.Y - this.pos.Y;

            // Визначити напрямок руху створіння
            int moveX = Math.Sign((int)dx); // Рухатись в напрямку гравця по осі X
            int moveY = Math.Sign((int)dy); // Рухатись в напрямку гравця по осі Y

            // Задати напрямок руху створіння
            Vector2 dir;
            dir.X = moveX;
            dir.Y = moveY;

            // Зберегти напрямок руху монстра
            if (moveX == 0 && moveY == -1)
            {
                this.direction = 1; // Рух вгору
            }
            else if (moveX == 0 && moveY == 1)
            {
                this.direction = 0; // Рух вниз
            }
            else if (moveX == 1 && moveY == 0)
            {
                this.direction = 2; // Рух вправо
            }
            else if (moveX == -1 && moveY == 0)
            {
                this.direction = 3; // Рух вліво
            }

            if (Math.Abs(dx) <= this.spriteSize / 4 && Math.Abs(dy) <= this.spriteSize / 4)
            {
            }
            else
            {
                this.InputMove(dir);
            }
        }
    }
}
