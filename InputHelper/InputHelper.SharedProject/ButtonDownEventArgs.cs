using Microsoft.Xna.Framework;
using System;

namespace InputHelper
{
	/// <summary>
	/// User is holding down a mouse button
	/// </summary>
	public class ButtonDownEventArgs : EventArgs
	{
		#region Fields

		/// <summary>
		/// the screen location where the mouse cursor is being held
		/// </summary>
		public Vector2 Position
		{
			get; set;
		}

		/// <summary>
		/// which button is held
		/// </summary>
		public MouseButton Button
		{
			get; set;
		}

		#endregion //Fields

		#region Methods

		public ButtonDownEventArgs()
		{
		}

		public ButtonDownEventArgs(Vector2 position, MouseButton button)
		{
			Position = position;
			Button = button;
		}

		#endregion //Methods
	}
}