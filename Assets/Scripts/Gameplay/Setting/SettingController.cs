using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    [SerializeField] Slider soundVolumeSlider;
    [SerializeField] Image soundImage;
    [SerializeField] Sprite soundOn, soundOff;
    void Start()
    {
        soundVolumeSlider.value = SoundVolume.currentVolume;
    }
    public void OpenSetting()
    {
        gameObject.SetActive(true);
    }
    public void CloseSetting()
    {
        gameObject.SetActive(false);
    }
    public void Replay()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneController.GoToScene(currentScene);
    }
    public void ExitToMenu()
    {
        SceneController.GoToScene(0);
    }
    public void ExitToSelectLevel()
    {
        SceneController.GoToScene(1);
    }
    public void SoundBtnOnclick()
    {
        Debug.Log(SoundVolume.saveVolume);
        if (soundVolumeSlider.value > 0)
        {
            SoundVolume.saveVolume = soundVolumeSlider.value;
            SoundVolume.currentVolume = 0;
            soundVolumeSlider.value = 0;
            
        }
        else
        {
            Debug.Log("hello");
            SoundVolume.saveVolume = soundVolumeSlider.value;
            SoundVolume.currentVolume = SoundVolume.saveVolume;
            soundVolumeSlider.value = SoundVolume.saveVolume;
        }
    }
    public void SoundVolumeControlelrOnchanged()
    {
        SoundGameplayController.instance.AudioSource.volume = soundVolumeSlider.value;
        SoundController.instance.AudioSource.volume = soundVolumeSlider.value;
        SoundVolume.currentVolume = soundVolumeSlider.value;
        if (soundVolumeSlider.value == 0)
        {
            soundImage.sprite = soundOff;
        }
        else
        {
            soundImage.sprite = soundOn;
        }
    }
}
