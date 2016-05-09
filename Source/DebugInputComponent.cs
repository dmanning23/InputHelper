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
	/// This is a game component for debugging input helper objects.
	/// Add one of these to your game, and it will render the highlights, clicks, drags, and drops.
	/// </summary>
	public class DebugInputComponent : DrawableGameComponent
	{
		#region Fields

		SpriteBatch _spriteBatch;

		#endregion //Fields

		#region Properties

		private IInputHelper Input
		{
			get; set;
		}

		private Primitive Prim
		{
			get; set;
		}

		private List<HighlightEventArgs> Cursor
		{
			get; set;
		}

		private List<ClickEventArgs> Clicks
		{
			get; set;
		}

		private DragEventArgs Drag
		{
			get; set;
		}

		private List<DragEventArgs> Drags
		{
			get; set;
		}

		private List<DropEventArgs> Drops { get; set; }

		#endregion //Properties

		#region Methods

		public DebugInputComponent(Game game) : base(game)
		{
			Cursor = new List<HighlightEventArgs>();
			Clicks = new List<ClickEventArgs>();
			Drops = new List<DropEventArgs>();
			Drags = new List<DragEventArgs>();

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
			Drag = null;

			Cursor.AddRange(Input.Highlights);
			Clicks.AddRange(Input.Clicks);
			Drags.AddRange(Input.Drags);
			Drag = Input.Drags.FirstOrDefault();
			Drops.AddRange(Input.Drops);

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

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		public override void Draw(GameTime gameTime)
		{
			_spriteBatch.Begin();

			//draw the mouse cursor
			Prim.Thickness = 2;
			foreach (var mouseEvent in Cursor)
			{
				Prim.Circle(mouseEvent.Position, 10, Color.Yellow);
			}

			//draw the mouse delta in lime green
			foreach (var mouseEvent in Drags)
			{
				Prim.Line(mouseEvent.Current, mouseEvent.Current - mouseEvent.Delta, Color.LimeGreen);
			}

			//draw the drag operatino in green
			if (null != Drag)
			{
				//Prim.Circle(Drag.Current, 10, Color.Green);
				Prim.Line(Drag.Start, Drag.Current, Color.Green);
			}

			foreach (var mouseEvent in Clicks)
			{
				Prim.Circle(mouseEvent.Position, 10, (mouseEvent.Button == MouseButton.Left) ? Color.Red : Color.DarkRed);
			}

			//draw the drop in dark green
			foreach (var mouseEvent in Drops)
			{
				Prim.Line(mouseEvent.Start, mouseEvent.Drop, Color.DarkGreen);
				Prim.Circle(mouseEvent.Drop, 10, Color.DarkGreen);
			}

			_spriteBatch.End();

			base.Draw(gameTime);
		}

		#endregion //Methods
	}
}
