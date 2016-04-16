using Microsoft.Xna.Framework;
using System;

namespace InputHelper
{
	/// <summary>
	/// After a drag event event ends, there is a drop event.
	/// </summary>
	public class DropEventArgs : EventArgs
	{
		/// <summary>
		/// where the drag event started
		/// </summary>
		public Vector2 Start
		{
			get; set;
		}

		/// <summary>
		/// where the drag event ended
		/// </summary>
		public Vector2 Drop
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
	}
}