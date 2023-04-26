using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Support.V4.App;
using Notes.Droid;
using Notes;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(NotificationService))]
namespace Notes.Droid
{
    public class NotificationService : INotificationService
    {
        public void CreateNotification(string title, string message)
        {
            var context = Android.App.Application.Context;
            var intent = new Intent(context, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);

            var pendingIntent = PendingIntent.GetActivity(context, 0, intent, PendingIntentFlags.OneShot);
            var notificationBuilder = new NotificationCompat.Builder(context, MainActivity.CHANNEL_ID)
                .SetContentTitle(title)
                .SetContentText(message)
                .SetAutoCancel(true)
                .SetContentIntent(pendingIntent)
                .SetSmallIcon(Resource.Drawable.notification_icon)
                .SetPriority(NotificationCompat.PriorityHigh);

            var notificationManager = NotificationManagerCompat.From(context);
            notificationManager.Notify(0, notificationBuilder.Build());
        }


    }
}
    
 