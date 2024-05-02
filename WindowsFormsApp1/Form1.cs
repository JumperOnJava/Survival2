using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Survival.Entites;
using Survival.Models;
using Survival.Controllers;
using System.Runtime.InteropServices;
using System.Numerics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WindowsFormsApp1.Util;
using WindowsFormsApp1.Entites;


namespace Survival
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        public bool gameOver = false;
        public static Player player;
        //public Monster monster;
        public List<Entity> entities = new List<Entity>();

        public int spawnTimer = 0;
        public int spawnTimerDead = 0;
        public int spawnInterval = 5000;
        public int deadInterval = 10000;
        // public int interval = 5000;

        static float TargetFrameRate = 1000;
        
        public Form1(Form2 f)
        {
            InitializeComponent();

            foreach (Keys keys in Enum.GetValues(typeof(Keys)))
            {
                PressedKeys[keys] = false;
            }

            timerMovement.Interval = (int)(1000/TargetFrameRate);
            timerMovement.Tick += (DeltaUpdate);
            KeyDown += new KeyEventHandler(Keyboard);
            KeyUp += new KeyEventHandler(FreeKeyboard);

            timerSpawnMonster.Interval = 1000;
            timerSpawnMonster.Tick += new EventHandler(SpawnMonsterTick);
            timerSpawnMonster.Start();

            timerDeadMonster.Interval = 1000;
            timerDeadMonster.Tick += new EventHandler(DeadMonsterTick);
            timerDeadMonster.Start();

            Init();

        }
        private void DeadMonsterTick(object sender, EventArgs e)
        {
            spawnTimerDead += 1000; // Додаємо 1 секунду до таймера монстрів
            if (spawnTimerDead >= deadInterval)
            {
                for (int i = 0; i < entities.Count; i++)
                {
                    if(entities.GetType() != typeof(Monster))
                        continue;
                    Monster monster = (Monster)entities[i];
                    if (monster != null && monster.isDead)
                    {
                        entities[i] = null;
                    }
                }

                spawnTimerDead = 0; // Скидаємо таймер, оскільки монстр з'явився
            }
        }

        private void SpawnMonsterTick(object sender, EventArgs e)
        {
            spawnTimer += 1000; // Додаємо 1 секунду до таймера монстрів
            if (spawnTimer >= spawnInterval)
            {
                SpawnMonster();
                spawnTimer = 0; // Скидаємо таймер, оскільки монстр з'явився
            }
        }

        private void SpawnMonster()
        {
            int x = rnd.Next(0, this.Width); // Випадкова координата X в межах ширини форми
            int y = rnd.Next(0, this.Height); // Випадкова координата Y в межах висоти форми

            Monster monster = new PlayerSpriteMonster(new Vector2(x, y));
            entities.Add(monster);
        }

        public static Dictionary<Keys,bool> PressedKeys = new Dictionary<Keys,bool>();
        private void FreeKeyboard(object sender, KeyEventArgs e)
        {
            PressedKeys[e.KeyCode] = false;
        }

        private void Keyboard(object sender, KeyEventArgs e)
        {
            PressedKeys[e.KeyCode]=true;
            /*
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.dir.Y = -5;
                    player.isMoving = true;
                    player.SetAnimationConfiguration(1);
                    player.direction = 0;
                    break;
                case Keys.S:
                    player.dir.Y = 5;
                    player.isMoving = true;
                    player.SetAnimationConfiguration(0);
                    player.direction = 1;
                    break;
                case Keys.D:
                    player.dir.X = 5;
                    player.isMoving = true;
                    player.SetAnimationConfiguration(2);
                    player.direction = 2;
                    break;
                case Keys.A:
                    player.dir.X = -5;
                    player.isMoving = true;
                    player.SetAnimationConfiguration(3);
                    player.direction = 3;
                    break;
                case Keys.Space:
                    player.dir.X = 0;
                    player.dir.Y = 0;
                    player.isMoving = false;
                    switch (player.direction)
                    {
                        case 0:
                            player.SetAnimationConfiguration(9);
                            break;
                        case 1:
                            player.SetAnimationConfiguration(8);
                            break;
                        case 2:
                            player.SetAnimationConfiguration(11);
                            break;
                        case 3:
                            player.SetAnimationConfiguration(10);
                            break;
                    }
                    if(player.AttackCooldown <= 0)
                    {
                        foreach (Monster monster in monsters)
                        {

                            if (player.IntersectsWith(monster))
                            {
                                player.AttackCooldown = 1;
                                player.PlayerAttack(monster);
                                Console.WriteLine("attacked monster "+new Random().Next());
                            }
                        }
                    }

                    break;
            }*/

        }

        System.Diagnostics.Stopwatch Watch = new System.Diagnostics.Stopwatch();

        public static float deltaTime = 0;
        void DeltaUpdate(object sender, EventArgs e)
        {
            Watch.Stop();
            deltaTime = Watch.ElapsedMilliseconds / 1000f;
            Tick();
            Watch.Restart();
        }

        public void Tick()
        {
            foreach (var entity in entities)
            {
                entity.Update();
            }
            Invalidate();
        }

        private void Control(Monster monster, Player player)
        {
            if (player.health == 0)
            {
                player.dir.X = 0;
                player.dir.Y = 0;
                player.SetAnimationConfiguration(16);
                timerMovement.Stop();
            }

            if (monster != null)
            {
                
            }
        }
        public void Init()
        {
            MapController.Init();

            this.Width = MapController.GetWidth();
            this.Height = MapController.GetHeight();

            player = new Player(new Vector2(10, 10));
            entities.Add(player);
            //monster = new Monster(150, 150, Hero.runFrames, Hero.idleFrames, Hero.attackFrames, Hero.hitFrames, Hero.deathFrames, 128, 100, playerSheet);

            entities.Add(new Slime(new Vector2(100, 100)));

            entities.Add(new Dwarf(new Vector2(300,300)));

            timerMovement.Start();
        }

        public void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            MapController.DrawMap(g);
            foreach(Entity entity in entities)
            {
                entity.Draw(g);
            }
        }
        private void labelPause_Click(object sender, EventArgs e)
        {
            timerMovement.Stop();
            timerSpawnMonster.Stop();
            timerDeadMonster.Stop();
            labelNoPause.Visible = true;
            labelExit.Visible = true;
            labelNoPause.BackColor = Color.Transparent;
            labelExit.BackColor = Color.Transparent;
        }

        private void labelNoPause_Click(object sender, EventArgs e)
        {
            timerMovement.Start();
            timerSpawnMonster.Start();
            timerDeadMonster.Start();
            labelNoPause.Visible = false;
            labelExit.Visible = false;
        }
        private void labelExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}