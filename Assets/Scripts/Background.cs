using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public void Move(float y)
    {
        GameObject[] bgs = GameObject.FindGameObjectsWithTag("BG");
        foreach (GameObject bg in bgs)
        {
            bg.transform.position += new Vector3(0, y);
        }
    }
    private void Update()
    {
        if (transform.position.y < -31)
        {
            transform.position = new Vector3(0, 16);
        }
        else if((transform.position.y > 31))
        {
            transform.position = new Vector3(0, -16);
        }
    }
}
