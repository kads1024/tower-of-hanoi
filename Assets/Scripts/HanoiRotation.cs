using UnityEngine;

/// <summary>
/// Component that rotates the object by _rotationOffset degress controlled by _input
/// </summary>
public class HanoiRotation : MonoBehaviour
{
    [Tooltip("Input Controls that will control the rotation of this object")]
    [SerializeField] private PlayerInput _input;

    [Tooltip("Rotation value to increment whenever you rotate this object")]
    [SerializeField, Range(0, 360)] private float _rotationOffset;

    private void Update()
    {
        if(_input.MoveRightPressed())
        {
            // Rotate the object by the Y-axis
            transform.eulerAngles += transform.up * _rotationOffset;
        }
        else if (_input.MoveLeftPressed())
        {
            // Rotate the object by the Y-axis
            transform.eulerAngles -= transform.up * _rotationOffset;
        }
    }
}
