using System.ComponentModel;
using System.Threading;

namespace TimerVarlamov;

public partial class Clock : ContentPage
{
    private System.Threading.Timer timer;
    public Clock()
	{
		InitializeComponent();
        timer = new(UpdateClock, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
    }

    [Obsolete]
    private void UpdateClock(object state)
    {
        Device.BeginInvokeOnMainThread(() =>
        {
            TimePicker.Time = DateTime.Now.TimeOfDay;
        });
    }

}