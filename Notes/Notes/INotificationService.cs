using System;
using System.Collections.Generic;
using System.Text;

namespace Notes
{
    public interface INotificationService
    {
        void CreateNotification(string title, string message);
    }

}