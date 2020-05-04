using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LineDraw;
using System.Runtime.Remoting;

namespace DrawingExample
{
    public class LargeAsteroid : BaseGameObject
    {
        public float AsteroidSpeed = 45;
        public float RotationRate = 45;
        public override void InitalizeObject()
        {
            //HasMaxiumVelocity = true;
            //MaxiumVelocity = 100;
            sprite = new Sprite("NewAsteroid2");

            sprite.scale = 0.10f;

            sprite.origin.X = (sprite.texture.Width / 2);
            sprite.origin.Y = (sprite.texture.Height / 2);

            Collison = new Rectangle(0, 0, (int)(sprite.texture.Width * sprite.scale), (int)(sprite.texture.Height * sprite.scale));

            SetSpawnLocation();
        }

        public virtual void SetSpawnLocation()
        {
            Vector2 SpawnLocation = Vector2.Zero;
            Vector2 HeadLocation = Vector2.Zero;
            int side = GameApp.instance.random.Next(4);
            
            
         

            if(side == 0)//Left Side
            {
                SpawnLocation.X = -ScreenBuffer;
                SpawnLocation.Y = GameApp.instance.random.Next(GameApp.instance.graphics.PreferredBackBufferHeight);
                HeadLocation.X = (GameApp.instance.graphics.PreferredBackBufferWidth + ScreenBuffer);
                HeadLocation.Y = GameApp.instance.random.Next(GameApp.instance.graphics.PreferredBackBufferHeight);
            }
            if (side == 1)//Right Side
            {
                SpawnLocation.X = (GameApp.instance.graphics.PreferredBackBufferWidth + ScreenBuffer);
                SpawnLocation.Y = GameApp.instance.random.Next(GameApp.instance.graphics.PreferredBackBufferHeight);
                HeadLocation.X = -ScreenBuffer;
                HeadLocation.Y = GameApp.instance.random.Next(GameApp.instance.graphics.PreferredBackBufferHeight); 
            }
            if (side == 2)//Top Side
            {
                SpawnLocation.X = GameApp.instance.random.Next(GameApp.instance.graphics.PreferredBackBufferWidth);
                SpawnLocation.Y = -ScreenBuffer;
                HeadLocation.X = GameApp.instance.random.Next(GameApp.instance.graphics.PreferredBackBufferWidth);
                HeadLocation.Y = (GameApp.instance.graphics.PreferredBackBufferHeight + ScreenBuffer);
            }
            if (side == 3)//Bottom Side
            {
                SpawnLocation.X = GameApp.instance.random.Next(GameApp.instance.graphics.PreferredBackBufferWidth);
                SpawnLocation.Y = (GameApp.instance.graphics.PreferredBackBufferHeight + ScreenBuffer);
                HeadLocation.X = GameApp.instance.random.Next(GameApp.instance.graphics.PreferredBackBufferWidth);
                HeadLocation.Y = -ScreenBuffer;
            }

            Position = SpawnLocation;



            Console.WriteLine(side);


            Velocity = (HeadLocation - SpawnLocation);
            Velocity.Normalize();
            Velocity *= AsteroidSpeed;


        }

        public override void Update(GameTime gameTime)
        {
            CheckCollision();

        }
        public virtual void AddRotate(float value, GameTime gameTime)
        {
            float dt = (float)(gameTime.ElapsedGameTime.TotalMilliseconds / 1000f);

            Rotation += (value * RotationRate * dt * (MathHelper.Pi / 180));
        }

        public override void OnDestroy()
        {
            LargeAsteroid newLarge = new LargeAsteroid();

            Asteroid newMedium = new Asteroid();
            newMedium.Position = this.Position;
            newMedium.Velocity = this.Velocity;

            //create 2 medium asteroids
        }

        public virtual void CheckCollision()
        {
            foreach(BaseGameObject obj in GameApp.instance.SceneList)
            {
                if(obj == this)
                {
                    continue;
                }

                if(Collison.Intersects(obj.Collison))
                {
                    //if player 
                    if (obj is PlayerShip)
                    {
                        obj.Destroy();
                        this.Destroy();
                        Console.WriteLine("Player Destroyed");
                    }

                    //if projectile

                    if (obj is Torpedo)
                    {
                        obj.Destroy();
                        this.Destroy();
                    }

                }
            }
        }
    }
}
