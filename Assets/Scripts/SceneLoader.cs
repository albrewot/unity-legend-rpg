using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentSceneIndex + 1;
        GoToScene(nextScene);
    }

    public void LoadStartGame() {
        GoToScene(0);
    }

    public void QuitGame() {
        Application.Quit();
    }

    private void GoToScene(int sceneIndex) {
        SceneManager.LoadScene(sceneIndex);
    }
}
