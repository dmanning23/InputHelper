using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace InputHelper
{
	/// <summary>
	/// This is an interface for managing highlighting and selection of items based on user input
	/// </summary>
	public interface IInputHelper
	{
		/// <summary>
		/// A list of all the clicks that occured during the last update.
		/// </summary>
		List<ClickEventArgs> Clicks
		{
			get;
		}

		/// <summary>
		/// A list of all the highlight events that occured during the last update.
		/// </summary>
		List<HighlightEventArgs> Highlights
		{
			get;
		}

		/// <summary>
		/// A list of all the drag events that are currently occuring during the last update.
		/// </summary>
		List<DragEventArgs> Drags
		{
			get;
		}

		/// <summary>
		/// A list of all the drop events that occured during the last update.
		/// </summary>
		List<DropEventArgs> Drops
		{
			get;
		}
	}
}