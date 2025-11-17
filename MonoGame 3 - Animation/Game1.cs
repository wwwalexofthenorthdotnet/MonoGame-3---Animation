using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace MonoGame_3___Animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        Texture2D tribbleBrownTexture;
        Texture2D tribbleCreamTexture;
        Texture2D tribbleGreyTexture;
        Texture2D tribbleOrangeTexture;
        Texture2D quitTexture;

        Rectangle tribbleBrown;
        Rectangle tribbleCream;
        Rectangle tribbleGrey;
        Rectangle tribbleOrange;
        Rectangle quit;

        Vector2 tribbleBrownSpeed;
        Vector2 tribbleCreamSpeed;
        Vector2 tribbleGreySpeed;
        Vector2 tribbleOrangeSpeed;

        int randomColor;
        int tribbleBrownX;
        int tribbleBrownY;
        int tribbleCreamX;
        int tribbleCreamY;
        int tribbleGreyX;
        int tribbleGreyY;
        int tribbleOrangeX;
        int tribbleOrangeY;
        int tribbleBrownSize = 100;

        List<Color> BGColors = new List<Color> { Color.Black, Color.Green, Color.Coral, Color.Orange, Color.AliceBlue };
        

        Random generator = new Random();

        MouseState mouseState;
        MouseState prevMouseState;

        


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            tribbleBrownX = generator.Next(window.Width - 100);
            tribbleBrownY = generator.Next(window.Height - 100);
            tribbleCreamX = generator.Next(window.Width - 100);
            tribbleCreamY = generator.Next(window.Height - 100);
            tribbleGreyX = generator.Next(window.Width - 100);
            tribbleGreyY = generator.Next(window.Height - 100);
            tribbleOrangeX = generator.Next(window.Width - 100);
            tribbleOrangeY = generator.Next(window.Height - 100);

            quit = new Rectangle(0, 0, 200, 50);

            tribbleBrown = new Rectangle(tribbleBrownX, tribbleBrownY, tribbleBrownSize, tribbleBrownSize);
            tribbleBrownSpeed = new Vector2(2, 1);

            tribbleCream = new Rectangle(tribbleCreamX, tribbleCreamY, 100, 100);
            tribbleCreamSpeed = new Vector2(-2, -1);

            tribbleGrey = new Rectangle(tribbleGreyX, tribbleGreyY, 100, 100);
            tribbleGreySpeed = new Vector2(3, 2);

            tribbleOrange = new Rectangle(tribbleOrangeX, tribbleOrangeY, 100, 100);
            tribbleOrangeSpeed = new Vector2(-3, -1);

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here


            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            quitTexture = Content.Load<Texture2D>("quit");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            
            prevMouseState = mouseState;
            mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
            {
                if (quit.Contains(mouseState.Position))
                Exit();
            }

            tribbleBrown.X += (int)tribbleBrownSpeed.X;
            tribbleBrown.Y += (int)tribbleBrownSpeed.Y;

            if (tribbleBrown.Right > window.Width || tribbleBrown.Left < 0)
            {
                tribbleBrownSpeed.X *= -1;
            }

            if (tribbleBrown.Bottom > window.Height || tribbleBrown.Top < 0)
            {
                tribbleBrownSpeed.Y *= -1;
            }

            tribbleCream.X += (int)tribbleCreamSpeed.X;
            tribbleCream.Y += (int)tribbleCreamSpeed.Y;


            if (tribbleCream.Right > window.Width || tribbleCream.Left < 0)
                tribbleCreamSpeed.X *= -1;

            if (tribbleCream.Bottom > window.Height || tribbleCream.Top < 0)
                tribbleCreamSpeed.Y *= -1;

            tribbleGrey.X += (int)tribbleGreySpeed.X;
            tribbleGrey.Y += (int)tribbleGreySpeed.Y;

            if (tribbleGrey.Right > window.Width || tribbleGrey.Left < 0)
            {
                tribbleGreySpeed.X *= -1;
                randomColor = generator.Next(BGColors.Count);
                if (randomColor == randomColor)
                    randomColor = generator.Next(BGColors.Count);
            }

            if (tribbleGrey.Bottom > window.Height || tribbleGrey.Top < 0)
            {
                tribbleGreySpeed.Y *= -1;
                randomColor = generator.Next(BGColors.Count);
                if (randomColor == randomColor)
                    randomColor = generator.Next(BGColors.Count);
            }


            tribbleOrange.X += (int)tribbleOrangeSpeed.X;
            tribbleOrange.Y += (int)tribbleOrangeSpeed.Y;

            if (tribbleOrange.Right > window.Width || tribbleOrange.Left < 0)
                tribbleOrangeSpeed.X *= -1;

            if (tribbleOrange.Bottom > window.Height || tribbleOrange.Top < 0)
                tribbleOrangeSpeed.Y *= -1;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(BGColors[randomColor]);
            

                // TODO: Add your drawing code here

                _spriteBatch.Begin();


            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrown, Color.White);
            _spriteBatch.Draw(tribbleCreamTexture, tribbleCream, Color.White);
            _spriteBatch.Draw(tribbleGreyTexture, tribbleGrey, Color.White);
            _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrange, Color.White);
            _spriteBatch.Draw(quitTexture, quit, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);

        }
    }
}
