using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBack : MonoBehaviour
{
    public void Move(int addY)
    {
        GameObject[] boosters = GameObject.FindGameObjectsWithTag("gbBooster");
        foreach (GameObject booster in boosters)
        {
            booster.transform.position += new Vector3(0, addY);
        }
    }
}
