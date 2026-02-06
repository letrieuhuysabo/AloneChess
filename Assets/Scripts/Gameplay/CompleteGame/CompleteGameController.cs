using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteGameController : MonoBehaviour
{
    public static bool completed;
    Animator anim;

    void Awake()
    {
        completed = false;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        SoundGameplayController.instance.PlayShowCompletePanelSound();
        StartCoroutine(ShowCollectedStarsCoroutine());
    }
    IEnumerator ShowCollectedStarsCoroutine()
    {
        yield return new WaitForSeconds(0.7f);
        string []triggers = {"Star1","Star2","Star3"};
        for (int i = 0; i < StarCollector.instance.StarCollected; i++)
        {
            yield return new WaitForSeconds(0.5f);
            anim.SetTrigger(triggers[i]);

        }
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
    public void PlayShowStar1Sound()
    {
        SoundGameplayController.instance.PlayShowStar1Sound();
    }
    public void PlayShowStar2Sound()
    {
        SoundGameplayController.instance.PlayShowStar2Sound();
    }
    public void PlayShowStar3Sound()
    {
        SoundGameplayController.instance.PlayShowStar3Sound();
    }
}
