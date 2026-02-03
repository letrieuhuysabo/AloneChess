using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteGameController : MonoBehaviour
{
    public static bool completed;

    void Awake()
    {
        completed = false;
    }
    public async void NextLevel()
    {
        LoadingCover.instance.Show();
        await Task.Delay(500);
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene+1);
    }
    public async void Back()
    {
        LoadingCover.instance.Show();
        await Task.Delay(500);
        SceneManager.LoadScene(1);
    }
    public async void Exit()
    {
        LoadingCover.instance.Show();
        await Task.Delay(500);
        SceneManager.LoadScene(0);
    }
}
