using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsHandler : MonoBehaviour
{
    public void Show()
    {
        var anim = GetComponent<Animation>();
        anim.PlayQueued("Show");
    }

    public void Hide()
    {
        var anim = GetComponent<Animation>();
        anim.PlayQueued("Hide");
    }
}
