using UniAttributes;
using UnityEngine;

[CreateAssetMenu]
public class ScriptableMethodAttributeTester : ScriptableObject
{
    [Button]
    public void Log()
    {
        Debug.Log(name, this);
    }
}
