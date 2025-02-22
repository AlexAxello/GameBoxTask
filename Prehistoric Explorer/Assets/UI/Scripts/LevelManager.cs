using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private Transform _endGamePanel;
    private TMP_Text _endGameTitle;
    private GameObject _nextLevelButton;
    private GameObject _collectablesPanel;
    private AudioSource _audioSource;

    [SerializeField] private AudioClip deathSound;
    
    public int runeStoneActivated;
    private bool _hasCollectables;
    [SerializeField] private int runeStoneCount;
    
    
    private void Awake()
    {
        _endGamePanel = transform.GetChild(2);
        _endGameTitle = _endGamePanel.GetChild(0).GetChild(0).gameObject.GetComponent<TMP_Text>();
        _nextLevelButton = _endGamePanel.GetChild(0).GetChild(1).gameObject;
        _collectablesPanel = _endGamePanel.GetChild(0).GetChild(4).gameObject;
        _audioSource = GetComponent<AudioSource>();
        
        runeStoneActivated = 0;
        _hasCollectables = runeStoneCount > 0;
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void Win()
    {
        Time.timeScale = 0;
        _endGamePanel.gameObject.SetActive(true);
        _endGameTitle.text = "Уровень пройден";
        if (SceneManager.GetActiveScene().buildIndex >= 5)
        {
            _nextLevelButton.SetActive(false);
            _endGameTitle.text = "Игра пройдена!!!";
        }

        if (_hasCollectables)
        {
            _collectablesPanel.SetActive(true);
            _collectablesPanel.GetComponentInChildren<TMP_Text>().text = $"{runeStoneActivated} / {runeStoneCount}";
        }
    }

    public void Failure()
    {
        Time.timeScale = 0;
        _endGamePanel.gameObject.SetActive(true);
        _endGameTitle.text = "Вы погибли";
        _nextLevelButton.SetActive(false);
        _audioSource.Stop();
        _audioSource.PlayOneShot(deathSound);
    }
}
