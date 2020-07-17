using System;

namespace VoronoiDemo
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new VoronoiDemo())
                game.Run();
        }
    }
}
