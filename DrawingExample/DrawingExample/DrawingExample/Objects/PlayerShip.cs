using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LineDraw;

namespace DrawingExample
{ 
   public class PlayerShip : BaseGameObject
    {
        public float ThrustValue = 5;
        public int ScreenBuffer = 100;
        public float RotationRate = 20;
        public override void InitalizeObject()
        {
         HasMaxiumVelocity = true;
         MaxiumVelocity = 100;
         sprite = new Sprite("Tie");
        }

        public override void Update(GameTime gameTime)
        {
            //GameApp.instance.graphics.PreferredBackBufferWidth;
            // GameApp.instance.graphics.PreferredBackBufferHeight;

            if (Position.X > (GameApp.instance.graphics.PreferredBackBufferWidth + ScreenBuffer))
            {
                Position.X = -ScreenBuffer;
            }

            if (Position.X < (-ScreenBuffer))
            {
                Position.X = (GameApp.instance.graphics.PreferredBackBufferWidth + ScreenBuffer);
            }


            if (Position.Y > (GameApp.instance.graphics.PreferredBackBufferHeight + ScreenBuffer))
            {
                Position.Y = -ScreenBuffer;
            }

            if (Position.Y < (-ScreenBuffer))
            {
                Position.Y = (GameApp.instance.graphics.PreferredBackBufferHeight + ScreenBuffer);
            }



        }

        public virtual void Thrust()
        {
           Velocity += LinePrimatives.AngleToV2(Rotation, ThrustValue);
        }

        public virtual void AddRotate(float value, GameTime gameTime)
        {
            float dt = (float)(gameTime.ElapsedGameTime.TotalMilliseconds / 1000f);

            Rotation += (value * RotationRate * dt * (MathHelper.Pi/180));
        }

    }
}
