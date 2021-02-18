using UnityEngine;

/// <summary>
/// Used to currently select a single pole
/// </summary>
public class PoleSelector : MonoBehaviour
{
    // Index of the current selected pole
    private int _currentPoleIndex;

    // List of poles in the game
    [SerializeField] private HanoiPole[] _poles = new HanoiPole[3];
    public HanoiDisc TopDisc => _poles[_currentPoleIndex].TopDisc;

    // Currently Selected Pole
    public HanoiPole CurrentlySelectedPole => _poles[_currentPoleIndex];

    // Initializes the Pole Selector
    public void Start()
    {
        _currentPoleIndex = 0;
    }

    /// <summary>
    /// Update the selected pole based on rotation
    /// </summary>
    /// <param name="p_rotationType">Whether the rotation is to the left or to the right</param>
    public void UpdateSelectedPoleFromRotation(RotationType p_rotationType)
    {
        // Add the rotation
        _currentPoleIndex += (int)p_rotationType;

        // Repeat the values between 0 and pole count
        if (_currentPoleIndex >= _poles.Length) _currentPoleIndex = 0;
        else if (_currentPoleIndex < 0) _currentPoleIndex = _poles.Length - 1;
    }
}
