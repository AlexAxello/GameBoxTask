using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private GameObject portalGate;
    
    private bool _canActivate;
    public bool charged;

    private void Start()
    {
        _canActivate = false;
        portalGate.SetActive(charged);
    }

    private void Update()
    {
        if (!charged) return;
        
        if (!portalGate.activeSelf) portalGate.SetActive(true);
        
        if (!_canActivate) return;
        if (!Input.GetKeyDown(KeyCode.E)) return;
        
        Onclick();
    }
    
    private void Onclick()
    {
        SceneSwitcher.LoadNext();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _canActivate = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        _canActivate = false;
    }
}
