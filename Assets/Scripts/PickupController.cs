﻿using UnityEngine;

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
    public bool OnDiscPicked => _input.PickupPressed;
    public bool OnDiscReleased => _input.PickupReleased;

    // Disc that the player is currently holding
    public HanoiDisc CurrentlyHeldDisc;

    // Original Pole of the currently held disc
    private HanoiPole _currentDiscOriginalPole;

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
        CurrentlyHeldDisc = p_disc;

        // Hold it when it is not null
        if (CurrentlyHeldDisc)
        {
            // Cache the original pole where the disc is from
            _currentDiscOriginalPole = p_currentPole;

            // Remove the current pole parent
            CurrentlyHeldDisc.transform.SetParent(null);

            // Set new held Position
            CurrentlyHeldDisc.transform.position = _pickUpLocation;
        }
    }

    /// <summary>
    /// Puts down a specific disc
    /// </summary>
    /// /// <param name="p_pole">The pole where the disc will be placed</param>
    public void PutdownDisc(HanoiPole p_pole)
    {
        // Check if you are holding a disc
        if (CurrentlyHeldDisc)
        {
            // The topmost disc of the p_pole
            HanoiDisc currentPoleTopDisc = p_pole.PeekTopDisc;

            // Checks if there is a stack on the current pole
            if (currentPoleTopDisc)
            {
                if (CurrentlyHeldDisc.Rank < currentPoleTopDisc.Rank) // Places the disc on the stack if it is smaller than the current top of the stack
                    PutDiscOnTopOfStack(currentPoleTopDisc, p_pole);
                else // if not, reset the position
                    ResetDiscPosition();
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
        Vector3 currentDiscPosition = Vector3.zero;
        if (p_currentPoleTopDisc) // If stack is not empty, get the top of the stack to land on
            currentDiscPosition = p_currentPoleTopDisc.transform.position;
        else // If stack is empty, get the base of the board
            currentDiscPosition = new Vector3(p_pole.transform.position.x, -CurrentlyHeldDisc.YScale, p_pole.transform.position.z);

        // Calculate Landing Position based on scale
        currentDiscPosition += Vector3.up * CurrentlyHeldDisc.YScale * 2f;

        // Set position based on calculated position
        CurrentlyHeldDisc.transform.position = currentDiscPosition;
        CurrentlyHeldDisc.transform.SetParent(p_pole.transform);

        // Add it to the stack
        p_pole.AddDiscToStack(CurrentlyHeldDisc);

        // Reset the Currently Held disc
        CurrentlyHeldDisc = null;
    }

    /// <summary>
    /// Resets the original position of the currently held disc if the pole cannot be put any disc
    /// </summary>
    private void ResetDiscPosition()
    {
        Vector3 originalDiscPosition = Vector3.zero;
        HanoiDisc originalTopStack = _currentDiscOriginalPole.PeekTopDisc;

        if (originalTopStack) // If stack is not empty, get the top of the stack to land on
            originalDiscPosition = originalTopStack.transform.position;
        else // If stack is empty, get the base of the board
            originalDiscPosition = new Vector3(_currentDiscOriginalPole.transform.position.x, -CurrentlyHeldDisc.YScale, _currentDiscOriginalPole.transform.position.z);

        // Calculate Landing Position based on scale
        originalDiscPosition += Vector3.up * CurrentlyHeldDisc.YScale * 2f;

        // Set position based on calculated position
        CurrentlyHeldDisc.transform.position = originalDiscPosition;
        CurrentlyHeldDisc.transform.SetParent(_currentDiscOriginalPole.transform);

        // Add it to the stack
        _currentDiscOriginalPole.AddDiscToStack(CurrentlyHeldDisc);

        // Reset the Currently Held disc
        CurrentlyHeldDisc = null;
    }
}
