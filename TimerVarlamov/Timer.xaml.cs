
using System.Diagnostics;

namespace TimerVarlamov;

public partial class Timer : ContentPage
{
    private TimeSpan remainingTime;
    private bool isRunning = false;

    public Timer()
	{
		InitializeComponent();
    }

    private async void StartButton_Clicked(object sender, EventArgs e)
    {
        if (!isRunning)
        {

            var selectedTime = TimePicker.Time;

            if (selectedTime.TotalSeconds > 0)
            {
                remainingTime = selectedTime;
                isRunning = true;

                while (remainingTime.TotalSeconds > 0 && isRunning) 
                {
                    timerLabel.Text = remainingTime.ToString(@"hh\:mm\:ss");
                    await Task.Delay(1000); 
                    remainingTime = remainingTime.Subtract(TimeSpan.FromSeconds(1));
                }

                isRunning = false;
                if (remainingTime.TotalSeconds == 0)
                {
                    timerLabel.Text = "Время истекло!";
                }
            }
        }
        else
        {
            isRunning = false;
        }
    }
}