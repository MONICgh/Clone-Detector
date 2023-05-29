using System.Collections.Generic;


namespace task2
{
    class ImmutableRectangle
    {
        public float Length { get; }
        public float Width { get; }

        public ImmutableRectangle(float length, float width)
        {
            Length = length;
            Width = width;  
        }

        public float GetPerimeter()
        {
            return Length * 2 + Width * 2;
        }
        public float GetSquare()
        {
            return Length * Width;
        }
        public ImmutableRectangle ChangeLength(float newLength)
        {
            return new ImmutableRectangle(newLength, Width);
        }

        public ImmutableRectangle ChangeWidth(float newWidth)
        {
            return new ImmutableRectangle(Length, newWidth);
        }

        public override string ToString()
        {
            return $"Rectangle{{ length:{Length}, width:{Width}}}";
        }
    }
}
