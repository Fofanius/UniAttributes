using UniAttributes;
using UnityEngine;

[CreateAssetMenu]
public class SampleScriptableObject : ScriptableObject
{
    [Button]
    public void Log()
    {
        Debug.Log(name, this);
    }
}
