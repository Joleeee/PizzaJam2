using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaJam2
{
	class Player : Sprite
	{
		public Player(Vector2 startPosition) : base(startPosition, Texture.Load<Texture2D>("Sprites/Old"), new Rectangle(0, 8, 7, 8), 4, 7)
		{
		}

		public void Update(bool animate, Tilemap tm)
		{
			Vector2 move = new Vector2(0, 0);
			if (Input.IsDown(Keys.Right))
			{
				move.X+=0.5f;
                start.Y = current.Height;
                animate = true;
			}else if (Input.IsDown(Keys.Left))
			{
				move.X-=0.5f;
                start.Y = texture.Height/2+current.Height;
                animate = true;
            }else
            {
                if (current.Y == current.Height) current.Y = 0;
                else if (current.Y == texture.Height / 2 + current.Height) current.Y = texture.Height / 2;
                current.X = 0;
            }

			position += move;

			base.Animate(animate);
		}
	}
}
