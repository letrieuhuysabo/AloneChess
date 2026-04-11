using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEvent : MonoBehaviour
{
    void Start()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;
    }
    public void Play()
    {
        SceneController.GoToScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
