using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project;
using System;
namespace SushiSnatch
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Fugu Fugu1;
       Texture2D background;
        Rectangle drawBackgroundRec;
        Random rand = new Random();
        ButtonState pbs = ButtonState.Released;
       

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 600;
            IsMouseVisible = true;
           
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
            
            Fugu1 = new Fugu(Content, @"graphics\fugu", rand.Next(100), rand.Next(10),Content.Load<Texture2D>(@"graphics\fugu"));

            
            background = Content.Load<Texture2D>(@"graphics\background");
            drawBackgroundRec = new Rectangle(0 ,0 , 600, 800);




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
 MouseState mouse = Mouse.GetState();
            Point mouseposition = new Point(mouse.X, mouse.Y);
            Rectangle area = Fugu1.drawRectanglefugu;

            // TODO: Add your update logic here
           if (pbs == ButtonState.Pressed  && mouse.LeftButton == ButtonState.Released  && area.Contains(mouseposition))
            {
                Exit();

               


            }
           else if (mouse.LeftButton == ButtonState.Pressed) { }
            pbs = mouse.LeftButton;

 Fugu1.Update();
           

           
            

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
           // GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
           
            spriteBatch.Draw(background, drawBackgroundRec, Color.White);
            if (gameTime.TotalGameTime.Seconds > 4)
            {
             Fugu1.Draw(spriteBatch);   
            }
            
            spriteBatch.End();
          

            base.Draw(gameTime);
        }
    }
}
