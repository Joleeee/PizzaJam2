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
		public Player(Vector2 startPosition) : base(startPosition, Texture.Load<Texture2D>("Sprites/Old"), new Rectangle(0, 0, 28, 32))
		{
            start = new Rectangle(0, 0, 7, 8);
		}

		public void Update(bool animate, Tilemap tm)
		{
			Vector2 move = new Vector2(0, 0);
			if (Input.IsDown(Keys.Right))
			{
				move.X++;
			}
			if (Input.IsDown(Keys.Left))
			{
				move.X--;
			}

			position += move;

			base.Animate(animate);
		}
	}
}
