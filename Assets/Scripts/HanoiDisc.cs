using UnityEngine;

/// <summary>
/// The disc that will be used in the game
/// </summary>
public class HanoiDisc : MonoBehaviour
{
    // How much the Disc will be scaled
    [SerializeField] private float _scaleFactor;

    // The Position in the Hierarchy of the current pole this disc is in
    private int _rank;

    /// <summary>
    /// The Scale of the disc in the Y value
    /// </summary>
    public float YScale => transform.localScale.y;

    /// <summary>
    /// The Position in the Hierarchy of the current pole this disc is in
    /// </summary>
    public float Rank => _rank;

    /// <summary>
    /// Initializes Values for the Disc
    /// </summary>
    /// <param name="p_rank">The Position in the Hierarchy of the current pole this disc is in</param>
    /// <param name="p_position">Where the disc will be placed initially</param>
    public void Initialize(int p_rank, Vector3 p_position)
    {
        // Set the rank
        _rank = p_rank;

        // Scale the disc depending on the rank and how much it will be scaled
        transform.localScale += new Vector3(_rank * _scaleFactor, 0.0f, _rank * _scaleFactor);

        // Set the Initial Position
        transform.position = p_position;
    }
}
