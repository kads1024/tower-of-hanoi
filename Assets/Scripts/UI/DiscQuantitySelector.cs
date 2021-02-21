using TMPro;
using UnityEngine;

/// <summary>
/// Used to Select the number of discs ingame.
/// </summary>
public class DiscQuantitySelector : MonoBehaviour
{
    // The disc quantity to be used in game
    [SerializeField] private IntReference _discQuantity;

    // The text to display the quantity value
    [SerializeField] private TextMeshProUGUI _discQuantityText;

    private void Start()
    {
        _discQuantity.SetVariableValue(1);
    }

    /// <summary>
    /// Closes the Selector menu
    /// </summary>
    public void CloseSelector()
    {
        gameObject.SetActive(false);
    }
    
    /// <summary>
    /// Chooses the quantity of the disc to be used in game
    /// </summary>
    /// <param name="p_quantity">The number of discs</param>
    public void ChooseQuantity(float p_quantity)
    {
        _discQuantity.SetVariableValue((int)p_quantity);
        _discQuantityText.text = "DISC QUANTITY: " + ((int)p_quantity).ToString();
    }
}
