using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CharacterSounds : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip step;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Step()
    {
        _audioSource.PlayOneShot(step);
    }
}
