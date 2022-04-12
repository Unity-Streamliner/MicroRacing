using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.iOS;
using UnityEngine;

public class IOSNotificationHandler : MonoBehaviour
{
#if UNITY_IOS
    public void ScheduleNotification(int minutes)
    {
        iOSNotification notification = new iOSNotification
        {
            Title = "Energy Recharge",
            Subtitle = "Your energy has been recharged",
            Body = "Your energy has been recharged, come back to play now!",
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Sound | PresentationOption.Alert),
            CategoryIdentifier = "category_a",
            ThreadIdentifier = "thread1",
            Trigger = new iOSNotificationTimeIntervalTrigger
            {
                TimeInterval = new System.TimeSpan(0, minutes, 0),
                Repeats = false
            }
        };
        
        iOSNotificationCenter.ScheduleNotification(notification);
    }
#endif
}
