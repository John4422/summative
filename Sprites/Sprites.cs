using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summative.Sprites
{
    public class Sprites
    {
        protected Texture2D _texture;

        public Vector2 Postion;
        public Vector2 Velocity;
        public float speed;
        public Input input;

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Postion.X, (int)Postion.Y, _texture.Width, _texture.Height);
            }
        }

        public Sprites(Texture2D texture)
        {
            _texture = texture;
        }

        public virtual void Update(GameTime gameTime, List <Sprites> sprites)
        { }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Postion, Color.White);
        }

        #region Collsion 
        protected bool IsTouchingLeft(Sprites sprites)
        {
            return this.Rectangle.Right + this.Velocity.X > sprites.Rectangle.Left &&
                this.Rectangle.Left < sprites.Rectangle.Left &&
                this.Rectangle.Bottom > sprites.Rectangle.Top &&
                this.Rectangle.Top < sprites.Rectangle.Bottom;   
        }

        protected bool IsTouchingRight(Sprites sprites)
        {
            return this.Rectangle.Left + this.Velocity.X < sprites.Rectangle.Right &&
                this.Rectangle.Right > sprites.Rectangle.Right &&
                this.Rectangle.Bottom > sprites.Rectangle.Top &&
                this.Rectangle.Top < sprites.Rectangle.Bottom;
        }

        protected bool IsTouchingTop(Sprites sprites)
        {
            return this.Rectangle.Bottom + this.Velocity.Y > sprites.Rectangle.Top &&
                this.Rectangle.Top < sprites.Rectangle.Top &&
                this.Rectangle.Right > sprites.Rectangle.Left &&
                this.Rectangle.Left < sprites.Rectangle.Right;
        }

        protected bool IsTouchingBottom(Sprites sprites)
        {
            return this.Rectangle.Top + this.Velocity.Y < sprites.Rectangle.Bottom &&
                this.Rectangle.Bottom > sprites.Rectangle.Bottom &&
                this.Rectangle.Right > sprites.Rectangle.Left &&
                this.Rectangle.Left < sprites.Rectangle.Right;
        }
        #endregion
    }
}
