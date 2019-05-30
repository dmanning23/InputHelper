using Microsoft.Xna.Framework;
using System;

namespace InputHelper
{
	/// <summary>
	/// User clicked a mouse button
	/// </summary>
	public class ClickEventArgs : EventArgs
	{
		#region Fields

		/// <summary>
		/// the screen location of this mouse click
		/// </summary>
		public Vector2 Position
		{
			get; set;
		}

		/// <summary>
		/// which button was clicked
		/// </summary>
		public MouseButton Button
		{
			get; set;
		}

		/// <summary>
		/// Gets the index of the player who triggered this event.
		/// </summary>
		public PlayerIndex? PlayerIndex { get; set; }

		public bool DoubleClick { get; set; } = false;

		#endregion //Fields

		#region Methods

		public ClickEventArgs()
		{
		}

		public ClickEventArgs(Vector2 position, MouseButton button, PlayerIndex? playerIndex)
		{
			Position = position;
			Button = button;
			PlayerIndex = playerIndex;
		}

		#endregion //Methods
	}
}