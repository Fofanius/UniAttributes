using UniAttributes;
using UnityEngine;

public class ChildMethodAttributeTester : MethodAttributeTester
{
    [Button(Name = "Overrided method", OnlyInPlayMode = true)]
    protected override void VirtualMethod()
    {
        Debug.Log("Overrided");
    }
}
