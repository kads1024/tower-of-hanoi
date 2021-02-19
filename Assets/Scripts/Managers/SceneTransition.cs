using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// The Manager that controls transition between scenes
/// </summary>
public class SceneTransition : MonoBehaviour
{
    /// <summary>
    /// Transitions to the Game Over Screen
    /// </summary>
    public void OpenGameOverScreen()
    {
        SceneManager.LoadScene(Constants.GAME_OVER_SCENE);
    }

    /// <summary>
    /// Transitions to the main game scene
    /// </summary>
    public void OpenMainGameScene()
    {
        SceneManager.LoadScene(Constants.MAIN_GAME_SCENE);
    }
}
