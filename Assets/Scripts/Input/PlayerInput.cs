using UnityEngine;

/// <summary>
/// Object used for assigning which Player Controls will be used for the game
/// </summary>
[CreateAssetMenu(menuName = "Input/Player Input")]
public class PlayerInput : ScriptableObject
{
    // Movement of the Hanoi Base
    [SerializeField] private KeyCode _moveLeft;
    [SerializeField] private KeyCode _moveRight;

    // Used for picking up the top most piece of a certain pole
    [SerializeField] private KeyCode _pickUp;

    /// <summary>
    /// Checks if the user has pressed the MoveLeft key
    /// </summary>
    /// <returns>Returns true if the user has pressed the MoveLeft Key</returns>
    public bool MoveLeftPressed()
    {
        return Input.GetKeyDown(_moveLeft);
    }

    /// <summary>
    /// Checks if the user has pressed the MoveRight key
    /// </summary>
    /// <returns>Returns true if the user has pressed the MoveRight Key</returns>
    public bool MoveRightPressed()
    {
        return Input.GetKeyDown(_moveRight);
    }

    /// <summary>
    /// Checks if the user has pressed the PickUp key
    /// </summary>
    /// <returns>Returns true if the user has pressed the PickUp Key</returns>
    public bool PickupPressed()
    {
        return Input.GetKeyDown(_pickUp);
    }
}
