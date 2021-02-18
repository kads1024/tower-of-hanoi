using UnityEngine;

/// <summary>
/// Serves as a reference for Integers, both shared and non-shared
/// </summary>
[System.Serializable]
public class IntReference
{
    [SerializeField] private bool _useConstant = true;

    // If UseConstant is true, this will appear in the inspector so that you will only supply a constant value
    [SerializeField] private int _constantValue;

    // If UseConstant is false, it means that the User wants to use a shared data
    [SerializeField] private IntVariable _variable;

    // The Value to be used for this IntReference
    public int Value => _useConstant ? _constantValue : _variable.Value;
}
