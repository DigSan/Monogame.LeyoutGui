using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace Gui
{
    public class Button : View
    {
        public enum Orintation
        {
            Left,
            Center
        }

        private readonly SpriteBatch _spriteBatch;
        public bool Enable = true;

        public Button(Game game, SpriteBatch spriteBatch) : base(game, spriteBatch) => _spriteBatch = spriteBatch;

        public ButtonType TypeButton { get; set; } = ButtonType.Release;
        public Color Color { get; set; } = Color.AliceBlue;
        public int TextOffsetX { get; set; }
        public SpriteFont SpriteFont { get; set; }


        public Orintation TextOrintation { get; set; }

        public string[] Texts { get; set; }

        public string Text
        {
            get => Texts[0];
            set => Texts = new[] {value};
        }

        public event Action<Button> Click;

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            if (!Visible)
                return;
            if (Texts.Length != 0)
            {
                var r = 200;
                var y = 0;

                for (var i = 0; Texts.Length > i; i++)
                {
                    if (i > 0)
                    {
                        r += TextOffsetX;
                        y = 1;
                    }

                    Color textColor;
                    textColor = Enable ? Color : Color.Gray;

                    var textPosition = Vector2.Zero;
                    if (TextOrintation == Orintation.Left)
                        textPosition = new Vector2(Rectangle.X + 15 + r * y,
                            Rectangle.Center.Y - SpriteFont.LineSpacing / 2 - 2);
                    if (TextOrintation == Orintation.Center)
                        textPosition = new Vector2(Rectangle.Center.X - (SpriteFont.MeasureString(Texts[0]) / 2).X,
                            Rectangle.Center.Y - SpriteFont.LineSpacing / 2 - 2);
                    _spriteBatch.DrawString(SpriteFont, Texts[i], textPosition, textColor);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (!Enable || !Visible)
                return;

            TextOrintation = Orintation.Center;

            foreach (var touch in Touches)
            {
                if (TypeButton == ButtonType.Moved)
                    if (touch.State == TouchLocationState.Moved)
                        if (Rectangle.Intersects(new Rectangle((int) touch.Position.X, (int) touch.Position.Y, 2, 2)))
                            Click?.Invoke(this);
                if (TypeButton == ButtonType.Preased)
                    if (touch.State == TouchLocationState.Pressed)
                        if (Rectangle.Intersects(new Rectangle((int) touch.Position.X, (int) touch.Position.Y, 2, 2)))
                            Click?.Invoke(this);

                if (TypeButton == ButtonType.Release)
                    if (touch.State == TouchLocationState.Released && touch.TryGetPreviousLocation(out var qwe))
                        if (Rectangle.Intersects(new Rectangle((int) qwe.Position.X, (int) qwe.Position.Y, 2, 2)))
                        {
                            TouchPanel.GetState();
                            Click?.Invoke(this);
                        }
            }
        }
    }

    public enum ButtonType
    {
        Moved,
        Preased,
        Release
    }
}