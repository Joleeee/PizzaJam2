using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaJam2
{
	public class Texture
	{
		public static ContentManager Content;
		public static T Load<T>(string assetName)
		{
			return Content.Load<T>(assetName);
		}

		public static Point Animate(Point start, int width, int time, int frames, int frameTime)
		{
			int x = time % frameTime;
			x -= x % frames;
			x *= width;
			start.X += x;
			return start;
		}
	}
}
