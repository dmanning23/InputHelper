using System;

namespace InputHelper
{
	public class PinchEventArgs : EventArgs
	{
		/// <summary>
		/// True if the pinch is a "release" action
		/// </summary>
		public bool Release { get; set; }

		/// <summary>
		/// The amount of change since last update
		/// </summary>
		public float Delta
		{
			get; set;
		}

		public PinchEventArgs()
		{
			Release = false;
		}

		public PinchEventArgs(float delta) : this()
		{
			Delta = delta;
		}
	}
}
