using Microsoft.Toolkit.Uwp.Notifications;
using Windows.UI.Notifications;
using System;

namespace RToast
{
    class Toaster
    {
        ToastContentBuilder toastContent;
        string thead { get; set; }
        string tcontent { get; set; }

        public enum Duration
        {
            Stay,
            Long,
            Short
        }
        public Toaster()
        {
            toastContent = new ToastContentBuilder() { };

        }

        private void build_body()
        {
            
            toastContent.AddText(thead,AdaptiveTextStyle.Caption,true);
            toastContent.AddText(tcontent,AdaptiveTextStyle.Body,true);
            toastContent.AddInlineImage(new Uri("https://www.google.co.za/images/branding/googlelogo/2x/googlelogo_light_color_272x92dp.png"));
        }

        public void add_heading(string s)
        {
            thead = s;
        }

        public void add_text(string s)
        {
            tcontent = s;
        }

        public void set_duration(Duration d)
        {
            switch (d)
            {
                case Duration.Stay:
                    toastContent.SetToastScenario(ToastScenario.Reminder);
                    toastContent.AddToastInput(new ToastSelectionBox("snoozeTime")
                    {
                        DefaultSelectionBoxItemId = "15",
                        Items =
                         {
                            new ToastSelectionBoxItem("5", "5 minutes"),
                            new ToastSelectionBoxItem("15", "15 minutes"),
                            new ToastSelectionBoxItem("30", "30 minutes"),
                            new ToastSelectionBoxItem("60", "1 hour")

                         }
                    });
                    toastContent.AddButton(new ToastButtonSnooze() { SelectionBoxId = "snoozeTime" });
                    toastContent.AddButton(new ToastButtonDismiss());
                    Console.WriteLine("Set to a call");
                    break;
                case Duration.Long:
                    toastContent.SetToastDuration(ToastDuration.Long);
                    Console.WriteLine("Set to a lomg");
                    break;
                case Duration.Short:
                    toastContent.SetToastDuration(ToastDuration.Short);
                    Console.WriteLine("Set to a short");
                    break;
            }
        }

        public void show_toast()
        {
            build_body();
            toastContent.Show(toast => toast.ExpiresOnReboot = true);
        }

        public void schedule_toast(DateTime d)
        {
            build_body();
            toastContent.Schedule(d, toast => toast.ExpirationTime = DateTime.Now.AddDays(1));
        }


    }
}
