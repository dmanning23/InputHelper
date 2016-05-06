using Microsoft.Xna.Framework;
using System;

namespace InputHelper
{
	/// <summary>
	/// User clicked a mouse button
	/// </summary>
	public class ClickEventArgs : EventArgs
	{
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
	}
}