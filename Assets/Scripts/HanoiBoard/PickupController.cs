using UnityEngine;

/// <summary>
/// Controls the pick ups of the discs
/// </summary>
[CreateAssetMenu(menuName = "Controllers/Disc Pickup Controller")]
public class PickupController : ScriptableObject
{
    // The input that will control this Controller
    [SerializeField] private PlayerInput _input;

    // The location where the picked up item will be placed while holding it
    private Vector3 _pickUpLocation;

    // Checker if you are picking up a disc or not
    public bool DiscPicked => _input.PickupPressed;
    public bool DiscReleased => _input.PickupReleased;

    // Events when pocking up and releasing a disc
    [SerializeField] private VoidEvent _onDiscPickup;
    [SerializeField] private VoidEvent _onDiscPutdown;
    [SerializeField] private VoidEvent _onDiscPutdownError;

    // Disc that the player is currently holding
    private HanoiDisc _currentlyHeldDisc;

    // Original Pole of the currently held disc
    private HanoiPole _currentDiscOriginalPole;

    // The move count of the player
    [SerializeField] private IntReference _moveCount;

    /// <summary>
    /// Initializes Controller for use
    /// </summary>
    /// <param name="p_pickUpLocation">The location where the picked up item will be placed while holding it</param>
    public void Initialize(Vector3 p_pickUpLocation)
    {
        _pickUpLocation = p_pickUpLocation;
    }

    /// <summary>
    /// Picks up a specific disc
    /// </summary>
    /// <param name="p_disc">The disc to be picked up</param>
    public void PickupDisc(HanoiDisc p_disc, HanoiPole p_currentPole)
    {
        // Cache the disc currently holding
        _currentlyHeldDisc = p_disc;

        // Hold it when it is not null
        if (_currentlyHeldDisc)
        {
            // Cache the original pole where the disc is from
            _currentDiscOriginalPole = p_currentPole;

            // Remove the current pole parent
            _currentlyHeldDisc.transform.SetParent(null);

            // Set new held Position
            _currentlyHeldDisc.transform.position = _pickUpLocation;

            // Raise Pickup event
            _onDiscPickup.Raise();
        }
    }

    /// <summary>
    /// Puts down a specific disc
    /// </summary>
    /// /// <param name="p_pole">The pole where the disc will be placed</param>
    public void PutdownDisc(HanoiPole p_pole)
    {
        // Check if you are holding a disc
        if (_currentlyHeldDisc)
        {
            // The topmost disc of the p_pole
            HanoiDisc currentPoleTopDisc = p_pole.PeekTopDisc;

            // Checks if there is a stack on the current pole
            if (currentPoleTopDisc)
            {
                if (_currentlyHeldDisc.Rank <= currentPoleTopDisc.Rank) // Places the disc on the stack if it is smaller than the current top of the stack
                    PutDiscOnTopOfStack(currentPoleTopDisc, p_pole);
                else
                { // if not, reset the position
                    ResetDiscPosition();

                    // Raise the Error putdown disc Event
                    _onDiscPutdownError.Raise();
                }
            }
            else // If there is no stack, you can safely place the disc on the pole
            {
                PutDiscOnTopOfStack(currentPoleTopDisc, p_pole);
            }  
        }
    }

    /// <summary>
    /// Puts down the currently held disc on top of the current stack
    /// </summary>
    /// <param name="p_currentPoleTopDisc">The top of the current stack on the pole</param>
    /// <param name="p_pole">The pole where this disc will be placed</param>
    private void PutDiscOnTopOfStack(HanoiDisc p_currentPoleTopDisc, HanoiPole p_pole)
    {
        if(_currentlyHeldDisc)
        {
            Vector3 currentDiscPosition = Vector3.zero;
            if (p_currentPoleTopDisc) // If stack is not empty, get the top of the stack to land on
                currentDiscPosition = p_currentPoleTopDisc.transform.position;
            else // If stack is empty, get the base of the board
                currentDiscPosition = new Vector3(p_pole.transform.position.x, -_currentlyHeldDisc.YScale, p_pole.transform.position.z);

            // Calculate Landing Position based on scale
            currentDiscPosition += Vector3.up * _currentlyHeldDisc.YScale * 2f;

            // Set position based on calculated position
            _currentlyHeldDisc.transform.position = currentDiscPosition;
            _currentlyHeldDisc.transform.SetParent(p_pole.transform);

            // Update Movecount if you moved to another pole
            if (p_pole != _currentDiscOriginalPole)
                _moveCount.SetVariableValue(_moveCount.Value + 1);

            // Add it to the stack
            p_pole.AddDiscToStack(_currentlyHeldDisc);

            // Reset the Currently Held disc
            _currentlyHeldDisc = null;

            // Raise the on put down event
            _onDiscPutdown.Raise();
        }    
    }

    /// <summary>
    /// Resets the original position of the currently held disc if the pole cannot be put any disc
    /// </summary>
    public void ResetDiscPosition()
    {
        if(_currentlyHeldDisc)
        {
            Vector3 originalDiscPosition = Vector3.zero;
            HanoiDisc originalTopStack = _currentDiscOriginalPole.PeekTopDisc;

            if (originalTopStack) // If stack is not empty, get the top of the stack to land on
                originalDiscPosition = originalTopStack.transform.position;
            else // If stack is empty, get the base of the board
                originalDiscPosition = new Vector3(_currentDiscOriginalPole.transform.position.x, -_currentlyHeldDisc.YScale, _currentDiscOriginalPole.transform.position.z);

            // Calculate Landing Position based on scale
            originalDiscPosition += Vector3.up * _currentlyHeldDisc.YScale * 2f;

            // Set position based on calculated position
            _currentlyHeldDisc.transform.position = originalDiscPosition;
            _currentlyHeldDisc.transform.SetParent(_currentDiscOriginalPole.transform);

            // Add it to the stack
            _currentDiscOriginalPole.AddDiscToStack(_currentlyHeldDisc);

            // Reset the Currently Held disc
            _currentlyHeldDisc = null;
        }  
    }
}
