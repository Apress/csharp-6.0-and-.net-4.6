using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProcessManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Processes *****\n");
            ListAllRunningProcesses();

            // Prompt user for a PID and print out the set of active threads.
            Console.WriteLine("***** Enter PID of process to investigate *****");
            Console.Write("PID: ");
            string pID = Console.ReadLine();
            int theProcID = int.Parse(pID);

            EnumThreadsForPid(theProcID);
            EnumModsForPid(theProcID);
            Console.ReadLine();
        }

        #region List all processes
        static void ListAllRunningProcesses()
        {
            // Get all the processes on the local machine, ordered by
            // PID.
            var runningProcs =
              from proc in Process.GetProcesses(".") orderby proc.Id select proc;

            // Print out PID and name of each process.
            foreach (var p in runningProcs)
            {
                string info = string.Format("-> PID: {0}\tName: {1}",
                  p.Id, p.ProcessName);
                Console.WriteLine(info);
            }
            Console.WriteLine("************************************\n");
        }
        #endregion

        #region Get process by PID
        // If there is no process with the PID of 987, a
        // runtime exception will be thrown.
        static void GetSpecificProcess()
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(987);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Enum threads in process
        static void EnumThreadsForPid(int pID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pID);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            // List out stats for each thread in the specified process.
            Console.WriteLine("Here are the threads used by: {0}",
              theProc.ProcessName);
            ProcessThreadCollection theThreads = theProc.Threads;

            foreach (ProcessThread pt in theThreads)
            {
                string info =
                  string.Format("-> Thread ID: {0}\tStart Time: {1}\tPriority: {2}",
                    pt.Id, pt.StartTime.ToShortTimeString(), pt.PriorityLevel);
                Console.WriteLine(info);
            }
            Console.WriteLine("************************************\n");
        }
        #endregion

        #region Enum mods in process
        static void EnumModsForPid(int pID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pID);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Here are the loaded modules for: {0}",
              theProc.ProcessName);
            ProcessModuleCollection theMods = theProc.Modules;
            foreach (ProcessModule pm in theMods)
            {
                string info = string.Format("-> Mod Name: {0}", pm.ModuleName);
                Console.WriteLine(info);
            }
            Console.WriteLine("************************************\n");
        }
        #endregion

        #region Start and Kill process
        static void StartAndKillProcess()
        {
            Process ieProc = null;

            // Launch Internet Explorer, and go to facebook!
            try
            {
                ProcessStartInfo startInfo = new
                  ProcessStartInfo("IExplore.exe", "www.facebook.com");
                startInfo.WindowStyle = ProcessWindowStyle.Maximized;

                ieProc = Process.Start(startInfo);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Write("--> Hit enter to kill {0}...", ieProc.ProcessName);
            Console.ReadLine();

            // Kill the iexplore.exe process.
            try
            {
                ieProc.Kill();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
