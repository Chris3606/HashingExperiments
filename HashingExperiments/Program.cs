using System.Reflection;
using HashingExperiments;
using SadRogue.Primitives;

var hashers = new[] { Hashers.BareMinimum, Hashers.BareMinimumXor, Hashers.BareMinimumSubtract };
var areas = new[]
{
    new Rectangle((-515, -515), (515, 515)).Positions().ToEnumerable().ToArray(),
    //new Rectangle(0, 0, 1024, 1024).Positions().ToEnumerable().ToArray(),
    //Gaussian.GaussianArray(1024),
    //new Rectangle(0, 0, 1024, 1024).Positions().ToEnumerable().Concat(new Rectangle(65536, 65536, 1024, 1024).Positions().ToEnumerable()).ToArray()
};

foreach (var hasher in hashers)
{
    Console.WriteLine($"-------------------Hasher: {hasher.GetMethodInfo().Name}-------------------");
    
    foreach (var area in areas)
    {
        CollisionTest.TestCollisions(area, hasher);
        Console.WriteLine();
    }
}
//CollisionTest.TestCollisions(points, Hashers.BareMinimum);