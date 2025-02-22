using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonStand : MonoBehaviour
{
    private static readonly int IsPressed = Animator.StringToHash("isPressed");
    
    [SerializeField] private Animator animator;
    
    private Button _button;
    private bool _canPress;

    private void Start()
    {
        _canPress = false;
        _button = GetComponent<Button>();
    }

    private void Update()
    {
        if (!_canPress) return;
        if (!Input.GetKeyDown(KeyCode.E)) return;

        OnPress();
    }

    private void OnPress()
    {
        animator.SetTrigger(IsPressed);
        _button.onClick.Invoke();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _canPress = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        _canPress = false;
    }
}
