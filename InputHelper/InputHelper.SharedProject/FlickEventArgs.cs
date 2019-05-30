using Microsoft.Xna.Framework;
using System;

namespace InputHelper
{
	public class FlickEventArgs : EventArgs
	{
		public Vector2 Position
		{
			get; set;
		}

		/// <summary>
		/// The amount of change since last update
		/// </summary>
		public Vector2 Delta
		{
			get; set;
		}

		public FlickEventArgs()
		{
		}

		public FlickEventArgs(Vector2 position, Vector2 delta)
		{
			Position = position;
			Delta = delta;
		}
	}
}
