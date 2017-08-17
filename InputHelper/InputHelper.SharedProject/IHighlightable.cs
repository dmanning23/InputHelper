using System;

namespace InputHelper
{
	/// <summary>
	/// This is an item that can be highlighted.
	/// </summary>
	public interface IHighlightable
	{
		/// <summary>
		/// Even though this is a IHighlightable object, sometimes you just don't want them to be highlighted.
		/// </summary>
		bool Highlightable { get; set; }

		/// <summary>
		/// Highlight or don't highlight this screen item
		/// </summary>
		bool IsHighlighted { get;  set; }

		event EventHandler<HighlightEventArgs> OnHighlight;

		/// <summary>
		/// Check if an item in this container should be highlighted
		/// </summary>
		/// <param name="position">the location to check</param>
		bool CheckHighlight(HighlightEventArgs highlight);
	}
}