using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summative
{
    internal class The_Grinch
    {
        private Rectangle _rectangle;
        private Vector2 _speed;
        private Texture2D _texture;
        public The_Grinch(Rectangle rectangle, Vector2 speed, Texture2D texture)
        {
            _rectangle = rectangle;
            _speed = speed;
            _texture = texture;
        }
        public void Move(GraphicsDeviceManager grapics)
        {
            _rectangle.Offset(_speed);
            if (_rectangle.Right > grapics.PreferredBackBufferWidth || _rectangle.Left < 0)
                _speed.X *= -1;
            if (_rectangle.Bottom > grapics.PreferredBackBufferHeight || _rectangle.Top < 0)
                _speed.Y *= -1;
        }

        public void Drawer(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _rectangle, Color.White);
        }
    }
}
