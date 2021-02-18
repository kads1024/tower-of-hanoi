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

    // The pole Component of this object
    private HanoiPole _pole;

    private void Awake()
    {
        _pole = GetComponent<HanoiPole>();
    }

    private void Update()
    {
        if(_pole.DiscCount ==_discQuantity.Value)
        {
            Debug.Log("You Win");
        }
    }
}
