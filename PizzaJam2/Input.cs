using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaJam2
{
	class Input
	{
		public static bool IsDown(Keys key)
		{
			return Keyboard.GetState().IsKeyDown(key);
		}
	}
}