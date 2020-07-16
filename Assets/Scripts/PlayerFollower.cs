using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    private Transform player;
    private Vector3 defaultPosition;
    void Start()
    {
        player = GameObject.Find("Player").transform;
        defaultPosition = transform.position;
    }

    
    void Update()
    {
        transform.position = player.position + defaultPosition;
    }
}
