﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;

namespace PizzaJam2
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
		RenderTarget2D RenderTarget;

		int scale = 1; //dont change!

		Point pixelRes = new Point(384/4, 216/4);
		Player player;

		Tilemap main;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferWidth = pixelRes.X * 12;
			graphics.PreferredBackBufferHeight = pixelRes.Y * 12;
			
            Content.RootDirectory = "Content";

			Window.AllowUserResizing = true;

			//ToggleFullscreen();
		}

		protected override void Initialize()
        {
			Texture.Content = Content;
			//Tileset TS = new Tileset();
			//TS.Add(1, Texture.Load<Texture2D>("tileset"), new Rectangle(0, 0, 8, 8));
			//TS.Add(2, Texture.Load<Texture2D>("tileset"), new Rectangle(0, 8, 8, 8));
			main = new Tilemap(@"Content\Maps\map.txt");
			base.Initialize();
        }
		
        protected override void LoadContent()
        {
			RenderTarget = new RenderTarget2D(GraphicsDevice, pixelRes.X, pixelRes.Y);
            spriteBatch = new SpriteBatch(GraphicsDevice);
			player = new Player(new Vector2(50, 20));
        }
		
        protected override void UnloadContent()
        {
			RenderTarget.Dispose();
			spriteBatch.Dispose();
        }
       
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

			if (Keyboard.GetState().IsKeyDown(Keys.F))
				ToggleFullscreen();

			main.Update();
			player.Update(false, main);

			base.Update(gameTime);
        } 

		protected override bool BeginDraw()
		{
			scale = Math.Min(graphics.PreferredBackBufferWidth / pixelRes.X, graphics.PreferredBackBufferHeight / pixelRes.Y);
			RenderTarget = new RenderTarget2D(RenderTarget.GraphicsDevice, pixelRes.X * scale, pixelRes.Y * scale);
			
			GraphicsDevice.SetRenderTarget(RenderTarget);
			GraphicsDevice.Clear(Color.CornflowerBlue);
			//do draw here
			spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Matrix.CreateScale(scale));
			main.Draw(spriteBatch);
			player.Draw(spriteBatch);
			spriteBatch.End();
			return base.BeginDraw();
		}

		protected override void Draw(GameTime gameTime)
        {
			//dont draw here
			GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Green);
			spriteBatch.Begin(samplerState: SamplerState.PointClamp/*, transformMatrix: Matrix.CreateScale(scale)*/);
			int x = (graphics.PreferredBackBufferWidth - scale * pixelRes.X) / 2;
			int y = (graphics.PreferredBackBufferHeight - scale * pixelRes.Y) / 2;
			Rectangle drawRect = new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
			spriteBatch.Draw(RenderTarget, drawRect, Color.White);
			spriteBatch.End();
            base.Draw(gameTime);
        }

		public static bool Overlap(Rectangle a, Rectangle b)
		{
			int top = Math.Max(a.Top, b.Top);
			int bottom = Math.Min(a.Bottom, b.Bottom);
			int left = Math.Max(a.Left, b.Left);
			int right = Math.Min(a.Right, b.Right);

			if (top >= bottom || left >= right)
				return false;

			return true;
		}

		void ToggleFullscreen()
		{
			bool b = Window.IsBorderless;

			if (b)
			{
				graphics.PreferredBackBufferWidth = pixelRes.X * 4;
				graphics.PreferredBackBufferHeight = pixelRes.Y * 4;
				Window.AllowUserResizing = true;
				Window.IsBorderless = false;
			}
			else
			{
				graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
				graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
				Window.AllowUserResizing = false;
				Window.IsBorderless = true;
			}
			graphics.ApplyChanges();
		}
	}
}
