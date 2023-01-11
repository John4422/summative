using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace summative.Sprites
{
    public class Player : Sprites 
    {
        public Player(Texture2D texture) 
            : base(texture)
        {

        }

        public void Update(GameTime gameTime, List<Sprites> sprites, Input input)
        {
            Move();

            foreach (var sprite in sprites)
            {
                if(sprite == this)
                    continue;

                if((this.Velocity.X > 0 && this.IsTouchingLeft(sprite)) || 
                   (this.Velocity.X < 0 && this.IsTouchingRight(sprite)))
                    this.Velocity.X = 0;

                if ((this.Velocity.Y > 0 && this.IsTouchingTop(sprite)) ||
                    ((this.Velocity.Y < 0 && this.IsTouchingBottom(sprite))))
                    this.Velocity.Y = 0;

                Postion += Velocity;

                Velocity = Vector2.Zero;
            }
        }

        
            public void Move()
            {
                if (Keyboard.GetState().IsKeyDown(input.Left))
                    Velocity.X = speed;
                else if (Keyboard.GetState().IsKeyDown(input.Right))
                    Velocity.X = speed;

                if (Keyboard.GetState().IsKeyDown(input.up))
                    Velocity.Y = speed;
                else if (Keyboard.GetState().IsKeyDown(input.Down))
                    Velocity.Y = speed;
            }


        
        
    }
}
