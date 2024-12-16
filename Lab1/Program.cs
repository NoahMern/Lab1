using Lab1;

class Program
{
    static void Main(string[] args)
    {
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.OnStarted += (message) => Console.WriteLine(message);
        stopwatch.OnStopped += (message) => Console.WriteLine(message);
        stopwatch.OnReset += (message) => Console.WriteLine(message);

        Console.WriteLine("Welcome to the Console Stopwatch!");
        Console.WriteLine("Instructions:");
        Console.WriteLine("Press 'S' to start the stopwatch.");
        Console.WriteLine("Press 'T' to stop the stopwatch.");
        Console.WriteLine("Press 'R' to reset the stopwatch.");
        Console.WriteLine("Press 'Q' to quit the application.");

        // We will run a loop to simulate the stopwatch ticking
        bool running = true;
        while (running)
        {
            // Check if there is user input
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(intercept: true).Key;
                switch (key)
                {
                    case ConsoleKey.S:
                        stopwatch.Start();
                        break;
                    case ConsoleKey.T:
                        stopwatch.Stop();
                        break;
                    case ConsoleKey.R:
                        stopwatch.Reset();
                        break;
                    case ConsoleKey.Q:
                        running = false;
                        break;
                }
            }

            if (stopwatch.IsRunning)
            {
                stopwatch.Tick();
            }

            ClearLineAndPrint(stopwatch.TimeElapsed);

            Thread.Sleep(1000);
        }

       

        Console.WriteLine("\nExiting the application...");
    }

    private static void ClearLineAndPrint(int timeElapsed)
    {
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write($"Elapsed Time: {timeElapsed} seconds   ");
    }
}
