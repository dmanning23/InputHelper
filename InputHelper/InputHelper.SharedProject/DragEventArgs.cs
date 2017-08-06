using Microsoft.Xna.Framework;
using System;

namespace InputHelper
{
	/// <summary>
	/// Currently in the middle of a drag drop event
	/// </summary>
	public class DragEventArgs : EventArgs
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
		/// the current screen location
		/// </summary>
		public Vector2 Current
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

		/// <summary>
		/// which button was clicked
		/// </summary>
		public MouseButton Button
		{
			get; set;
		}

		#endregion //Fields

		#region Methods

		public DragEventArgs()
		{
		}

		public DragEventArgs(Vector2 start, Vector2 current, Vector2 delta, MouseButton button)
		{
			Start = start;
			Current = current;
			Delta = delta;
			Button = button;
		}

		#endregion //Methods
	}
}