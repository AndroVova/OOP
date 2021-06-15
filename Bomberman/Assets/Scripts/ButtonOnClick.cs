using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOnClick : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
    public void OpenSettings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void OpenPVPMap()
    {
        SceneManager.LoadScene("PvpMap");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
