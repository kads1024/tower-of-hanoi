using UnityEngine;

/// <summary>
/// Manages the Main Menu parts
/// </summary>
public class MainMenuManager : MonoBehaviour
{
    // The Menu for choosing the number of discs
    [SerializeField] private GameObject _discQuantityChooser;

    /// <summary>
    /// Opens up the Disc Quantity Slider menu to choose disc quantity in game
    /// </summary>
    public void ChooseDiscQuantity()
    {
        _discQuantityChooser.SetActive(true);
    }

    /// <summary>
    /// Closes the Disc Quantity Slider menu to choose disc quantity in game
    /// </summary>
    public void CloseDiscQuantity()
    {
        _discQuantityChooser.SetActive(false);
    }
}
