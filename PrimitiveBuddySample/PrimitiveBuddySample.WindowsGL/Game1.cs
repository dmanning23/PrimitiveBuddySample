using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PrimitiveBuddy;

namespace PrimitiveBuddySample.WindowsGL
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Primitive _prim;
		KeyboardState _keys;
		float step = 200f;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			_keys = new KeyboardState();
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			// TODO: Add your initialization logic here

			base.Initialize();
			_prim = new Primitive(graphics.GraphicsDevice, spriteBatch);
			_prim.NumCircleSegments = 3;
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// TODO: use this.Content to load your game content here
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
		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			var curKeys = Keyboard.GetState();
			if (_keys.IsKeyUp(Keys.A) && curKeys.IsKeyDown(Keys.A))
			{
				_prim.NumCircleSegments = _prim.NumCircleSegments + 1;
			}
			else if (_keys.IsKeyUp(Keys.S) && curKeys.IsKeyDown(Keys.S))
			{
				_prim.NumCircleSegments = _prim.NumCircleSegments - 1;
			}
			_keys = curKeys;

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin();

			_prim.Circle(new Vector2(128f, 128f), 64f, Color.White);
			_prim.Pie(new Vector2(256f, 256f), 64f, MathHelper.PiOver2, MathHelper.PiOver2, Color.White);

			_prim.SineWave(new Vector2(300, 200), new Vector2(500, 200), 20f, 30f, Color.White);
			_prim.SineWave(new Vector2(300, 300), new Vector2(400, 400), 20f, 30f, Color.Red);
			_prim.SineWave(new Vector2(300, 400), new Vector2(400, 550), 20f, 30f, Color.White);
			_prim.SineWave(new Vector2(200, 400), new Vector2(300, 300), 20f, 30f, Color.Green);

			_prim.SineWave(new Vector2(step, 100), new Vector2(200, 100), 20f, 30f, Color.Green);
			step += 2f;
			if (step >= 1000)
			{
				step = 200f;
			}

			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
