using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TilesetLibrary
{
    class Tileset : GameObject
	{
        Texture2D texture;
        Point dimentions;
		int time = 0;

		public Dictionary<int, Tile> Tiles = new Dictionary<int, Tile>();
		public Dictionary<int, Texture2D> Textures = new Dictionary<int, Texture2D>();

		public Tileset()
        {
			
        }

		public void Update()
		{
			time++;
			foreach (Tile t in Tiles.Values)
			{
				t.Animate(time);
			}
		}

		public void Add(int id, Texture2D sheet, Point start, Point size)
		{
			Tiles.Add(id, new Tile(id, start, size));
			Textures.Add(id, sheet);
		}
    }
}
