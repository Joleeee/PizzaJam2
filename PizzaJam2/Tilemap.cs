using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.Linq;

namespace PizzaJam2
{
    class Tilemap : GameObject
    {
		Tile[,] map;
		AutoTile[,] aMap;

		Point tileSize = new Point(8,8);

		public Tilemap(string path, bool autoDraw = true)
		{
			string[] lines = File.ReadAllLines(path);
			var xSize = 0;
			for (int i = 0; i < lines.Length; i++)
				if (lines[i].Count(x => x == ':') + 1 > xSize)
					xSize = lines[i].Count(x => x == ':') + 1;


			map = new Tile[xSize, lines.Length];
			aMap = new AutoTile[xSize, lines.Length];
			for (int y = 0; y < lines.Length; y++)
			{
				string[] tiles = lines[y].Split(':');
				for (int x = 0; x < tiles.Length; x++)
				{
					Vector2 tilePos = new Vector2(x, y);
					switch (tiles[x])
					{
						case "1":
							AutoTile tile = new AutoTile(tilePos, Texture.Load<Texture2D>("Tiles/dirt_tile"), Texture.Load<Texture2D>("Tiles/dirt_overlay"), new Rectangle(0, 0, 8, 8), 2, 60);
							aMap[x, y] = tile;
							break;
						case "2":
							////tile = new Tile(tilePos, Texture.Load<Texture2D>("tileset"), new Rectangle(8, 0, 8, 8), 2, 60);
							break;
						default:
							tile = null;
							break;
					}
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
					if (aMap[x, y] != null)
						aMap[x, y].Update(true);
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
					if (aMap[x, y] != null)
						aMap[x, y].Draw(spriteBatch);
				}
			}
		}

		void UpdateAutoTiles()
		{
			for (int x = 0; x < aMap.GetLength(0); x++)
			{
				for (int y = 0; y < aMap.GetLength(1); y++)
				{
					bool up = aMap[x, y - 1] != null;
					bool down = aMap[x, y + 1 != null;
					if (map[x, y] != null)
						map[x, y].Draw(spriteBatch);
				}
			}
		}
	}
}
