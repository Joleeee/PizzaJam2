using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaJam2
{
	class Tile : Sprite
	{
		public Tile(Vector2 tilePosition, Texture2D texture, Rectangle start, int frames = 1, int frameTime = 1) : base(tilePosition * start.Size.ToVector2(), texture, start, frames, frameTime)
		{
			
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}

		public void Update(bool animate = false)
		{
			if(animate)
				base.Animate(animate);
		}
	}
}
