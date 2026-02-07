using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuEvent : MonoBehaviour
{
    public void Play()
    {
        
        SceneController.GoToScene(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
