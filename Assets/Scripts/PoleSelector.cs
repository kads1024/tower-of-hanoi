using UnityEngine;

/// <summary>
/// Used to currently select a single pole
/// </summary>
public class PoleSelector : MonoBehaviour
{
    // Index of the current selected pole
    private int _currentlySelectedPole;

    // List of poles in the game
    [SerializeField] private HanoiPole[] _poles = new HanoiPole[3];

    private void Start()
    {
        _currentlySelectedPole = 0;    
    }

    /// <summary>
    /// Update the selected pole based on rotation
    /// </summary>
    /// <param name="p_rotationType">Whether the rotation is to the left or to the right</param>
    public void UpdateSelectedPoleFromRotation(RotationType p_rotationType)
    {
        // Add the rotation
        _currentlySelectedPole += (int)p_rotationType;

        // Repeat the values between 0 and pole count
        if (_currentlySelectedPole >= _poles.Length) _currentlySelectedPole = 0;
        else if (_currentlySelectedPole < 0) _currentlySelectedPole = _poles.Length - 1;
    }
}
