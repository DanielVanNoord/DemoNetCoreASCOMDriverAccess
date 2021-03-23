using System;

namespace DemoNetCoreASCOMDriverAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            //Print all Camera drivers
            foreach (var camera in ASCOM.Standard.COM.DriverAccess.Camera.Cameras)
            {
                Console.WriteLine($"Found driver {camera.Name} with ProgID {camera.ProgID}");
            }

            //Create a CoverCalibrator Simulator driver, open SetupDialog and connect / disconnect
            using (var covcal = new ASCOM.Standard.COM.DriverAccess.CoverCalibrator("ASCOM.Simulator.CoverCalibrator"))
            {
                covcal.SetupDialog();
                var test = covcal.SupportedActions;
                Console.WriteLine($"Connected state: {covcal.Connected}");
                Console.WriteLine("Connecting...");
                covcal.Connected = true;
                Console.WriteLine($"Connected state: {covcal.Connected}");
                Console.WriteLine("Disconnecting...");
                covcal.Connected = false;
                Console.WriteLine($"Connected state: {covcal.Connected}");
            }
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
