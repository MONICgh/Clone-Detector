using System;

namespace RacingCar
{
    public class RacingCar
    {
        private int _position;

        public int Position
        {
            get => _position;
        }
    
        private int _speed;

        public int Speed
        {
            get => _speed;
        }

        public RacingCar()
        {
            _position = 0;
            _speed = 1;
        }

        public void DoA()
        {
            _position += _speed;
            _speed = Math.Abs(_speed) * 2;
        }

        public void DoR()
        {
            if (_position > 0)
            {
                _speed = -1;
            }
        }
    }
}