using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Text scoreText;
    void Update()
    {
        scoreText.text = Convert.ToString(player.counter);
    }
}
