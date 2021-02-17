using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Initialized the Tower of hanoi Board to be ready for use
/// </summary>
public class BoardInitializer : MonoBehaviour
{
    // The Disc to be used in the game
    [SerializeField] private HanoiDisc _discPrefab;

    // The poles of the current board
    [SerializeField] private HanoiPole[] _poles = new HanoiPole[3];

    // Total number of discs to be used in the current session
    // TODO: Convert to IntVariable
    [SerializeField] private int _discQuantity;

    // Initialize the values upon start of this object
    private void Start()
    {
        // List of all the current discs for the session
        List<Transform> discTransform = new List<Transform>();

        // Loop starting from the biggest disc
        HanoiDisc disc = null;
        for(int i = _discQuantity; i > 0; i--)
        {
            // First, instantiate the disc
            disc = Instantiate(_discPrefab);

            // Second, Get the order position this disc is instatiated
            int discOrderPosition = _discQuantity - i;

            // Third, Calculate the current disc's Y position
            // The disc's Y position will be twice its scale multiplied by 
            // it's order in position the offset it by the Y scale
            Vector3 discPosition = new Vector3(
                    disc.transform.position.x, 
                    (2f * disc.YScale * discOrderPosition) + disc.YScale, 
                    disc.transform.position.z);

            // Fourth, Use the Disc position to Initialize the Disc
            disc.Initialize(i, discPosition);

            // Finally, Add the disc to the list
            discTransform.Add(disc.transform);
        }

        // Initialize all poles
        for (int i = 0; i < _poles.Length; i++)     
            _poles[i].Initialize(_discQuantity, disc.YScale);

        // After Initializing the poles, Assign the Disc's Parent to the First pole
        for (int i = 0; i < discTransform.Count; i++)
            discTransform[i].SetParent(_poles[0].transform);     
    }
}
