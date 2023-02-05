using SadRogue.Primitives;
using ShaiRandom;

namespace HashingExperiments;

public static class Gaussian
{
    public static Point[] GaussianArray(int size)
    {
        int totalSize = size * size;
        var points = new Point[totalSize];
        ulong xc = 1UL, yc = 2UL;
        HashSet<Point> pts = new(totalSize);
        unchecked
        {
            while(pts.Count < totalSize)
            {
                // R2 sequence, sub-random with lots of space between nearby points
                xc += 0xC13FA9A902A6328FUL;
                yc += 0x91E10DA5C79E7B1DUL;
                // Using well-spread inputs to Probit() gives points that shouldn't overlap as often.
                // 1.1102230246251565E-16 is 2 to the -53 .
                pts.Add(new Point((int)(MathUtils.Probit((xc >> 11) * 1.1102230246251565E-16) * 256.0),
                    (int)(MathUtils.Probit((yc >> 11) * 1.1102230246251565E-16) * 256.0)));
            }
            pts.CopyTo(points);
        }

        return points;
    }
}