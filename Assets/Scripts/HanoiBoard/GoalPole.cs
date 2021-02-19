using UnityEngine;

/// <summary>
/// This object will be the destination pole where you need to put all the disks in
/// This needs the HanoiPole Conponent, otherwise, this will be useless
/// </summary>
[RequireComponent(typeof(HanoiPole))]
public class GoalPole : MonoBehaviour
{
    // The Goal quantity you need to achieve
    [SerializeField] private IntReference _discQuantity;

    // Event to ba called when the user completes the disc on this pole
    [SerializeField] private VoidEvent _onDiscComplete;

    // The pole Component of this object
    private HanoiPole _pole;

    private void Awake()
    {
        _pole = GetComponent<HanoiPole>();
    }

    private void OnEnable()
    {
        _pole.RegisterOnStackListener(EvaluateDiscs);    
    }

    private void OnDisable()
    {
        _pole.UnregisterOnStackListener(EvaluateDiscs);
    }

    /// <summary>
    /// Evaluate Discs whether or not this pole has all the discs on it
    /// </summary>
    private void EvaluateDiscs()
    {
        if(_pole.DiscCount ==_discQuantity.Value)
        {
            Debug.Log("You Win");
            _onDiscComplete.Raise();
        }
    }
}
