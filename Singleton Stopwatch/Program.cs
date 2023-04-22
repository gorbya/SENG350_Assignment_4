using System;

public class StopWatch
{
    private static readonly StopWatch instance = new StopWatch(); //make sure that this isnt modified
    private DateTime startTime;
    private TimeSpan runningTime;

    private StopWatch() { }

    public static StopWatch Instance
    {
        get { return instance; }
    }

    public void startTimer()
    {
        startTime = DateTime.Now;
    }

    public TimeSpan GetRunningTime()
    {
        runningTime = DateTime.Now - startTime;
        return runningTime;
    }

    public double GetRunningTimeInHours()
    {
        return GetRunningTime().TotalHours;
    }

    public void StopTimer()
    {
        runningTime = DateTime.Now - startTime;
    }


    //a driver method for testing
    public static void Main(string[] args)
    {
        StopWatch stopwatch = StopWatch.Instance;
        stopwatch.startTimer();

        for (int i = 0; i < 20; i++)
        {
            TimeSpan runningTime = stopwatch.GetRunningTime();
            double runningTimeInMinutes = runningTime.TotalSeconds;
            double runningTimeInHours = runningTime.TotalHours;
            Console.WriteLine("Running time in seconds: " + runningTimeInMinutes);
            Console.WriteLine("Running time in hours: " + runningTimeInHours);
            Thread.Sleep(500); // wait for a half second
        }

        Console.WriteLine("Stopwatch stopped after 10 seconds.\n Creating a 'new' stopwatch...");

        StopWatch stopwatch2 = StopWatch.Instance; //ran into a bug here the first time through, where I called the start timer again, 
                                                   //this of course cleared the stopwatch timer and began again... fixed now

        for (int i = 0; i < 20; i++)
        {
            TimeSpan runningTime = stopwatch2.GetRunningTime();
            double runningTimeInMinutes = runningTime.TotalSeconds;
            double runningTimeInHours = runningTime.TotalHours;
            Console.WriteLine("Running time in seconds: " + runningTimeInMinutes);
            Console.WriteLine("Running time in hours: " + runningTimeInHours);
            Thread.Sleep(500); // wait for a half second
        }

        Console.WriteLine("Stopwatch2 stopped after 10 seconds.");
    }
}