using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SkinChanger : MonoBehaviour
{
    private static readonly int IsWorking = Animator.StringToHash("isWorking");
    
    [SerializeField] private List<GameObject> skinPrefabs;
    [SerializeField] private GameObject hint;
    private Animator _animator;

    private bool _characterNearby;
    private bool _canStartWork;
    private int _currentSkinID;
    private int _skinCount;
    private GameObject _playerCharacter;
    

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _currentSkinID = 0;
        _skinCount = skinPrefabs.Count;
        _canStartWork = true;
    }

    private void Update()
    {
        if (!_canStartWork) return;
        if (!_characterNearby) return;
        if (!Input.GetKeyDown(KeyCode.E)) return;
        
        StartWork();
    }

    private void StartWork()
    {
        _animator.SetTrigger(IsWorking);
        _playerCharacter.GetComponent<PlayerInputs>().IsControllable = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _characterNearby = true;
        if (other.CompareTag("Player"))
        {
            _playerCharacter = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        _characterNearby = false;
        _playerCharacter = null;
    }

    private void ChangeSkin()
    {
        if (!_playerCharacter) return;

        _currentSkinID++;
        if (_currentSkinID > _skinCount - 1)
        {
            _currentSkinID = 0;
        }
        
        var playerPosition = _playerCharacter.transform.position;
        Destroy(_playerCharacter);
        Instantiate(skinPrefabs[_currentSkinID], playerPosition, Quaternion.identity);
    }

    private void SetWorkStateTrue()
    {
        _canStartWork = true;
        hint.SetActive(true);
    }

    private void SetWorkStateFalse()
    {
        _canStartWork = false;
        hint.SetActive(false);
    }
}
