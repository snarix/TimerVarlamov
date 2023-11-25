namespace TimerVarlamov;

public partial class AlarmClock : ContentPage
{
    private DateTime now = DateTime.Now;
    private DateTime alarmTime;
    private bool isAlarmSet;
    public AlarmClock()
    {
        InitializeComponent();
    }

    [Obsolete]
    private async Task CheckAlarm()
    {
        while (isAlarmSet)
        {
            await Task.Delay(1000);

            var currentTime = DateTime.Now;

            if (currentTime.Hour == alarmTime.Hour && currentTime.Minute == alarmTime.Minute && currentTime.Second == alarmTime.Second)
            {
                isAlarmSet = false;

                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    await DisplayAlert("Будильник", "Будильник сработал!", "ОК");
                });
            }

        }
    }

    private void StartButton_Clicked(object sender, EventArgs e)
    {
        var selectedTime = timePicker.Time;
        alarmTime = DateTime.Now.Date + selectedTime;
        isAlarmSet = true;

        CheckAlarm();

    }
}
