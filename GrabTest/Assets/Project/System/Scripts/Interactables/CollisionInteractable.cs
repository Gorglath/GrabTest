using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInteractable : MonoBehaviour
{
    [Header("Events")]
    [SerializeField] private bool m_isEventRepeatable = false;
    [SerializeField] private DelayedEvent[] m_whenInteracted = null;
    
    [Header("References")]
    [SerializeField] private Collider m_interactionCollider = null;

    //helpers
    private bool m_didAlreadyInvokedEvents = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other != m_interactionCollider)
            return;
        if (m_didAlreadyInvokedEvents && !m_isEventRepeatable)
            return;

        m_didAlreadyInvokedEvents = true;
        EventManager.Instance.InvokeDelayedEvents(m_whenInteracted);
    }
}
