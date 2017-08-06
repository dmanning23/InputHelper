using System;

namespace InputHelper
{
	/// <summary>
	/// This is an item that can respond to drag-drop operations
	/// </summary>
	public interface IDroppable
	{
		event EventHandler<DropEventArgs> OnDrop;

		/// <summary>
		/// Check if something was dropped into this container
		/// </summary>
		/// <param name="drag">the drop operation being performed</param>
		/// <returns>bool: true if this item was dropped in, false if not</returns>
		bool CheckDrop(DropEventArgs drop);
	}
}