using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuideButton : MonoBehaviour
{
    public void ShowGuide()
    {
        SceneManager.LoadScene("GuideScene");
    }
    public void CloseGuide()
    {
        SceneManager.LoadScene("Menu");
    }
}
