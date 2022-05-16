using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable/Dialog")]
public class DialogScriptable : ScriptableObject
{
    [TextArea(1,200)]
    public string m_dialog;
}
