using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreUI;
    
    public void UpdateScoreUI(int score)
    {
        scoreUI.text = "Score : " + score;
    }
}
