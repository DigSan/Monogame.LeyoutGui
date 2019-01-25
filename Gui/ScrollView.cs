using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace Gui
{
    public class ScrollView : LinearLayout
    {
        private readonly int _maxSpped = 50;
        private int _lenght;
        private float _scrollSpeed;
        private float? _prevTouchX;
        private float? _touchX;

        public ScrollView(Game game, SpriteBatch spriteBatch) : base(game, spriteBatch)
        {
        }

        public event Action<float> OnScroll;

        public override void Update(GameTime gameTime)
        {
            _touchX = null;
            var isTouched = false;

            foreach (var newTouch in Touches)
                if (newTouch.State == TouchLocationState.Moved)
                    if (Rectangle.Intersects(new Rectangle((int)newTouch.Position.X, (int)newTouch.Position.Y, 2, 2)))
                    {
                        _touchX = (int)newTouch.Position.X;
                    }


            if (_prevTouchX != null && _touchX != null)
            {
                _scrollSpeed = _prevTouchX.Value - _touchX.Value;
                isTouched = true;

                if (Math.Abs(_scrollSpeed) < 1)
                {
                    _scrollSpeed = 0;
                }
            }

            if (Math.Abs(_scrollSpeed) > _maxSpped)
                _scrollSpeed = Math.Sign(_scrollSpeed) * _maxSpped;

            ContentOffest -= (int)_scrollSpeed;
            ApplyChanges(Location);

            if (!isTouched)
            {
                _lenght = Views[0].Size.X * Views.Count;
                if (ContentOffest > 0)
                    _scrollSpeed = ContentOffest / 10;
                else if (ContentOffest + _lenght - Size.X < 0)
                    _scrollSpeed = (ContentOffest + _lenght - Size.X) / 10;
                else
                    _scrollSpeed -= Math.Sign(_scrollSpeed);

                if (Math.Abs(_scrollSpeed) < 1)
                    _scrollSpeed = 0;
            }

            _prevTouchX = _touchX;
        }
    }
}