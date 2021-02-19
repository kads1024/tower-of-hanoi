using UnityEngine;

/// <summary>
/// Object used for assigning which Player Controls will be used for the game
/// </summary>
[CreateAssetMenu(menuName = "Input/Player Input")]
public class PlayerInput : ScriptableObject
{
    // Rotation of the Hanoi Base
    [SerializeField] private KeyCode _rotateLeft;
    [SerializeField] private KeyCode _rotateRight;

    // Used for picking up the top most piece of a certain pole
    [SerializeField] private KeyCode _pickUp;

    /// <summary>
    /// Checks if the user has pressed the RotateLeft key and the game is not paused
    /// </summary>
    public bool RotateLeftPressed => Input.GetKeyDown(_rotateLeft) && Time.timeScale != 0.0f;

    /// <summary>
    /// Checks if the user has pressed the RotateRight key and the game is not paused
    /// </summary>
    public bool RotateRightPressed  => Input.GetKeyDown(_rotateRight) && Time.timeScale != 0.0f;

    /// <summary>
    /// Checks if the user has pressed the PickUp key and the game is not paused
    /// </summary>
    public bool PickupPressed => Input.GetKeyDown(_pickUp) && Time.timeScale != 0.0f;

    /// <summary>
    /// Checks if the user has released the PickUp key and the game is not paused
    /// </summary>
    public bool PickupReleased => Input.GetKeyUp(_pickUp) && Time.timeScale != 0.0f;
}
