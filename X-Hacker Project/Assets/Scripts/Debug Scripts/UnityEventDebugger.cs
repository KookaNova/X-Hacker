using UnityEngine;

[CreateAssetMenu(menuName = "Debug/Unity Event Debugger")]
public class UnityEventDebugger : ScriptableObject
{
    public void EventDebug(string message)
    {
        Debug.Log(message);
    }

    public void EventDebug(GameObject obj)
    {
        Debug.Log(obj);
    }
}