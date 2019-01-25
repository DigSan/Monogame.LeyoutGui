using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Xml;
using Gui;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TestGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        //private HorizontalLinearLayout horizontalLinearLayout;

        private ScreenLayout sl;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 480;
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
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
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D back = new Texture2D(graphics.GraphicsDevice, 1, 1);
            UInt32[] pixel = { 0xAA000000 };
            back.SetData<UInt32>(pixel, 0, back.Width * back.Height);

            sl = new ScreenLayout(this, spriteBatch);
            var frame = new FrameLayout(this, spriteBatch);
            frame.LayoutParameters = new LayoutParameters(Gravity.Start, Gravity.Start, 0 ,0, LayoutFilling.MatchViewport, LayoutFilling.MatchViewport);
            frame.Background = back;
            
            var frame2 = new FrameLayout(this, spriteBatch);
            frame2.LayoutParameters = new LayoutParameters(Gravity.Start, Gravity.Start, 0, 0, LayoutFilling.MatchViewport, LayoutFilling.WrapContent);
            frame2.Background = back;

            var b = new Button(this, spriteBatch)
            {
                LayoutParameters = new LayoutParameters(Gravity.Center, Gravity.Start) {Height = 300, Wight = 300},
                Background = back,
                Text = "ERTre",
                SpriteFont = Content.Load<SpriteFont>("sp")
            };
            b.Click += B_Click;

            frame2.Views.Add(b);

            frame2.Views.Add(new Button(this, spriteBatch)
            {
                LayoutParameters = new LayoutParameters(Gravity.Start, Gravity.Start) { Wight = 100, Height = 100 },
                Background = back,
                Text = "ERTre2",
                SpriteFont = Content.Load<SpriteFont>("sp")
            });

            frame2.Views.Add(new Button(this, spriteBatch)
            {
                LayoutParameters = new LayoutParameters(Gravity.End, Gravity.Start) { Wight = 100, Height = 100 },
                Background = back,
                Text = "ERTre2",
                SpriteFont = Content.Load<SpriteFont>("sp")
            });

            var frame3 = new FrameLayout(this, spriteBatch);
            frame3.LayoutParameters = new LayoutParameters(Gravity.Start, Gravity.Center, 0, 0, LayoutFilling.MatchViewport, LayoutFilling.WrapContent){ Wight = 100, Height = 100};
            frame3.Background = back;

            frame3.Views.Add(new Button(this, spriteBatch)
            {
                LayoutParameters = new LayoutParameters(Gravity.Center, Gravity.Start) { Wight = 100, Height = 100 },
                Background = back,
                Text = "ERTre",
                SpriteFont = Content.Load<SpriteFont>("sp")
            });

            frame3.Views.Add(new Button(this, spriteBatch)
            {
                LayoutParameters = new LayoutParameters(Gravity.Start, Gravity.Start) { Wight = 100, Height = 100 },
                Background = back,
                Text = "ERTre2",
                SpriteFont = Content.Load<SpriteFont>("sp")
            });

            frame3.Views.Add(new Button(this, spriteBatch)
            {
                LayoutParameters = new LayoutParameters(Gravity.End, Gravity.Start) { Wight = 100, Height = 100 },
                Background = back,
                Text = "ERTre2",
                SpriteFont = Content.Load<SpriteFont>("sp")
            });

            frame.Views.Add(frame2);
            frame.Views.Add(frame3);

            var hl = new ScrollView(this, spriteBatch)
            {
                LayoutParameters =
                    new LayoutParameters(Gravity.Start, Gravity.End)
                    {
                        Height = 300,
                        LayoutFillingX = LayoutFilling.MatchViewport
                    },
                Background = back
            };

            var bbb2 = new Button(this, spriteBatch)
            {
                Text = "test-",
                Background = back,
                LayoutParameters = new LayoutParameters() { Wight = 200, Height = 200, PaddingLeft = 15, PaddingRight = 15 },
                SpriteFont = Content.Load<SpriteFont>("sp")
            };

            bbb2.Click += (v) =>
            {
                //hl.ContentOffestX -= 50;
                //hl.ApplyChanges(Point.Zero);
            };

            hl.Views.Add(bbb2);

            var bbb = new Button(this, spriteBatch)
            {
                Text = "test+",
                Background = back,
                LayoutParameters = new LayoutParameters() {Wight = 200, Height = 200, PaddingLeft = 15, PaddingRight = 15 },
                SpriteFont = Content.Load<SpriteFont>("sp")
            };

            bbb.Click += (v) =>
            {
                //hl.ContentOffestX += 50;
                //hl.ApplyChanges(Point.Zero);
            };

            hl.Views.Add(bbb);

            hl.Views.Add(new Button(this, spriteBatch)
            {
                Text = "test+",
                Background = back,
                LayoutParameters = new LayoutParameters() { Wight = 200, Height = 200, PaddingLeft = 15, PaddingRight = 15, PaddingUp = 30},
                SpriteFont = Content.Load<SpriteFont>("sp")
            });

            hl.Views.Add(new Button(this, spriteBatch)
            {
                Text = "test+",
                Background = back,
                LayoutParameters = new LayoutParameters() { Wight = 200, Height = 200, PaddingLeft = 15, PaddingRight = 15 },
                SpriteFont = Content.Load<SpriteFont>("sp")
            }); hl.Views.Add(new Button(this, spriteBatch)
            {
                Text = "test+",
                Background = back,
                LayoutParameters = new LayoutParameters() { Wight = 200, Height = 200, PaddingLeft = 15, PaddingRight = 15 },
                SpriteFont = Content.Load<SpriteFont>("sp")
            }); hl.Views.Add(new Button(this, spriteBatch)
            {
                Text = "test+",
                Background = back,
                LayoutParameters = new LayoutParameters() { Wight = 200, Height = 200, PaddingLeft = 15, PaddingRight = 15 },
                SpriteFont = Content.Load<SpriteFont>("sp")
            }); hl.Views.Add(new Button(this, spriteBatch)
            {
                Text = "test+",
                Background = back,
                LayoutParameters = new LayoutParameters() { Wight = 200, Height = 200, PaddingLeft = 15, PaddingRight = 15 },
                SpriteFont = Content.Load<SpriteFont>("sp")
            }); hl.Views.Add(new Button(this, spriteBatch)
            {
                Text = "test+",
                Background = back,
                LayoutParameters = new LayoutParameters() { Wight = 200, Height = 200, PaddingLeft = 15, PaddingRight = 15 },
                SpriteFont = Content.Load<SpriteFont>("sp")
            }); hl.Views.Add(new Button(this, spriteBatch)
            {
                Text = "test+",
                Background = back,
                LayoutParameters = new LayoutParameters() { Wight = 200, Height = 200, PaddingLeft = 15, PaddingRight = 15 },
                SpriteFont = Content.Load<SpriteFont>("sp")
            }); hl.Views.Add(new Button(this, spriteBatch)
            {
                Text = "test+",
                Background = back,
                LayoutParameters = new LayoutParameters() { Wight = 200, Height = 200, PaddingLeft = 15, PaddingRight = 15 },
                SpriteFont = Content.Load<SpriteFont>("sp")
            }); hl.Views.Add(new Button(this, spriteBatch)
            {
                Text = "test+",
                Background = back,
                LayoutParameters = new LayoutParameters() { Wight = 200, Height = 200, PaddingLeft = 5, PaddingRight = 5 },
                SpriteFont = Content.Load<SpriteFont>("sp")
            }); hl.Views.Add(new Button(this, spriteBatch)
            {
                Text = "test+",
                Background = back,
                LayoutParameters = new LayoutParameters() { Wight = 200, Height = 200, PaddingLeft = 5, PaddingRight = 5 },
                SpriteFont = Content.Load<SpriteFont>("sp")
            }); hl.Views.Add(new Button(this, spriteBatch)
            {
                Text = "test+",
                Background = back,
                LayoutParameters = new LayoutParameters() { Wight = 200, Height = 200, PaddingLeft = 5, PaddingRight = 5 },
                SpriteFont = Content.Load<SpriteFont>("sp")
            }); hl.Views.Add(new Button(this, spriteBatch)
            {
                Text = "test+",
                Background = back,
                LayoutParameters = new LayoutParameters() { Wight = 200, Height = 200, PaddingLeft = 5, PaddingRight = 5 },
                SpriteFont = Content.Load<SpriteFont>("sp")
            }); hl.Views.Add(new Button(this, spriteBatch)
            {
                Text = "test+",
                Background = back,
                LayoutParameters = new LayoutParameters() { Wight = 200, Height = 200, PaddingLeft = 5, PaddingRight = 5},
                SpriteFont = Content.Load<SpriteFont>("sp")
            }); hl.Views.Add(new Button(this, spriteBatch)
            {
                Text = "test+",
                Background = back,
                LayoutParameters = new LayoutParameters() { Wight = 200, Height = 200, PaddingLeft = 5, PaddingRight = 5 },
                SpriteFont = Content.Load<SpriteFont>("sp")
            });
            frame.Views.Add(hl);

            sl.Views.Add(frame);
            sl.ApplyChanges(Point.Zero);
        }

        private int i;
        private void B_Click(Button b)
        {
            b.Text = i++.ToString();
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                Exit();

            //horizontalLinearLayout.Update(gameTime);
            sl.Update(gameTime);

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

            //horizontalLinearLayout.Draw(gameTime);
            sl.Draw(gameTime);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
