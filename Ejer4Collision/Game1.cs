using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Ejer4Collision
{
    /// <summary>
    /// Con un objeto en pantalla que se mueva por teclado y otro que se mueva por pantalla.
    /// Haz un chequeo de colisiones y cuando estos colisionen haz que ocurra algo.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite s_pelota;
        List<Sprite> sprites = new List<Sprite>();
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
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
            s_pelota = new Sprite(graphics, new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2));
            s_pelota.velocidad = new Vector2(100, 15);

            

            Random x = new Random();
            for (int i = 0; i <= 46; i++)
            {
                sprites.Add(new Sprite(graphics, new Vector2((float)(x.NextDouble() * graphics.PreferredBackBufferWidth), (float)(x.NextDouble() * graphics.PreferredBackBufferHeight))));
            }
            foreach (Sprite objeto in sprites)
            {
                objeto.velocidad = new Vector2((float)(x.NextDouble() * 50), (float)(x.NextDouble() * 50));
            }

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
            s_pelota.cargarImagen(Content, "JK");

            foreach (Sprite objeto in sprites)
            {
                objeto.cargarImagen(Content, "JK");
            }

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
            s_pelota.Mover();

            foreach (Sprite objeto in sprites)
            {
                objeto.Mover();
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            s_pelota.Dibujar();

            foreach (Sprite objeto in sprites)
            {
                objeto.Dibujar();
            }
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
