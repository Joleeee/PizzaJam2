using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaJam2
{
	public enum Side { Up, Down, Left, Right, TopLeftCorner, TopRightCorner, BottomLeftCorer, BottomRightCorner };
	class AutoTile : Tile
	{
		Point size;
		Texture2D overlayTexture;
		int[] overlays = new int[(int)Enum.GetValues(typeof(Side)).Cast<Side>().Last()];
		
		public AutoTile(Vector2 tilePosition, Texture2D texture, Texture2D overlayTexture, Rectangle start, int frames = 1, int frameTime = 1) : base(tilePosition * start.Size.ToVector2(), texture, start, frames, frameTime)
		{
			size = start.Size;
			this.overlayTexture = overlayTexture;
		}
		Rectangle GetOverlay(Side s)
		{
			int x = start.X;
			int y = 0;
			switch (s)
			{
				case Side.Up:
					x += size.X * 1;
					break;
				case Side.Down:
					x += size.X * 2;
					break;
				case Side.Left:
					x += size.X * 3;
					break;
				case Side.Right:
					x += size.X * 4;
					break;
				case Side.TopLeftCorner:
					x += size.X * 5;
					break;
				case Side.TopRightCorner:
					x += size.X * 6;
					break;
				case Side.BottomLeftCorer:
					x += size.X * 7;
					break;
				case Side.BottomRightCorner:
					x += size.X * 8;
					break;
				default:
					throw new ArgumentOutOfRangeException("Out of range!");
					break;
			}

			return new Rectangle(new Point(x, y), size);
		}
		
		public void UpdateTile(Side[] sides)
		{
			overlays = new int[(int)Enum.GetValues(typeof(Side)).Cast<Side>().Last()];
			foreach (Side s in sides)
			{
				overlays[(int)s] = (int)s * size.Y;
			}
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
			foreach (int y in overlays)
			{
				spriteBatch.Draw(overlayTexture, position, new Rectangle(0, y, size.X, size.Y), Color.White);
			}
		}
	}
}
