using UnityEngine;

/// <summary>
/// Manages the picking up of discs
/// </summary>
public class PickupManager : ScriptableObject
{
    [Tooltip("Input Controls that will control the rotation of this object")]
    [SerializeField] private PlayerInput _input;

    /// <summary>
    /// Check if the player has pressed pick up
    /// </summary>
    public bool HasPickedUp => _input.PickupPressed;

    /// <summary>
    /// Check if the player has released pickup
    /// </summary>
    public bool HasPutDown => _input.PickupReleased;

}
