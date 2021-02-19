using UnityEngine;

/// <summary>
/// Manages the disk of a currently selected pole
/// </summary>
[RequireComponent(typeof(PoleSelector))]
public class DiscManagement : MonoBehaviour
{
    // Controller used for picking up the top most disc in a pole
    [SerializeField] private PickupController _pickupController;

    // Used to pick to pole on where to get the discs from
    private PoleSelector _poleSelector;

    private void Awake()
    {
        _poleSelector = GetComponent<PoleSelector>();
    }

    private void Update()
    {
        if(_pickupController.DiscPicked)    
            _pickupController.PickupDisc(_poleSelector.TopDisc, _poleSelector.CurrentlySelectedPole);     
        else if (_pickupController.DiscReleased)      
            _pickupController.PutdownDisc(_poleSelector.CurrentlySelectedPole);   
    }
}
