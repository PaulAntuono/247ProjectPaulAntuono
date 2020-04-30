using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LineDraw; 

namespace DrawingExample
{
    class GameMode : GameApp
    {
        PlayerShip Player1;
        SpriteFont font; 

        float offset = 0;
        //bool MouseShow = false;

        Line theline;

        Grid2D theGrid;

        XMark xMark; 

        /// <summary>
        /// Default Constructor. Most of the work you need to do should be in Initalize
        /// </summary>
        public GameMode() : base()
        {
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            font = GameApp.instance.Content.Load<SpriteFont>("Font");
            // TODO: use this.Content to load your game content here

            // Setting up Screen Resolution
            // Read more here: http://rbwhitaker.wikidot.com/changing-the-window-size
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 480;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

            Player1 = new PlayerShip();
            Player1.Position = new Vector2(300, 300);

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
           
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            // If you create textures on the fly, you need to unload them. 
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void GameUpdate(GameTime gameTime)
        {

            offset += gameTime.ElapsedGameTime.Milliseconds;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                    || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
           
            if (IsKeyHeld(Keys.W))
            {
                Player1.Thrust();
            }

            if (IsKeyHeld(Keys.A))
            {
                Player1.AddRotate(-1, gameTime);
            }

            if (IsKeyHeld(Keys.D))
            {
                Player1.AddRotate(1, gameTime);
            }

            if (IsKeyPressed(Keys.Q))
            {
                Player1.Shoot();
            }




        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void GameDraw(GameTime gameTime)
        {

            string message = "Rotation: " + Player1.Rotation.ToString();
            string newmessage = "Velocity: " + Player1.Velocity.ToString();

            spriteBatch.DrawString(font, message, new Vector2(200, 200), Color.Red);

            spriteBatch.DrawString(font, newmessage, new Vector2(200, 300), Color.Red);



        }
    }
}
