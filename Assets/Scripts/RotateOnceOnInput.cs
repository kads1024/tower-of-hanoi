using System.Collections;
using UnityEngine;

/// <summary>
/// Component that rotates the object by _rotationOffset degress controlled by _input
/// </summary>
public class RotateOnceOnInput : MonoBehaviour
{
    [Tooltip("Input Controls that will control the rotation of this object")]
    [SerializeField] private PlayerInput _input;

    [Tooltip("Event that will be raised when the object has rotated")]
    [SerializeField] private RotationEvent _onRotate;

    [Tooltip("Rotation value to increment whenever you rotate this object")]
    [SerializeField, Range(0, 360)] private float _rotationOffset;

    // How fast the object will rotate
    [SerializeField, Range(0, 10)] private float _rotationSpeed;

    // Checker to see if the object is currently rotating
    private bool _isCurrentlyRotating = false;

    private void Update()
    {
        if(_input.RotateRightPressed && !_isCurrentlyRotating)
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.Euler(transform.eulerAngles + (transform.up * _rotationOffset));

            _isCurrentlyRotating = true;
            StartCoroutine(InterpolateRotation(currentRotation, targetRotation));
            _onRotate.Raise(RotationType.RIGHT);
        }
        else if (_input.RotateLeftPressed && !_isCurrentlyRotating)
        {
            Quaternion currentRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.Euler(transform.eulerAngles - (transform.up * _rotationOffset));

            _isCurrentlyRotating = true;
            StartCoroutine(InterpolateRotation(currentRotation, targetRotation));
            _onRotate.Raise(RotationType.LEFT);
        }
    }

    /// <summary>
    /// Interpolates between p_startRotation and p_endRotation
    /// </summary>
    /// <param name="p_startRotation">Starting rotation of the object</param>
    /// <param name="p_endRotation">Target rotation to interpolate to</param>
    private IEnumerator InterpolateRotation(Quaternion p_startRotation, Quaternion p_endRotation)
    {
        // Reset the timer based on the rotation speed
        float lerpTimer = 1f / _rotationSpeed;
        float initialTime = lerpTimer;

        // Interpolate between the start and end rotation based on the interpolation timer and rotation speed
        while (lerpTimer > 0.0f)
        {
            lerpTimer -= Time.deltaTime;
            transform.rotation = Quaternion.Slerp(p_startRotation, p_endRotation, (initialTime - lerpTimer) * _rotationSpeed);

            yield return new WaitForEndOfFrame();
        }

        _isCurrentlyRotating = false;
    }
}

public enum RotationType
{
    LEFT = -1,
    RIGHT = 1
}