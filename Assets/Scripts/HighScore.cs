using System;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Text highscoreText;


    private void Start()
    {
        highscoreText.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }
    private void Update()
    {
        if(player.counter > PlayerPrefs.GetInt("Highscore", 0))
        {
            PlayerPrefs.SetInt("Highscore", player.counter);
            highscoreText.text = Convert.ToString(player.counter);
        }
    }
}
