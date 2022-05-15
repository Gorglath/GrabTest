using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabInputHandler : MonoBehaviour
{
    //helpers
    private ActionBasedController m_ownerController;
    private XRSocketInteractor m_ownerInteractor;
    private bool m_isGrabButtonDown = false;
    private bool m_didAlreadyChangedState = false;
    private void Awake()
    {
        m_ownerInteractor = GetComponent<XRSocketInteractor>();
        m_ownerController = GetComponent<ActionBasedController>();
    }
    private void Update()
    {
        UpdateGrabPress();
        if(!m_didAlreadyChangedState)
        {
            m_didAlreadyChangedState = true;
            m_ownerInteractor.socketActive = m_isGrabButtonDown;
        }
    }

    private void UpdateGrabPress()
    {
        bool previousGrabButtonValue = m_isGrabButtonDown;
        float value = m_ownerController.selectActionValue.action.ReadValue<float>();
        m_isGrabButtonDown = value >= 0.9f;

        if (previousGrabButtonValue != m_isGrabButtonDown)
            m_didAlreadyChangedState = false;
    }
}
