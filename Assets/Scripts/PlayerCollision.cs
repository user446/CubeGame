using UnityEngine;
using System;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerCollision : MonoBehaviour
{
    private PlayerMovement playerMoveComponent;
    public Action ObstacleHitTrigger;
    public Action LevelFinishTrigger;

    void Start()
    {
       playerMoveComponent = gameObject.GetComponent<PlayerMovement>();
    }
    
    void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Obstacle")
        {
            playerMoveComponent.enabled = false;
            ObstacleHitTrigger();
        }
        if(collisionInfo.collider.tag == "LevelEnd")
        {
            playerMoveComponent.enabled = false;
            LevelFinishTrigger();
        }
    }
}
