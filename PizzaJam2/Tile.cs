using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaJam2
{
	class Tile
	{
		public int id;
		public Point start;
		public Point current;
		public Point size;
		public bool isAnimated;
		public int frames;
		public int frameTime;
		public int time = 0;

		/// <param name="frameTime">In frames</param>
		public Tile(int id, Point start, Point size, int frames = 1, int frameTime = 0)
		{
			this.id = id;
			this.start = start;
			this.current = start;
			this.size = size;
			this.frames = frames;
			this.frameTime = 0;
			this.isAnimated = (frames != 1 || frameTime != 0);
		}

		public void Draw(SpriteBatch spriteBatch, Tileset tileset)
		{
			//spriteBatch
		}

		public Point Animate(int time)
		{
			return Texture.Animate(start, size.X, time, 2, 5);
		}
	}
}
