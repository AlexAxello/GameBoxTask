using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position = respawnPoint.position;
        _audioSource.PlayOneShot(_audioSource.clip);
    }
}
