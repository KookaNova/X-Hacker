using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public int[] loadScene;
    public int currentScene;

    public UnityEvent levelLoadingEvent, levelLoadingWhileEvent, levelLoadingWhile90PercentEvent;

    public AsyncOperation sceneLoad;

    public void LoadLevel(int scene)
    {
        StartCoroutine(asyncLoad(scene));
    }

    private IEnumerator asyncLoad(int scene)
    {
        sceneLoad = SceneManager.LoadSceneAsync(scene);
        sceneLoad.allowSceneActivation = false;
        levelLoadingEvent.Invoke();
        
        //things to do while the level is loading
        while (!sceneLoad.isDone)
        {
            levelLoadingWhileEvent.Invoke();
            
            //things to do while the level is >90% loaded
            if (sceneLoad.progress >= 0.9f)
            {
                levelLoadingWhile90PercentEvent.Invoke();
                yield return new WaitForSeconds(.5f);
                sceneLoad.allowSceneActivation = true;
            }
            
            yield return null;
        }
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