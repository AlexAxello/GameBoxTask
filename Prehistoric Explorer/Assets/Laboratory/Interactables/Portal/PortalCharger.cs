using UnityEngine;

[RequireComponent(typeof(Portal))]
public class PortalCharger : MonoBehaviour
{
    private bool _charged;
    private int _currentBatteries;
    [SerializeField] private int requiredBatteries;

    private void Start()
    {
        _currentBatteries = 0;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(typeof(PlayerInventory), out var component))
        {
            var playerInventory = other.GetComponent<PlayerInventory>();
            _currentBatteries += playerInventory.batteries;
            playerInventory.batteries = 0;
        }

        if (_charged) return;
        
        CheckBatteries();
    }

    private void CheckBatteries()
    {
        if (_currentBatteries == requiredBatteries)
        {
            GetComponent<Portal>().charged = true;
            _charged = true;
        }
    }
}
