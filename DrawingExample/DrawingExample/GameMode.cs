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
        float offset = 0;
        Grid2D theGrid;

        /// <summary>
        /// Public contstructor... Does need to do anything at all. Those are the best constructors. 
        /// </summary>
        public GameMode() : base() { }

        protected override void Initialize()
        {
            base.Initialize();

            // Setting up Screen Resolution
            // Read more here: http://rbwhitaker.wikidot.com/changing-the-window-size
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 480;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();

            theGrid = new Grid2D();
            IsMouseVisible = true; 
      
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

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            int deltaScrollWheel = mousePrevious.ScrollWheelValue - mouseCurrent.ScrollWheelValue; 
            if (deltaScrollWheel != 0)
            {
                theGrid.GridSize += (Math.Abs(deltaScrollWheel) / deltaScrollWheel) * 2; 
            }

            //mouseCurrent.MiddleButton
            if (MouseButtonIsPressed("MiddleButton"))
            {
                theGrid.Origin = mouseCurrent.Position.ToVector2(); 
            }

            // Toggle Drawing Lines
            if (IsKeyPressed(Keys.Q))
            {
                theGrid.isDrawingLines = !theGrid.isDrawingLines; 
            }

            // Toggle Drawing Divison Lines
            if (IsKeyPressed(Keys.W))
            {
                theGrid.isDrawingDivsions = !theGrid.isDrawingDivsions;
            }

            // Toggle Drawing Axis Lines
            if (IsKeyPressed(Keys.E))
            {
                theGrid.IsDrawingAxis = !theGrid.IsDrawingAxis;
            }

            // Move Point to check in Triangle
            if (IsKeyPressed(Keys.A))
            {
                
            }

            // Move Point A on Triangle
            if (IsKeyPressed(Keys.S))
            {

            }

            // Move Point B on Triangle
            if (IsKeyPressed(Keys.D))
            {

            }

            // Move Point C on Triangle
            if (IsKeyPressed(Keys.F))
            {

            }

            // Toggle Showing Controls
            if (IsKeyPressed(Keys.Tab))
            {

            }

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        //protected override void Draw(GameTime gameTime)
        //{
        //    GraphicsDevice.Clear(clearColor);

        //    spriteBatch.Begin();

            

        //    theGrid.Draw(spriteBatch);

        //    spriteBatch.End();

        //    base.Draw(gameTime);
        //}
    }
}
