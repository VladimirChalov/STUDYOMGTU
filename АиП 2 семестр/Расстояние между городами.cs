using System;

class DistanceCalculator
{
    static void Main()
    {
        Console.WriteLine("Введите координаты первого города (широта долгота):");
        string[] firstCity = Console.ReadLine().Split();
        double firstLatDeg = double.Parse(firstCity[0]);
        double firstLonDeg = double.Parse(firstCity[1]);

        Console.WriteLine("Введите координаты второго города (широта долгота):");
        string[] secondCity = Console.ReadLine().Split();
        double secondLatDeg = double.Parse(secondCity[0]);
        double secondLonDeg = double.Parse(secondCity[1]);

        Console.WriteLine("Введите радиус планеты:");
        double sphereRadius = double.Parse(Console.ReadLine());

        double firstLatRad = DegreesToRadians(firstLatDeg);
        double firstLonRad = DegreesToRadians(firstLonDeg);
        double secondLatRad = DegreesToRadians(secondLatDeg);
        double secondLonRad = DegreesToRadians(secondLonDeg);

        double longitudeDiff = Math.Abs(firstLonRad - secondLonRad);

        double angleCos = CalculateCentralAngleCos(firstLatRad, secondLatRad, longitudeDiff);
        angleCos = ClampValue(angleCos, -1.0, 1.0);
        double centralAngle = Math.Acos(angleCos);

        double surfaceDistance = sphereRadius * centralAngle;
        double roundedDistance = Math.Round(surfaceDistance, 3);

        Console.WriteLine($"Расстояние между городами: {roundedDistance}");
    }

    static double DegreesToRadians(double degrees)
    {
        return degrees * Math.PI / 180.0;
    }

    static double CalculateCentralAngleCos(double lat1, double lat2, double lonDiff)
    {
        return Math.Sin(lat1) * Math.Sin(lat2) +
               Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(lonDiff);
    }

    static double ClampValue(double value, double min, double max)
    {
        return Math.Max(min, Math.Min(max, value));
    }
}