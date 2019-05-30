using Microsoft.Xna.Framework;
using System;

namespace InputHelper
{
	public class PinchEventArgs : EventArgs
	{
		/// <summary>
		/// The amount of change since last update
		/// </summary>
		public float Delta
		{
			get; set;
		}

		public PinchEventArgs()
		{
		}

		public PinchEventArgs(float delta)
		{
			Delta = delta;
		}
	}
}
