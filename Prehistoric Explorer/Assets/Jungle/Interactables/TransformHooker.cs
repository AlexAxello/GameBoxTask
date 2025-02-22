using UnityEngine;

public class TransformHooker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.parent = transform;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.transform.parent = null;
    }
}
