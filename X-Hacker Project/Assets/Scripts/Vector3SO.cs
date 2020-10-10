using UnityEngine;

[CreateAssetMenu]
public class Vector3SO : ScriptableObject
{
    public Vector3 data;

    public void UpdateData(Transform obj)
    {
        data = obj.position;
    }
    
    public void UpdateData(Vector3SO dataObj)
    {
        data = dataObj.data;
    }

    public void MoveObjToData(Transform obj)
    {
        obj.transform.position = data;
    }
}