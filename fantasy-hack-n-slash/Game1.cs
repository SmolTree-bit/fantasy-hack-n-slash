using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Plattformer;

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

        }

        protected override void Initialize()
        {
            Window.Position = new Point(0, 0);
            Window.IsBorderless = true;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.PreferredBackBufferWidth = 1920;

            _graphics.ApplyChanges();


            Data.mainTarget = new RenderTarget2D(GraphicsDevice, 960, 540);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Data.tilesetTexture = Content.Load<Texture2D>("tileset");
            Data.level1 = new TileMaps(30, 18, Data.tilesetTexture, 16, 6);
            Data.hitBoxImage = new Texture2D(GraphicsDevice, 1, 1);
            Data.hitBoxImage.SetData<Color>(new Color[] { Color.White });

            Data.gameFont = Content.Load<SpriteFont>("gameFont");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Här sätts de metoder som alltid ska köras oavsett vilket gamestate.
            Data.DataUpdate(gameTime);
            gameManager.Update(gameTime);


            switch(MenuManager.CurrentGameState())
            {
               
                case (MenuManager.GameStates.MainMenu):

                    break;
                
                case (MenuManager.GameStates.Playing):

                    break;
               
                case (MenuManager.GameStates.PauseMenu):

                    break;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.SetRenderTarget(Data.mainTarget);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp, sortMode: SpriteSortMode.FrontToBack);
            // Skriv allt här inne som ska synas i spelet som t.ex player, enemy, items
            Data.level1.Draw(_spriteBatch);
            GraphicsDevice.Clear(Color.Black);
            gameManager.Draw(_spriteBatch);
            _spriteBatch.End();




            GraphicsDevice.SetRenderTarget(null);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp, blendState: BlendState.NonPremultiplied);
            _spriteBatch.Draw(
                Data.mainTarget,
                Vector2.Zero,
                null,
                Color.White,
                0f,
                Vector2.Zero,
                5,
                SpriteEffects.None,
                0f);
            _spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}