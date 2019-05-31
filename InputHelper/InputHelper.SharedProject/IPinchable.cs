using System;

namespace InputHelper
{
	/// <summary>
	/// This is an item that can be pinched.
	/// </summary>
	public interface IPinchable
	{
		bool Pinchable { get; set; }

		bool IsPinched { get; set; }

		event EventHandler<PinchEventArgs> OnPinch;

		bool CheckPinch(PinchEventArgs pinch);
	}
}