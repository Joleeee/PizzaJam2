using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilesetLibrary
{
	class Sprite
	{
		public Vector2 position;
		public Texture2D texture;
		public Rectangle start;
		public Rectangle current;
		public int frames;
		public int frameTime;
		public int time;

		public Sprite(Vector2 position, Texture2D texture, Rectangle start, int frames = 1, int frameTime = 1)
		{
			this.position = position;
			this.texture = texture;
			this.start = start;
			this.current = start;
			this.frames = frames;
			this.frameTime = frameTime;
		}

		public void Update(bool animate)
		{
			int frame = time % frames;
			current = new Rectangle(start.X += start.X * frame, start.Y, start.Width, start.Height);
			time++;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, position, current, Color.White);
		}
	}
}
