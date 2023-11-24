namespace TimerVarlamov;

public partial class StopWatch : ContentPage
{
    private bool isRunning;
    private DateTime startTime;
    private TimeSpan elapsed;

    public StopWatch()
	{
		InitializeComponent();
	}

    [Obsolete]
    private async Task OnTimerTick()
    {
        while (isRunning)
        {
            await Task.Delay(100); //?
            elapsed = DateTime.Now - startTime;

            await Device.InvokeOnMainThreadAsync(() =>
            {
                TimePicker.Time = elapsed;
            });
        }
    }

    private void btnStartStop_Clicked(object sender, EventArgs e)
    {
        if (isRunning)
        {
            isRunning = false;
        }
        else
        {
            isRunning = true;
            startTime = DateTime.Now - elapsed;
            OnTimerTick();
        }
    }

}