using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Mutex oneMutex = null;
        const string MutexName = "RUNMEONLYONCE";

        try 
        {
            oneMutex = Mutex.OpenExisting(MutexName);
        }
        catch (WaitHandleCannotBeOpenedException)
        {
            // Cannot open the mutex because it doesn't exist 
        }

         
        if (oneMutex == null)
        {
            oneMutex = new Mutex(true, MutexName);
        }
        else
        {
            oneMutex.Close();
            return;
        }

        Console.WriteLine("Our Application");
        Console.Read();
    }
}
