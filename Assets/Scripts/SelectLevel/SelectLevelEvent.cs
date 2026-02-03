using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelEvent : MonoBehaviour
{
    [SerializeField] GameObject levelPrefab;
    void Start()
    {
        for (int i = 0; i < Configs.levelQuantity; i++)
        {
            GameObject level = Instantiate(levelPrefab);
            level.SetActive(true);
            level.name = "Level " + (i+1);
            level.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = (i+1) + "";
            level.transform.SetParent(levelPrefab.transform.parent,false);
        }
    }
    public async void ChooseLevel(TextMeshProUGUI text)
    {
        LoadingCover.instance.Show();
        await Task.Delay(500);
        GoToLevel(int.Parse(text.text));
    }
    void GoToLevel(int level)
    {
        SceneManager.LoadScene(level + 1);
    }
    public async void Exit()
    {
        LoadingCover.instance.Show();
        await Task.Delay(500);
        SceneManager.LoadScene(0);
    }
}
