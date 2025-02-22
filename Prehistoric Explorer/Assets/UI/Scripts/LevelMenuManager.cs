using UnityEngine;

public class LevelMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private TimeManager timeManager;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            timeManager.Pause();
            menuPanel.SetActive(true);
        }
    }

    public void QuitGame()
    {
        SceneSwitcher.QuitGame();
    }

    public void MainMenu()
    {
        SceneSwitcher.LoadScene(0);
    }
}
