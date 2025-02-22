using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    private const string MasterVolume = "MasterVolume";
    private const string MusicVolume = "MusicVolume";
    private const string SoundVolume = "SoundVolume";
    
    public float masterVolumeValue, musicVolumeValue, soundVolumeValue;

    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider soundVolumeSlider;

    private void Start()
    {
        Load();
        ApplyValues();
    }

    private void Load()
    {
        masterVolumeValue = PlayerPrefs.HasKey(MasterVolume) ? PlayerPrefs.GetFloat(MasterVolume) : 100;
        musicVolumeValue = PlayerPrefs.HasKey(MusicVolume) ? PlayerPrefs.GetFloat(MusicVolume) : 100;
        soundVolumeValue = PlayerPrefs.HasKey(SoundVolume) ? PlayerPrefs.GetFloat(SoundVolume) : 100;
    }
    
    private void ApplyValues()
    {
        masterVolumeSlider.value = masterVolumeValue;
        musicVolumeSlider.value = musicVolumeValue;
        soundVolumeSlider.value = soundVolumeValue;
        
        SetVolume(MasterVolume, masterVolumeValue);
        SetVolume(MusicVolume, musicVolumeValue);
        SetVolume(SoundVolume, soundVolumeValue);
    }

    public void UpdateVolume(int chanelId)
    {
        switch (chanelId)
        {
            case 0:
                masterVolumeValue = masterVolumeSlider.value;
                SetVolume(MasterVolume, masterVolumeValue);
                break;
            
            case 1:
                musicVolumeValue = musicVolumeSlider.value;
                SetVolume(MusicVolume, musicVolumeValue);
                break;
            
            case 2:
                soundVolumeValue = soundVolumeSlider.value;
                SetVolume(SoundVolume, soundVolumeValue);
                break;
        }
    }
    private void SetVolume(string chanelName, float value)
    {
        audioMixer.SetFloat(chanelName, SliderToDbValue(value));
    }
    private static float SliderToDbValue(float sliderValue)
    {
        return 40 * Mathf.Log10(sliderValue / 100);
    }
    
    public void ToDefault()
    {
        masterVolumeValue = 100;
        musicVolumeValue = 100;
        soundVolumeValue = 100;
        
        ApplyValues();
    }

    public void Save()
    {
        PlayerPrefs.SetFloat(MasterVolume, masterVolumeValue);
        PlayerPrefs.SetFloat(MusicVolume, musicVolumeValue);
        PlayerPrefs.SetFloat(SoundVolume, soundVolumeValue);
        PlayerPrefs.Save();
    }
}
