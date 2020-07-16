using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private PlayerCollision player_collision;
    private PlayerMovement player_movement;
    private GameObject levelcompleteUI;
    private GameObject gameOverUI;
    private bool endHasHappened = false;
    public float invokeRestartAfter = 2.0f;

    void Start()
    {
        player_collision = GameObject.Find("Player").GetComponent<PlayerCollision>();
        player_movement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        levelcompleteUI = GameObject.Find("Canvas").transform.Find("LevelCompletePanel").gameObject;
        gameOverUI = GameObject.Find("Canvas").transform.Find("GameOverPanel").gameObject;
        player_collision.ObstacleHitTrigger += GameOver;
        player_collision.LevelFinishTrigger += LevelPassed; //it is necessary to install LevelEnd prefab in the environment to trigger this Action
    }

    void Update()
    {
        if(player_movement.GetRigidbody().position.y < -1.0f)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        if(endHasHappened == false)
        {
            endHasHappened = true;
            Debug.Log("Game over");
            gameOverUI.SetActive(true);
            Invoke("Restart", invokeRestartAfter);
        }
    }

    public void LevelPassed()
    {
        if(endHasHappened == false)
        {
            endHasHappened = true;
            Debug.Log("Level finished");
            levelcompleteUI.SetActive(true);
            Invoke("Restart", invokeRestartAfter);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
