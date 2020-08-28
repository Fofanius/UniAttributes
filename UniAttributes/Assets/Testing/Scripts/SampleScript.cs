using UniAttributes.Runtime.Scripts;
using UnityEngine;

public class SampleScript : MonoBehaviour
{
    public int IntValue;

    [Button(Name = "Some Method")]
    public void Method()
    {
        Debug.Log("Message");
    }

    [Button(Name = "Some Method 123")]
    public void Method1(int number)
    {
        Debug.Log("Message " + number);
    }
}