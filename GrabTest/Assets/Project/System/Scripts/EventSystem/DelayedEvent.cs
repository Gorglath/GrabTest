using System;
using UnityEngine.Events;

[Serializable]
public class DelayedEvent
{
    public UnityEvent m_event = null;
    public float m_timeBeforeInvokingEvent = 0.0f;
}
