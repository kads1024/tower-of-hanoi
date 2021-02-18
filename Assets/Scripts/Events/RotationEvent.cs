using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rotation Event is a scriptable object event with a RotationType parameter that serves as a channel to raise events in a more modular manner
/// </summary>
[CreateAssetMenu(menuName = "Events/Rotation Event")]
public class RotationEvent : ScriptableObject
{
    private List<RotationEventListener> _listeners = new List<RotationEventListener>();

    /// <summary>
    /// Invoke All Listeners registered to this event
    /// </summary>
    public void Raise(RotationType p_rotationType)
    {
        for (int i = _listeners.Count - 1; i >= 0; i--)
        {
            _listeners[i].OnEventRaised(p_rotationType);
        }
    }

    /// <summary>
    /// Add a certain listener for the event 
    /// </summary>
    /// <param name="p_listener">The Listener that will be added</param>
    public void RegisterListener(RotationEventListener p_listener)
    {
        _listeners.Add(p_listener);
    }

    /// <summary>
    /// Remove a certain listener for the event 
    /// </summary>
    /// <param name="p_listener">The Listener that will be removed</param>
    public void UnregisterListener(RotationEventListener p_listener)
    {
        _listeners.Remove(p_listener);
    }
}