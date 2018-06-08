using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using System.Linq;

namespace PizzaJam2
{
    class Tilemap : GameObject
    {
		Tile[,] map;
		AutoTile[,] aMap;
		string[,] textMap;

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
			textMap = new string[xSize, lines.Length];
			for (int y = 0; y < lines.Length; y++)
			{
				string[] tiles = lines[y].Split(':');
				for (int x = 0; x < tiles.Length; x++)
				{
					textMap[x, y] = tiles[x];
					Tile tile = null;
					Vector2 tilePos = new Vector2(x, y);
					switch (tiles[x])
					{
						case "1":
							tile = new Tile(tilePos, Texture.Load<Texture2D>("Tiles/dirt_tile"), new Rectangle(0, 0, 8, 8));
							map[x, y] = tile;
							break;
						case "2":
							tile = new Tile(tilePos, Texture.Load<Texture2D>("Tiles/dirt_tile"), new Rectangle(8, 0, 8, 8));
							map[x, y] = tile;
							break;
						default:
							//tile = null;
							break;
					}
				}
			}
			UpdateAutoTiles();
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
			/*int width = aMap.GetLength(0);
			int height = aMap.GetLength(1);
			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					if (aMap[x, y] != null)
					{
						Side[] sides = new Side[(int)Enum.GetValues(typeof(Side)).Cast<Side>().Last()];
						if (x > 0) if (textMap[x - 1, y] != "0") sides[(int)Side.Left] = Side.Left;
						if (x < width) if (textMap[x + 1, y] != "0") sides[(int)Side.Right] = Side.Right;
						if (y > 0) if (textMap[x, y - 1] != "0") sides[(int)Side.Up] = Side.Up;
						if (y < height) if (textMap[x, y + 1] != "0") sides[(int)Side.Down] = Side.Down;
						if (x > 0 && y > 0) if (textMap[x - 1, y - 1] != "0") sides[(int)Side.TopLeftCorner] = Side.TopLeftCorner;
						if (x > 0 && y < width) if (textMap[x - 1, y + 1] != "0") sides[(int)Side.BottomLeftCorer] = Side.BottomLeftCorer;
						if (x < width && y > 0) if (textMap[x + 1, y - 1] != "0") sides[(int)Side.TopRightCorner] = Side.TopRightCorner;
						if (x > 0 && y > 0) if (textMap[x + 1, y + 1] != "0") sides[(int)Side.BottomRightCorner] = Side.BottomRightCorner;
						aMap[x, y].UpdateTile(sides);
					}
				}
			}*/
		}
	}
}
