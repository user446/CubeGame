using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Environment : MonoBehaviour
{
    public EnvironmentTrigger EnvironmentNewTrigger;
    public EnvironmentTrigger EnvironmentEnterTrigger;

    [Tooltip("Place where new environment should be spawned")]
    public Transform nextEnvironmentSpawner;
    public Action halfwayPassed;
    public Action environmentEntered;
    void Start()
    {
        EnvironmentNewTrigger.OnTriggerActivate += EnvironmentHalfWayPassed;
        EnvironmentEnterTrigger.OnTriggerActivate += CurrentEnvironmentEntered;
    }

    public void EnvironmentHalfWayPassed()
    {
        Debug.Log("Create new environment!");
        halfwayPassed();
    }

    public void CurrentEnvironmentEntered()
    {
        Debug.Log("Environment entered!");
        environmentEntered();
    }

    public Transform GetNextSpawnTransform()
    {
        return nextEnvironmentSpawner.transform;
    }

    public Transform GetGround()
    {
        return this.transform.Find("Ground");
    }

    void OnDisable()
    {
        EnvironmentNewTrigger.OnTriggerActivate -= EnvironmentHalfWayPassed;
        EnvironmentEnterTrigger.OnTriggerActivate -= CurrentEnvironmentEntered;
    }
}
