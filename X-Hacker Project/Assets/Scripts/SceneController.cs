using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public int loadScene;
    public int currentScene;

    public void LoadLevel()
    {
        SceneManager.LoadScene(loadScene);
    }
    
    public void ReloadLevel()
    {
        SceneManager.LoadScene(currentScene);
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}