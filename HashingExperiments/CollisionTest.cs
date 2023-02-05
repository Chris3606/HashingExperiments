using SadRogue.Primitives;

namespace HashingExperiments;

public static class CollisionTest
{
    public static void TestCollisions(IEnumerable<Point> positions, Func<Point, int> hasher)
    {
        Dictionary<int, int> collisionCounters = new Dictionary<int, int>();
        int valueCount = 0;
        foreach (var pos in positions)
        {
            int hash = hasher(pos);
            collisionCounters[hash] = collisionCounters.GetValueOrDefault(hash, 0) + 1;
            valueCount++;
        }
        
        Console.WriteLine($"Num Values: {valueCount}");
        Console.WriteLine($"Collisions: {collisionCounters.Values.Select(i => i - 1).Sum()}");
        Console.WriteLine($"Max collisions on single value: {collisionCounters.Values.Max()}");
    }

    public static void TestCollisions(Rectangle rect, Func<Point, int> hasher)
    {
        Console.WriteLine($"Positions in rectangle: {rect}");
        TestCollisions(rect.Positions().ToEnumerable(), hasher);
    }
        
}