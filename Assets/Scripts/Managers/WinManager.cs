using TMPro;
using UnityEngine;

/// <summary>
/// Manages the Win System In Game
/// </summary>
public class WinManager : MonoBehaviour
{
    // The pause menu to be used
    [SerializeField] private GameObject _winMenu;

    // Moves used during the game
    [SerializeField] private IntReference _moveCount;

    // Move Count UI text
    [SerializeField] private TextMeshProUGUI _moveCountText;

    /// <summary>
    /// Shows the win game menu
    /// </summary>
    public void WinGame()
    {
        // Pause the game so that player cannot input anything
        Time.timeScale = 0.0f;
        
        // Set win text
        string moveText = _moveCount.Value > 1 ? " MOVES" : " MOVE";
        _moveCountText.text = _moveCount.Value.ToString() + moveText;

        // Show Win UI
        _winMenu.SetActive(true);
    }
}
