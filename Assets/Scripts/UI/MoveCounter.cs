using UnityEngine;
using TMPro;

/// <summary>
/// Tracks the number of moves the player has made
/// </summary>
public class MoveCounter : MonoBehaviour
{
    // The current number of movecount
    [SerializeField] private IntReference _moveCount;

    // The text field of the move counter
    [SerializeField] private TextMeshProUGUI _moveLabel;

    private void Start()
    {
        // Reset Movec ount on start
        _moveCount.SetVariableValue(0);
    }

    /// <summary>
    /// Updates the move label UI
    /// </summary>
    public void UpdateMoveCount()
    {
        _moveLabel.text = "MOVES: " + _moveCount.Value.ToString();
    }
}
