using System.Collections;
using System.Threading.Tasks;
using TMPro;
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
        // ChessPiece
        SoundGameplayController.instance.PlayShowCompletePanelSound();
        // Destroy(Player.instance.gameObject);
        StartCoroutine(ShowCollectedStarsCoroutine());
        TextMeshProUGUI description = transform.Find("Panel").Find("Description").GetComponent<TextMeshProUGUI>();
        int starCollected = StarCollector.instance.StarCollected;
        if (starCollected == 0)
        {
            description.text = "Good job";
        }
        else if (starCollected == 1)
        {
            description.text = "Great !";
        }
        else if (starCollected == 2)
        {
           description.text = "Excellent !!"; 
        }
        else
        {
            description.text = "Perfect !!!";
        }
        TextMeshProUGUI levelText = transform.Find("Panel").Find("Level").GetComponent<TextMeshProUGUI>();
        levelText.text = "Level " + (SceneManager.GetActiveScene().buildIndex - 1);
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
    public void NextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneController.GoToScene(currentScene+1);
    }
    public void ReplayLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneController.GoToScene(currentScene);
    }
    public void Back()
    {
        SceneController.GoToScene(1);
    }
    public void Exit()
    {
        SceneController.GoToScene(0);
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
