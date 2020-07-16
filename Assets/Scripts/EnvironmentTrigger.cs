using UnityEngine;
using System;

public class EnvironmentTrigger : MonoBehaviour
{
    public Action OnTriggerActivate;
    public string activationTag;
    void OnTriggerEnter(Collider colliderInfo)
    {
        if(colliderInfo.tag == activationTag)
        {
            OnTriggerActivate();
        }
    }
}

