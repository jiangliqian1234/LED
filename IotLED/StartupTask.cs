using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Timers;
using Windows.ApplicationModel.Background;
using Windows.Devices.Gpio;
using System.Threading.Tasks;
using System.Threading;


// The Background Application template is documented at http://go.microsoft.com/fwlink/?LinkID=533884&clcid=0x409

namespace IotLED
{
    public sealed class StartupTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            // 
            // TODO: Insert code to perform background work
            //
            // If you start any asynchronous methods here, prevent the task
            // from closing prematurely by using BackgroundTaskDeferral as
            // described in http://aka.ms/backgroundtaskdeferral
            //

            InitGPIO();
        }

        public void InitGPIO()
        {
            GpioController gpio = GpioController.GetDefault();
            GpioPin pin = gpio.OpenPin(5);
            pin.SetDriveMode(GpioPinDriveMode.Output);
            while (true)
            {
                pin.Write(GpioPinValue.Low);
                Thread.Sleep(600);
                pin.Write(GpioPinValue.High);
                Thread.Sleep(600);
            }

        }


    }
}
