using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaJam2
{
	class Tileset : GameObject
	{
		Texture2D texture;
		Point dimentions;
		int time = 0;

		public Texture2D[] Textures = new Texture2D[128];
		public Rectangle[] Rectangles = new Rectangle[128];
		public int[] Frames = new int[128];
		public int[] FrameTimes = new int[128];
		//public Dictionary<int, Texture2D> Textures = new Dictionary<int, Texture2D>();

		public Tileset()
        {
			
        }

		//public Tile GetTile(int id, Vector2 position)
		//{
		//	return new Tile(id, position, Textures[id], Rectangles[id], Frames[id], FrameTimes[id]);
		//}

		public void Add(int id, Texture2D texture, Rectangle start, int frames = 1, int frameTimes = 1)
		{
			Textures[id] = texture;
			Rectangles[id] = start;
			Frames[id] = frames;
			FrameTimes[id] = frameTimes;
		}
    }
}
