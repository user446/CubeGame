using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private Transform player;
    private Text text_score;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        text_score = transform.Find("ScoreText").GetComponent<Text>();
    }
    void Update()
    {
        text_score.text = player.position.z.ToString("0");
    }
}
