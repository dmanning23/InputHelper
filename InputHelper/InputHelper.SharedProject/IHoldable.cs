
using System;

namespace InputHelper
{
	/// <summary>
	/// This is an item that can be held
	/// When a user touches a single point for a second or more (only fires once)
	/// </summary>
	public interface IHoldable
	{
		bool Holdable { get; set; }

		bool IsHeld { get; set; }

		event EventHandler<HoldEventArgs> OnHold;

		bool CheckHold(HoldEventArgs hold);
	}
}