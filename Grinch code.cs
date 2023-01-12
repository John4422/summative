using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using summative.Sprites;
using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Threading;

namespace summative
{
    public class Game1 : Game
    {
        

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Rectangle position;
        Vector2 velocity;
        Rectangle position2;
        Vector2 velocity2;
        Vector2 pause;
        Texture2D grinTexture;
        Texture2D grinndog;
        Rectangle grinndogRect;
        Rectangle grinRect;
        MouseState mousestate;
        Texture2D Krumpit;
        Song UrMean;
        Song Welcome;
        Screen screen;
        enum Screen
        {
            intro,
            anamate,
            
        }
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screen = Screen.intro;
            velocity = new Vector2 (0,3);
            velocity2 = new Vector2 (3,0);
            position = new Rectangle(155, 390, 0, 0);
            position2 = new Rectangle(551, 390, 0, 0);
            pause = new Vector2(0,0);
            grinndogRect = new Rectangle(120, 80, 80 ,80);
            grinRect = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            grinTexture = Content.Load<Texture2D>("The-Grinch background");
            grinndog = Content.Load<Texture2D>("Grinch-and-dog");
            Krumpit = Content.Load<Texture2D>("Mt.-Krumpit");
            Welcome = Content.Load<Song>("Welcome.Mp3");
            UrMean = Content.Load<Song>("Y2Mate.is - You're a Mean One, Mr Grinch _ Dr Seuss-3Hj3U18FHgQ-96k-1657043497269");
        }

        protected override void Update(GameTime gameTime)
        {

            mousestate = Mouse.GetState();
            this.Window.Title = mousestate.X.ToString() + "'" + mousestate.Y.ToString();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (screen == Screen.intro)
            {
                if (mousestate.LeftButton == ButtonState.Pressed)
                    screen = Screen.anamate;
            }
            else if (screen == Screen.anamate)
            {
                
            }

            if (mousestate.LeftButton == ButtonState.Pressed)
            {
                MediaPlayer.Play(UrMean);
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            
            if (screen == Screen.intro)
            {
                _spriteBatch.Draw(grinTexture, grinRect, Color.White);
                _spriteBatch.Draw(grinTexture, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.White);
            }
            else if (screen == Screen.anamate)
            {
                if (grinndogRect.Y < 390)
                {
                    grinndogRect.Y += 2;
                }
                if (grinndogRect.Y >= 390)
                {
                    grinndogRect.X += 2;
                }
                if (grinndogRect.X >= 444)
                {
                    MediaPlayer.Stop();
                    MediaPlayer.Play(Welcome);
                    grinndogRect.X = 444;
                }
                _spriteBatch.Draw(Krumpit, new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight), Color.White);
                _spriteBatch.Draw(grinndog, grinndogRect, Color.White);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}