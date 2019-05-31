using System;

namespace InputHelper
{
	/// <summary>
	/// This is an item that can be flicked
	/// </summary>
	public interface IFlickable
	{
		bool Flickable { get; set; }

		bool IsFlicked { get; set; }

		event EventHandler<FlickEventArgs> OnFlick;

		bool CheckFlick(FlickEventArgs flick);
	}
}