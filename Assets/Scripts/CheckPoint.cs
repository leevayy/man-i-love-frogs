using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Vector2 screenBounds;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)) - new Vector3(1, 1);
    }

    private void Update()
    {
        if (transform.position.y < -screenBounds.y - 5 /*|| cpTransform.position.y > screenBounds.y*/)
        {
            float rndX = UnityEngine.Random.Range(1, screenBounds.x);
            if (transform.position.x < 0)
            {
                rndX = -rndX;
            }
            transform.position = new Vector3(rndX, screenBounds.y);
        }
        if (transform.position.y > screenBounds.y + 5)
        {
            float rndX = UnityEngine.Random.Range(1, screenBounds.x);
            if(transform.position.x < 0)
            {
                rndX = -rndX;
            }
            transform.position = new Vector3(rndX, -screenBounds.y);
        }

    }

    public void Move(int addY)
    {
        GameObject[] cps = GameObject.FindGameObjectsWithTag("CP");
        foreach (GameObject cp in cps)
        {
            cp.transform.position += new Vector3(0, addY);
        }
    }
}
