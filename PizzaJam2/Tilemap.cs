using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Linq;

namespace PizzaJam2
{
    class Tilemap : GameObject
    {
		Tile[,] map;

		Point tileSize = new Point(8,8);

		public Tilemap(string path, bool autoDraw = true)
		{
			string[] lines = File.ReadAllLines(path);
			var xSize = 0;
			for (int i = 0; i < lines.Length; i++)
				if (lines[i].Count(x => x == ':') + 1 > xSize)
					xSize = lines[i].Count(x => x == ':') + 1;


			map = new Tile[xSize, lines.Length];
			for (int y = 0; y < lines.Length; y++)
			{
				string[] tiles = lines[y].Split(':');
				for (int x = 0; x < tiles.Length; x++)
				{
					Tile tile;
					Vector2 tilePos = new Vector2(x, y);
					switch (tiles[x])
					{
						case "1":
							tile = new Tile(tilePos, Texture.Load<Texture2D>("tileset"), new Rectangle(0, 0, 8, 8), 2, 60);
							break;
						case "2":
							tile = new Tile(tilePos, Texture.Load<Texture2D>("tileset"), new Rectangle(8, 0, 8, 8));
							break;
						default:
							tile = null;
							break;
					}
					if (tile != null)
						map[x, y] = tile;
					else
						map[x, y] = null;
				}
			}
		}
		
		public void Update()
		{
			for (int x = 0; x < map.GetLength(0); x++)
			{
				for (int y = 0; y < map.GetLength(1); y++)
				{
					if (map[x, y] != null)
						map[x, y].Update(true);
				}
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			for (int x = 0; x < map.GetLength(0); x++)
			{
				for (int y = 0; y < map.GetLength(1); y++)
				{
					if (map[x, y] != null)
						map[x, y].Draw(spriteBatch);
				}
			}
		}
	}
}
