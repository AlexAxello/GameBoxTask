using UnityEngine;

public class Battery : MonoBehaviour
{
    private bool _canBeCollected;
    private Collider2D _collidedObject;

    private void Start()
    {
        _canBeCollected = false;
        _collidedObject = null;
    }

    private void Update()
    {
        if (!_canBeCollected) return;
        if (!Input.GetKeyDown(KeyCode.E)) return;

        _collidedObject.GetComponent<PlayerInventory>().batteries++;
        
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        _canBeCollected = true;
        _collidedObject = other;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _canBeCollected = false;
        _collidedObject = null;
    }
}
