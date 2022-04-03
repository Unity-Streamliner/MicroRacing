using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiplier;

    private float _score;
    
    void Update()
    {
        _score += Time.deltaTime * scoreMultiplier;
        scoreText.text = Mathf.FloorToInt(_score).ToString();
    }
}
