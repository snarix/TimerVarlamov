namespace TimerVarlamov;

public partial class Reminder : ContentPage
{
    private DateTime reminderTime;
    private bool isReminderSet;

    public Reminder()
	{
		InitializeComponent();
	}

    [Obsolete]
    private async Task CheckReminder()
    {
        while (isReminderSet)
        {
            await Task.Delay(1000);

            var currentTime = DateTime.Now;

            if (currentTime.Hour == reminderTime.Hour && currentTime.Minute == reminderTime.Minute && currentTime.Second == reminderTime.Second)
            {
                isReminderSet = false;

                await Device.InvokeOnMainThreadAsync(async () =>
                {
                    await DisplayAlert("Напоминание", $"Время для: {entRemind.Text}", "ОК");
                });
            }
        }
    }

    private void bttnok_Clicked(object sender, EventArgs e)
    {
        var selectedTime = timePicker.Time;
        reminderTime = DateTime.Now.Date + selectedTime;
        isReminderSet = true;

        CheckReminder();
    }
}