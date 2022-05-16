using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupText : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private DialogScriptable m_dialogToPresent = null;
    [SerializeField] private TMP_Text m_popUpText = null;
    private void OnEnable()
    {
        m_popUpText.text = m_dialogToPresent.m_dialog;
    }
}
