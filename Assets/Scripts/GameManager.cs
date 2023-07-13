using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int restartDelay;
    [SerializeField] private GameObject failedLevelGUI;

    public void EndGame()
    {
        FindObjectOfType<Player>().enabled = false;
        Debug.Log("Game over/:");
        failedLevelGUI.SetActive(true);
        Invoke("RestartGame", restartDelay);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
