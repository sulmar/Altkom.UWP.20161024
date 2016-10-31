using System;
using System.Threading.Tasks;
using Windows.System.Power;
using Windows.UI.Core;
using Windows.UI.Xaml;


namespace Altkom.Bicycle.UWPClient.Triggers
{
    public class BatteryTrigger : StateTriggerBase
    {
        public bool Charging { get; set; }

        public BatteryTrigger()
        {
            Windows.Devices.Power.Battery.AggregateBattery.ReportUpdated
                += async (sender, args) => await UpdateStatus();

            Task.Run(()=>UpdateStatus());
        }


        private async Task UpdateStatus()
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                var batteryReport = Windows.Devices.Power.Battery.AggregateBattery.GetReport();

                switch (batteryReport.Status)
                {
                    case BatteryStatus.Idle:
                        SetActive(!this.Charging);
                        break;

                    case BatteryStatus.Charging:
                        SetActive(!this.Charging);
                        break;
                    case BatteryStatus.Discharging:
                        SetActive(this.Charging);
                        break;
                }

            });
        }
    }
}
