using UniAttributes;
using UnityEngine;

public class SampleScript : MonoBehaviour
{
    [ScriptableSubInspector]
    [SerializeField] private SampleScriptableObject _scriptable;
    [ScriptableSubInspector]
    [SerializeField] protected SampleData _data;

    [Button]
    public void Method()
    {
        Debug.Log("Message");
    }

    [Button(Name = "Some Method 1")]
    public void Method1(int number)
    {
        Debug.Log("Message " + number);
    }

    [Button(Name = "Some Method 2")]
    public int Method2()
    {
        return 47;
    }

    [Button]
    private int PrivateMethod()
    {
        return 47;
    }

    [Button]
    protected void ProtectedMethod() { }

    [Button]
    protected virtual void VirtualMethod()
    {
        Debug.Log("Virtual base");
    }
}
