using Microsoft.Xna.Framework;
using System;

namespace InputHelper
{
	public class HighlightEventArgs : EventArgs
	{
		#region Fields

		public Vector2 Position { get; set; }

		#endregion //Fields

		#region Methods

		public HighlightEventArgs()
		{
		}

		public HighlightEventArgs(Vector2 position)
		{
			Position = position;
		}

		#endregion //Methods
	}
}