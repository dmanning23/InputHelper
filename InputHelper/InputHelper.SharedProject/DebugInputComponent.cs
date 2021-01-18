using InputHelper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PrimitiveBuddy;
using System.Collections.Generic;
using System.Linq;

namespace InputHelper
{
	/// <summary>
	/// The matrix to convert from game to screen cooridinates
	/// </summary>
	/// <param name="screenCoord"></param>
	/// <returns></returns>
	public delegate Matrix ConvertToScreenMatrix();

	/// <summary>
	/// This is a game component for debugging input helper objects.
	/// Add one of these to your game, and it will render the highlights, clicks, drags, and drops.
	/// </summary>
	public class DebugInputComponent : DrawableGameComponent
	{
		#region Fields

		SpriteBatch _spriteBatch;

		ConvertToScreenMatrix _transform;

		#endregion //Fields

		#region Properties

		private IInputHelper Input { get; set; }

		Color mouseCursorColor = Color.Yellow;
		Color dragDeltaColor = Color.LimeGreen;
		Color dragColor = Color.Green;
		Color dropColor = Color.DarkGreen;
		Color leftClickColor = Color.Red;
		Color rightClickColor = Color.Pink;
		Color flickColor = Color.Orange;

		Color pinchDeltaColor = Color.Pink;
		Color pinchFirstColor = Color.Blue;
		Color pinchSecondColor = Color.Magenta;
		Color pinchReleaseColor = Color.DarkBlue;

		private Primitive Prim { get; set; }

		private List<HighlightEventArgs> Cursor { get; set; }

		private List<ClickEventArgs> Clicks { get; set; }

		private DragEventArgs Drag { get; set; }

		private List<DragEventArgs> Drags { get; set; }

		private List<DropEventArgs> Drops { get; set; }

		private List<FlickEventArgs> Flicks { get; set; }

		private PinchEventArgs Pinch { get; set; }

		private List<PinchEventArgs> Pinches { get; set; }

		#endregion //Properties

		#region Methods

		public DebugInputComponent(Game game, ConvertToScreenMatrix transform) : base(game)
		{
			Cursor = new List<HighlightEventArgs>();
			Clicks = new List<ClickEventArgs>();
			Drops = new List<DropEventArgs>();
			Drags = new List<DragEventArgs>();
			Flicks = new List<FlickEventArgs>();
			Pinches = new List<PinchEventArgs>();
			_transform = transform;

			Input = game.Services.GetService<IInputHelper>();

			game.Components.Add(this);
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			_spriteBatch = new SpriteBatch(GraphicsDevice);
			Prim = new Primitive(GraphicsDevice, _spriteBatch);
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
			// TODO: Unload any non ContentManager content here
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		public override void Update(GameTime gameTime)
		{
			if (null == Input)
			{
				//If the IInputHelper is null, this is probably a controller game.
				//There is nothing to debug!
				return;
			}

			Drag = null;
			Pinch = null;

			Cursor.AddRange(Input.Highlights);
			Clicks.AddRange(Input.Clicks);
			Drags.AddRange(Input.Drags);
			Drag = Input.Drags.FirstOrDefault();
			Drops.AddRange(Input.Drops);
			Flicks.AddRange(Input.Flicks);
			Pinches.AddRange(Input.Pinches);
			Pinch = Input.Pinches.FirstOrDefault();

			while (Cursor.Count > 1)
			{
				Cursor.RemoveAt(0);
			}

			while (Clicks.Count > 1)
			{
				Clicks.RemoveAt(0);
			}

			while (Drops.Count > 1)
			{
				Drops.RemoveAt(0);
			}

			while (Drags.Count > 30)
			{
				Drags.RemoveAt(0);
			}

			while (Flicks.Count > 1)
			{
				Flicks.RemoveAt(0);
			}

			while (Pinches.Count > 1)
			{
				Pinches.RemoveAt(0);
			}

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		public override void Draw(GameTime gameTime)
		{
			_spriteBatch.Begin(SpriteSortMode.Deferred,
							  BlendState.AlphaBlend,
							  null, null, null, null,
							  (null != _transform ? _transform() : Matrix.Identity));

			DrawDebugInfo();

			_spriteBatch.End();

			base.Draw(gameTime);
		}

		/// <summary>
		/// Call this to render all the debug info.
		/// </summary>
		public void DrawDebugInfo()
		{
			//draw the mouse cursor
			Prim.Thickness = 2;
			foreach (var mouseEvent in Cursor)
			{
				Prim.Circle(mouseEvent.Position, 10, mouseCursorColor);
			}

			//draw the drag delta
			foreach (var mouseEvent in Drags)
			{
				Prim.Line(mouseEvent.Current, mouseEvent.Current - mouseEvent.Delta, dragDeltaColor);
			}

			//draw the drag operation
			if (null != Drag)
			{
				Prim.Line(Drag.Start, Drag.Current, dragColor);
			}

			foreach (var mouseEvent in Clicks)
			{
				Prim.Circle(mouseEvent.Position, 10, (mouseEvent.Button == MouseButton.Left) ? leftClickColor : rightClickColor);

				if (mouseEvent.DoubleClick)
				{
					Prim.Circle(mouseEvent.Position, 20, (mouseEvent.Button == MouseButton.Left) ? leftClickColor : rightClickColor);
				}
			}

			//draw the drop
			foreach (var mouseEvent in Drops)
			{
				Prim.Line(mouseEvent.Start, mouseEvent.Drop, dropColor);
				Prim.Circle(mouseEvent.Drop, 10, dropColor);
			}

			//Draw the Flick events
			foreach (var mouseEvent in Flicks)
			{
				Prim.Circle(mouseEvent.Position, 10, flickColor);
				Prim.Line(mouseEvent.Position, mouseEvent.Position + mouseEvent.Delta, flickColor);
			}

			//draw the pinch delta
			foreach (var mouseEvent in Pinches)
			{
				Prim.Line(mouseEvent.First, mouseEvent.Second, pinchDeltaColor);
			}

			//draw the pinch release in
			foreach (var mouseEvent in Pinches)
			{
				if (!mouseEvent.Release)
				{
					Prim.Circle(mouseEvent.First, 60, pinchFirstColor);
					Prim.Circle(mouseEvent.Second, 60, pinchSecondColor);
				}
				else
				{
					Prim.Circle(mouseEvent.First, 60, pinchReleaseColor);
					Prim.Circle(mouseEvent.Second, 60, pinchReleaseColor);
				}
			}
		}

		#endregion //Methods
	}
}
