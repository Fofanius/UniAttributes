using UniAttributes;
using UnityEngine;

[CreateAssetMenu]
public class SampleScriptableObject : ScriptableObject
{
    [SerializeField] private float _float;
    [SerializeField] private int _integer;
    [SerializeField] private string _string;

    [Button]
    public void Log()
    {
        Debug.Log(name, this);
    }
}
