using UniAttributes;
using UnityEngine;

public class ChildSampleScript : SampleScript
{
    [Button(Name = "Overrided method", OnlyInPlayMode = true)]
    protected override void VirtualMethod()
    {
        Debug.Log("Overrided");
    }
}
