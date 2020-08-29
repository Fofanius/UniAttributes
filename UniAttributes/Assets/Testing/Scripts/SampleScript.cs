using UniAttributes.Runtime.Scripts;
using UnityEngine;

public class SampleScript : MonoBehaviour
{
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
}