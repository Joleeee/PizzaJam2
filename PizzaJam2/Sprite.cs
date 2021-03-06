﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaJam2
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

		public virtual void Animate(bool animate)
		{
			if (animate && frames > 1)
			{
				int frame = time / frameTime;
				frame = frame % frames;
				current = new Rectangle(start.X + start.Width * frame, start.Y, start.Width, start.Height);
				time++;	
			}
		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, position, current, Color.White);
		}

		public static bool Overlap(Sprite a, Sprite b)
		{
			int scale = 2;
			Rectangle ar = new Rectangle((a.position * scale).ToPoint(), a.current.Size);
			Rectangle ab = new Rectangle((b.position * scale).ToPoint(), b.current.Size);
			return ar.Intersects(ab);
		}
	}
}
