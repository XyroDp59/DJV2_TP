using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    int score;
    public static LevelController Instance;
    private ScoreUI scoreUI;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
        scoreUI = GetComponent<ScoreUI>();
    }

    private void Start()
    {
        PlayerController.Singleton.health.Die.AddListener(GameOver);
    }
    public int AddToScore(int s)
    {
        score += s;
        scoreUI.UpdateScoreUI(score);
        return score;
    }

    public static void GameOver()
    {
        Instance.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
    }

}
