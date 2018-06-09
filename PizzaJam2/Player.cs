using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaJam2
{
	class Player : Sprite
	{
        Vector2 velocity;
        bool canJump = true;

        Vector2 lastPosition;
		public Player(Vector2 startPosition) : base(startPosition, Texture.Load<Texture2D>("Sprites/Old"), new Rectangle(0, 8, 7, 8), 4, 7)
		{
            velocity = new Vector2(0, 0);
		}

		public void Update(bool animate, Tilemap tm)
		{
            Vector2 move = new Vector2(0, 0);
            velocity.Y += 0.05f;
            move.Y += velocity.Y;

			if (Input.IsDown(Keys.Right))
			{
				move.X+=0.5f;
                start.Y = current.Height;
                animate = true;
			}else if (Input.IsDown(Keys.Left))
			{
				move.X-=0.5f;
                start.Y = texture.Height/2+current.Height;
                animate = true;
            }else
            {
                if (current.Y == current.Height) current.Y = 0;
                else if (current.Y == texture.Height / 2 + current.Height) current.Y = texture.Height / 2;
                current.X = 0;
            }

			position += move;

            if (Input.IsDown(Keys.Up) && canJump)
            {
                velocity.Y = -1;
                canJump = false;
            }

            for(int i = 0; i < tm.map.GetLength(1); i++)
            {
                for(int x = 0; x < tm.map.GetLength(0); x++)
                {
                    if(tm.map[x,i] != null && new Rectangle((position*new Vector2(2,2)).ToPoint(), current.Size*new Point(2,2)).Intersects(new Rectangle(tm.map[x,i].position.ToPoint() * new Point(2,2), tm.map[x,i].current.Size*new Point(2,2))))
                    {
                        if(new Rectangle((new Vector2(position.X, lastPosition.Y) * new Vector2(2, 2)).ToPoint(), current.Size * new Point(2, 2)).Intersects(new Rectangle(tm.map[x, i].position.ToPoint() * new Point(2, 2), tm.map[x, i].current.Size * new Point(2, 2))))
                        {
                            if (position.X > tm.map[x, i].position.X) position.X = tm.map[x, i].position.X + tm.map[x, i].current.Width;
                            else position.X = tm.map[x, i].position.X - current.Width;
                        }
                        if (new Rectangle((new Vector2(lastPosition.X, position.Y) * new Vector2(2, 2)).ToPoint(), current.Size * new Point(2, 2)).Intersects(new Rectangle(tm.map[x, i].position.ToPoint() * new Point(2, 2), tm.map[x, i].current.Size * new Point(2, 2))))
                        {
                            if (position.Y > tm.map[x, i].position.Y) position.Y = tm.map[x, i].position.Y + tm.map[x, i].current.Height;
                            else
                            {
                                position.Y = tm.map[x, i].position.Y - current.Height;
                                velocity.Y = 0;
                                canJump = true;
                            }
                        }
                    }
                }
            }

			base.Animate(animate);
            lastPosition = position;
		}
	}
}
