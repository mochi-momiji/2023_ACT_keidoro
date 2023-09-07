using UnityEngine;
using UnityEngine.SceneManagement;

public class ACT_SceneManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("StartScene");
    }
}
