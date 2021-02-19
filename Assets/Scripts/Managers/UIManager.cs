using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the UI In Game
/// </summary>
public class UIManager : MonoBehaviour
{
    // The pause menu to be used
    [SerializeField] private GameObject _pauseMenu;

    // UI Events
    [SerializeField] private VoidEvent _restartEvent;
    [SerializeField] private VoidEvent _homeEvent;

    /// <summary>
    /// Pauses the game
    /// </summary>
    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        _pauseMenu.SetActive(true);
    }

    /// <summary>
    /// Resumes the game
    /// </summary>
    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        _pauseMenu.SetActive(false);
    }

    /// <summary>
    /// Restarts the current game
    /// </summary>
    public void OnRestart()
    {
        _restartEvent.Raise();
    }

    /// <summary>
    /// Goes Back to the main menu
    /// </summary>
    public void OnHome()
    {
        _homeEvent.Raise();
    }
}
