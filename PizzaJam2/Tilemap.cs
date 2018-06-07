using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Linq;

namespace TilesetLibrary
{
    class Tilemap : GameObject
    {
		int[,] map;
		Tileset TS;

		public Tilemap(Tileset Tileset, string path, bool autoDraw = true)
		{
			TS = Tileset;
			string[] lines = File.ReadAllLines(path);
			var xSize = 0;
			for (int i = 0; i < lines.Length; i++)
				if (lines[i].Count(x => x == ':') + 1 > xSize)
					xSize = lines[i].Count(x => x == ':') + 1;


			map = new int[xSize, lines.Length];
			for (int y = 0; y < lines.Length; y++)
			{
				string[] tiles = lines[y].Split(':');
				for (int x = 0; x < tiles.Length; x++)
				{
					int val = int.Parse(tiles[x]);
					map[x, y] = val;
				}
			}
		}

		public bool Overlap()
		{
			for (int x = 0; x < map.GetLength(0); x++)
			{
				for (int y = 0; y < map.GetLength(1); y++)
				{
					//Rectangle tileRect = new Rectangle(x * TS.Textures[map[x,y]].Bounds)
				}
			}
		}

		public void Update()
		{
			TS.Update();
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			for (int x = 0; x < map.GetLength(0); x++)
			{
				for (int y = 0; y < map.GetLength(1); y++)
				{
					int id = map[x, y];
					if (id != 0)
					{
						Point start = TS.Tiles[id].current;
						Point size = TS.Tiles[id].size;
						Texture2D tex = TS.Textures[id];
						spriteBatch.Draw(tex, new Vector2(x*size.X, y*size.Y), new Rectangle(start, size), Color.White);
					}
				}
			}
		}
	}
}
