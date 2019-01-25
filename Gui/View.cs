using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace Gui
{
    public class View : DrawableGameComponent
    {
        private readonly SpriteBatch _spriteBatch;
        private Point _resize;

        public View(Game game, SpriteBatch spriteBatch) : base(game)
        {
            _spriteBatch = spriteBatch;
        }

        protected Rectangle Rectangle => new Rectangle(Location, Size);

        protected static TouchCollection Touches { get; set; }

        public Texture2D Background { get; set; }

        public LayoutParameters LayoutParameters { get; set; }

        public Point Size { get; protected set; }

        public Point Location { get; set; }

        public virtual Point GetSize(Point parentSize)
        {
            var contentSize = Point.Zero;
            if (Background != null)
                contentSize = new Point(Background.Width, Background.Height);

            if (LayoutParameters.Wight != null) contentSize.X = LayoutParameters.Wight.Value;

            if (LayoutParameters.Height != null) contentSize.Y = LayoutParameters.Height.Value;

            _resize = new Point(
                LayoutParameters.PaddingLeft + LayoutParameters.PaddingRight,
                LayoutParameters.PaddingUp + LayoutParameters.PaddingDown);

            Size = new Point(GetFiilingValue(parentSize.X, contentSize.X, LayoutParameters.LayoutFillingX),
                       GetFiilingValue(parentSize.Y, contentSize.Y, LayoutParameters.LayoutFillingY)) + _resize;
            return Size;
        }

        protected int GetFiilingValue(int viewportValue, int contentValue, LayoutFilling layoutFilling)
        {
            switch (layoutFilling)
            {
                case LayoutFilling.MatchViewport:
                    return viewportValue;
                case LayoutFilling.None:
                    return 0;
                case LayoutFilling.WrapContent:
                    return contentValue;
            }

            return 0;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            if (Background != null)
                _spriteBatch.Draw(Background, new Rectangle(Location + new Point(LayoutParameters.PaddingLeft, LayoutParameters.PaddingUp), Size - _resize), Color.White);
        }
    }

    public class LayoutParameters
    {
        private Gravity _gravityX;
        private Gravity _gravityY;
        private LayoutFilling _layoutFillingX;
        private LayoutFilling _layoutFillingY;
        private int _offsetX;
        private int _offsetY;

        public LayoutParameters(Gravity gravityX = Gravity.Start,
            Gravity gravityY = Gravity.Start,
            int offsetX = 0,
            int offsetY = 0,
            LayoutFilling layoutFillingX = LayoutFilling.WrapContent,
            LayoutFilling layoutFillingY = LayoutFilling.WrapContent)
        {
            GravityX = gravityX;
            GravityY = gravityY;
            OffsetX = offsetX;
            OffsetY = offsetY;
            LayoutFillingX = layoutFillingX;
            LayoutFillingY = layoutFillingY;
        }

        public int PaddingUp { get; set; }
        public int PaddingRight { get; set; }
        public int PaddingDown { get; set; }
        public int PaddingLeft { get; set; }

        public int? Wight { get; set; }
        public int? Height { get; set; }

        public LayoutFilling LayoutFillingX
        {
            get => _layoutFillingX;
            set
            {
                if (_layoutFillingX != value)
                    ProprtyUpdated?.Invoke();
                _layoutFillingX = value;
            }
        }

        public LayoutFilling LayoutFillingY
        {
            get => _layoutFillingY;
            set
            {
                if (_layoutFillingY != value)

                    ProprtyUpdated?.Invoke();

                _layoutFillingY = value;
            }
        }

        public int OffsetX
        {
            get => _offsetX;
            set
            {
                if (_offsetX != value)
                    ProprtyUpdated?.Invoke();

                _offsetX = value;
            }
        }

        public int OffsetY
        {
            get => _offsetY;
            set
            {
                if (_offsetY != value)
                    ProprtyUpdated?.Invoke();

                _offsetY = value;
            }
        }

        public Gravity GravityX
        {
            get => _gravityX;
            set
            {
                if (_gravityX != value)
                    ProprtyUpdated?.Invoke();
                _gravityX = value;
            }
        }

        public Gravity GravityY
        {
            get => _gravityY;
            set
            {
                if (_gravityY != value)
                    ProprtyUpdated?.Invoke();

                _gravityY = value;
            }
        }

        public event Action ProprtyUpdated;
    }

    public enum LayoutFilling
    {
        WrapContent,
        MatchViewport,
        None
    }

    public enum Gravity
    {
        Start,
        Center,
        End
    }
}