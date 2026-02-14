using System;
public struct Point
{
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }
}

public class Dinglemouse
{
    public static void Main()
    {
        // Tworzymy testowy "dom"
        char[][] house = new char[][]
        {
            "   o                o        #######".ToCharArray(),
            " ###############             #     #".ToCharArray(),
            " #             #        o    #     #".ToCharArray(),
            " #  X          ###############     #".ToCharArray(),
            " #                                 #".ToCharArray(),
            " ###################################".ToCharArray()
        };

        bool result = AllAlone(house);

        Console.WriteLine("Czy POTUS jest sam? " + result);
    }
    public static bool AllAlone(char[][] house)
    {
        Point potus = default;

        for (int i = 0; i < house.GetLength(0); i++)
        {
            for (int j = 0; j < house[i].Length; j++)
            {
                if (house[i][j] == 'X')
                {
                    potus = new Point(i, j);
                }
            }
        } 
        var scannedPoints = new List<Point>();
        var isNotAllone = Scan(potus, house, scannedPoints);
        return !isNotAllone;
    }
    public static bool Scan (Point point, char[][] house, List<Point> scannedPoints)
    {
        if (scannedPoints.Contains(point))
        {
            return false;
        }
        scannedPoints.Add(point);

        if (house[point.X][point.Y] == 'o')
        {
            return true;
        }
        if (house[point.X][point.Y] == '#')
        {
            return false;
        }

        var pointUp = new Point(point.X, point.Y - 1);
        var pointDown = new Point(point.X, point.Y + 1);
        var pointToLeft = new Point(point.X - 1, point.Y);
        var pointToRight = new Point(point.X + 1, point.Y);
       
        /*
       if (Scan(pointUp, house, scannedPoints))
       {
           return true; 
       }
       if (Scan(pointDown, house, scannedPoints))
       {
           return true;
       }
       if (Scan(pointToLeft, house, scannedPoints))
       {
           return true;
       }
       if (Scan(pointToRight, house, scannedPoints))
       {
           return true;
       }
       return false;
        */

        return Scan(pointUp, house, scannedPoints) ||
            Scan(pointDown, house, scannedPoints) ||
            Scan(pointToLeft, house, scannedPoints) ||
            Scan(pointToRight, house, scannedPoints);

    }
}