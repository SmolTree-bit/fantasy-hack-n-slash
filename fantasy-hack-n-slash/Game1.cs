using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace fantasy_hack_n_slash
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        GameManager gameManager = new GameManager();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.PreferredBackBufferWidth = 1920;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Data.hitBoxImage = new Texture2D(GraphicsDevice, 1, 1);
            Data.hitBoxImage.SetData<Color>(new Color[] { Color.White });
            Data.startGame = Content.Load<Texture2D>("MainMenuStart");
            Data.endGame = Content.Load<Texture2D>("MainMenuExit");
            Data.gameFont = Content.Load<SpriteFont>("gameFont");
            Data.pixelTexture = new Texture2D(GraphicsDevice, 1, 1);
            Data.pixelTexture.SetData(new Color[] { Color.White });


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Här sätts de metoder som alltid ska köras oavsett vilket gamestate.
            Data.DataUpdate(gameTime);
            gameManager.Update(gameTime);


           
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);


            _spriteBatch.Begin();

            gameManager.Draw(_spriteBatch);

            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}