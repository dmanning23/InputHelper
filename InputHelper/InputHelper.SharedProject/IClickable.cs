using System;

namespace InputHelper
{
	/// <summary>
	/// This is an item that can be highlighted or clicked on.
	/// </summary>
	public interface IClickable
	{
		/// <summary>
		/// Even though this is a IClickable object, sometimes you just don't want them to be clicked.
		/// </summary>
		bool Clickable { get; set; }

		/// <summary>
		/// True if this thing has been clicked recently
		/// </summary>
		bool IsClicked { get; set; }

		/// <summary>
		/// Event that gets called when this thing is clicked
		/// </summary>
		event EventHandler<ClickEventArgs> OnClick;

		/// <summary>
		/// Check if something in this container is highlighted
		/// </summary>
		/// <param name="position">the position that was clicked</param>
		/// <returns>bool: true if this item was clicked in, false if not</returns>
		bool CheckClick(ClickEventArgs click);
	}
}