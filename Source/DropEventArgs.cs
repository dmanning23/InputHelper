using Microsoft.Xna.Framework;
using System;

namespace InputHelper
{
	/// <summary>
	/// After a drag event event ends, there is a drop event.
	/// </summary>
	public class DropEventArgs : EventArgs
	{
		#region Fields

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

		#endregion //Fields

		#region Methods

		public DropEventArgs()
		{
		}

		public DropEventArgs(Vector2 start, Vector2 drop, MouseButton button)
		{
			Start = start;
			Drop = drop;
			Button = button;
		}

		#endregion //Methods
	}
}