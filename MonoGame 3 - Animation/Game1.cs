using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace MonoGame_3___Animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        enum Screen
        {
            Intro,
            TribbleYard,
            End
        }

        Screen screen;

        Rectangle window;

        SpriteFont titleFont;
        SpriteFont subTitleFont;

        Texture2D tribbleBrownTexture;
        Texture2D tribbleCreamTexture;
        Texture2D tribbleGreyTexture;
        Texture2D tribbleOrangeTexture;
        Texture2D quitTexture;
        Texture2D tribbleIntroTexture;

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
          
            screen = Screen.Intro;

            tribbleBrownX = generator.Next(window.Width - 100);
            tribbleBrownY = generator.Next(window.Height - 100);
            tribbleCreamX = generator.Next(window.Width - 100);
            tribbleCreamY = generator.Next(window.Height - 100);
            tribbleGreyX = generator.Next(window.Width - 100);
            tribbleGreyY = generator.Next(window.Height - 100);
            tribbleOrangeX = generator.Next(window.Width - 100);
            tribbleOrangeY = generator.Next(window.Height - 100);


            quit = new Rectangle(0, 0, 200, 50);

            tribbleBrown = new Rectangle(tribbleBrownX, tribbleBrownY, 100, 100);
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
            tribbleIntroTexture = Content.Load<Texture2D>("TribbleIntro");
            titleFont = Content.Load<SpriteFont>("Title");
            subTitleFont = Content.Load<SpriteFont>("SubTitle");

        }

        protected override void Update(GameTime gameTime)
        {
          
            // TODO: Add your update logic here
            
            prevMouseState = mouseState;
            mouseState = Mouse.GetState();

            if (screen == Screen.Intro)
            {
                UpdateIntro();
            }
            if (screen == Screen.TribbleYard)
            {
                UpdateTribbleYard();
            }
            if (screen == Screen.End)
            {
                UpdateEnd();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(BGColors[randomColor]);
            

                // TODO: Add your drawing code here

                _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(tribbleIntroTexture, new Rectangle(0, 0, window.Width, window.Height), Color.White);
                _spriteBatch.DrawString(titleFont, "Tribble Yard", new Vector2(100, 200), Color.White);
                _spriteBatch.DrawString(subTitleFont, "Click to Start", new Vector2(250, 300), Color.White);

            }
            if (screen == Screen.TribbleYard)
            {
                _spriteBatch.Draw(tribbleBrownTexture, tribbleBrown, Color.White);
                _spriteBatch.Draw(tribbleCreamTexture, tribbleCream, Color.White);
                _spriteBatch.Draw(tribbleGreyTexture, tribbleGrey, Color.White);
                _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrange, Color.White);
                _spriteBatch.Draw(quitTexture, quit, Color.White);
            }
            if (screen == Screen.End)
            {
                _spriteBatch.DrawString(subTitleFont, "Thank You for Playing", new Vector2(150, 200), Color.White);            }
            _spriteBatch.End();

            base.Draw(gameTime);

        }
        public void UpdateIntro()
        {
            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                screen = Screen.TribbleYard;
        }
        public void UpdateTribbleYard()
        {
            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
            {
                if (quit.Contains(mouseState.Position))
                    screen = Screen.End;
            }

            tribbleBrown.X += (int)tribbleBrownSpeed.X;
            tribbleBrown.Y += (int)tribbleBrownSpeed.Y;

            if (tribbleBrown.Left < 0)
            {
                tribbleBrownSpeed.X -= 1;
                tribbleBrownSpeed.X *= -1;
            }

            if (tribbleBrown.Right > window.Width)
            {
                tribbleBrownSpeed.X += 1;
                tribbleBrownSpeed.X *= -1;

            }

            if (tribbleBrown.Top < 0)
            {
                tribbleBrownSpeed.Y -= 1;
                tribbleBrownSpeed.Y *= -1;
            }

            if (tribbleBrown.Bottom > window.Height)
            {
                tribbleBrownSpeed.Y += 1;
                tribbleBrownSpeed.Y *= -1;

            }

            tribbleCream.X += (int)tribbleCreamSpeed.X;
            tribbleCream.Y += (int)tribbleCreamSpeed.Y;


            if (tribbleCream.Right > window.Width || tribbleCream.Left < 0)
            {
                tribbleCreamSpeed.X *= -1;
            }

            if (tribbleCream.Bottom > window.Height || tribbleCream.Top < 0)
            {
                tribbleCreamSpeed.Y *= -1;
            }

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
        }
        public void UpdateEnd()
        {
            if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
            {
                
            }
        }

    }
}
