using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private TMP_Text energyText;
    [SerializeField] private AndroidNotificationHandler androidNotificationHandler;
    [SerializeField] private int maxEnergy;
    [SerializeField] private int energyRechargeDuration;

    private int _energy;
    private const string EnergyKey = "Energy";
    private const string EnergyReadyKey = "EnergyReady";

    private void Start()
    {
        int score = PlayerPrefs.GetInt(ScoreSystem.HighScoreKey, 0);
        highScoreText.text = $"High Score: {score}";

        _energy = PlayerPrefs.GetInt(EnergyKey, maxEnergy);
        if (_energy == 0)
        {
            string energyReadyString = PlayerPrefs.GetString(EnergyReadyKey, string.Empty);
            if (energyReadyString == String.Empty)
            {
                return;
            }

            DateTime energyReady = DateTime.Parse(energyReadyString);
            if (DateTime.Now > energyReady)
            {
                _energy = maxEnergy;
                PlayerPrefs.SetInt(EnergyKey, _energy);
            }
        }

        energyText.text = $"Play ({_energy})";
    }

    public void Play()
    {
        if (_energy > 0)
        {
            _energy--;
            PlayerPrefs.SetInt(EnergyKey, _energy);
            if (_energy == 0)
            {
                DateTime energyReady = DateTime.Now.AddMinutes(energyRechargeDuration);
                PlayerPrefs.SetString(EnergyReadyKey, energyReady.ToString());
#if UNITY_ANDROID
                androidNotificationHandler.ScheduleNotification(energyReady);
#endif
                
            }
            SceneManager.LoadScene(1);
        }
    }
}
