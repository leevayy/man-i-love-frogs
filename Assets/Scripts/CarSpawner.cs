using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject car;

    private bool executeOnce = false;

    private void Update()
    {
        if (player.counter < 150 && (player.counter + 1) % 26 == 0)
        {
            if (executeOnce)
            {
                executeOnce = false;
                SpawnEnemy();
            }
        }
        else
        {
            if (!executeOnce)
            { 
                executeOnce = true;
            }
        }
    }

    private void SpawnEnemy()
    {
        GameObject a = Instantiate(car) as GameObject;
        a.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }
}
