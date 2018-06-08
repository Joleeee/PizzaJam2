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
		public Player(Vector2 startPosition) : base(startPosition, Texture.Load<Texture2D>("player"), new Rectangle(0, 0, 16, 32))
		{
			
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
