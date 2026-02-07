using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneController
{
    public static async void GoToScene(int n)
    {
        LoadingCover.instance.Show();
        await Task.Delay(500);
        SceneManager.LoadScene(n);
    }
}
