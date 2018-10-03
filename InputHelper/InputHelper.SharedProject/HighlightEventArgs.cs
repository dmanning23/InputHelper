using Microsoft.Xna.Framework;
using System;

namespace InputHelper
{
	public class HighlightEventArgs : EventArgs
	{
		#region Fields

		public Vector2 Position { get; set; }

		public IInputHelper InputHelper { get; set; }

		#endregion //Fields

		#region Methods

		public HighlightEventArgs(IInputHelper inputHelper)
		{
			InputHelper = inputHelper;
		}

		public HighlightEventArgs(Vector2 position, IInputHelper inputHelper) : this(inputHelper)
		{
			Position = position;
		}

		#endregion //Methods
	}
}