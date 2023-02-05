using SadRogue.Primitives;

namespace HashingExperiments;

public static class Hashers
{
    public static int BareMinimum(Point p)
    {
        uint x = (uint)p.X, y = (uint)p.Y;
        return (int)(x + (y << 16 | y >> 16));
    }
}