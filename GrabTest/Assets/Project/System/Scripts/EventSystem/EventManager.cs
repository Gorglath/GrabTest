using Pixelplacement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public void InvokeDelayedEvents(DelayedEvent[] delayedEvents)
    {
        StartCoroutine(invokeEvents(delayedEvents));
    }

    IEnumerator invokeEvents(DelayedEvent[] delayedEvents)
    {
        foreach (DelayedEvent delayedEvent in delayedEvents)
        {
            yield return new WaitForSeconds(delayedEvent.m_timeBeforeInvokingEvent);
            delayedEvent.m_event.Invoke();
        }
    }
}
