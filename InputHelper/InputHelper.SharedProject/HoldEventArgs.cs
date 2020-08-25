using Microsoft.Xna.Framework;
using System;

namespace InputHelper
{
	public class HoldEventArgs : EventArgs
	{
		public Vector2 Position
		{
			get; set;
		}

		public HoldEventArgs()
		{
		}

		public HoldEventArgs(Vector2 position)
		{
		}
	}
}
