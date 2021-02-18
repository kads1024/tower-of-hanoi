﻿using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Pole that will serve as the cointainers for the HanoiDiscs
/// </summary>
public class HanoiPole : MonoBehaviour
{
    // How much will the pole be scaled in the Y direction
    private float _scaleFactor;

    [Tooltip("How much allowance will the pole have on top when every disc is stacked on one pole")]
    [SerializeField] private FloatReference _poleTopOffset;

    // Total discs for the current game
    private int _discQuantity;

    // The stack of discs this pole currently has
    private Stack<HanoiDisc> _discStack = new Stack<HanoiDisc>();

    /// <summary>
    /// Gets the Top disc and removes it
    /// </summary>
    public HanoiDisc TopDisc => _discStack.Pop();

    /// <summary>
    /// Gets the Top disc but does not remove it
    /// </summary>
    public HanoiDisc PeekTopDisc => _discStack.Peek();

    /// <summary>
    /// Initializes the pole to be ready to use for the game
    /// </summary>
    /// <param name="p_discQuantity">The total number of discs that can fit in a pole</param>
    /// <param name="p_scaleFactor">How much will the pole be scaled in the Y direction, usually set to the Y scale of the disc</param>
    public void Initialize(int p_discQuantity, float p_scaleFactor)
    {
        // Set Values for the disc quantity and scale factor
        _discQuantity = p_discQuantity;
        _scaleFactor = p_scaleFactor;

        // Set the scale in terms of height depending on the number of disc and how much it will be scaled
        transform.localScale = new Vector3(transform.localScale.x, (_discQuantity * _scaleFactor) + _poleTopOffset.Value, transform.localScale.z);

        // Then set the Y position to its current scale
        transform.position = new Vector3(transform.position.x, transform.localScale.y, transform.position.z);
    }

    /// <summary>
    /// Adds a certain disc to the pole's stack
    /// </summary>
    /// <param name="p_disc">The disc to be added</param>
    public void AddDiscToStack(HanoiDisc p_disc)
    {
        _discStack.Push(p_disc);
    } 
}