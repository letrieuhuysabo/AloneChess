using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelEvent : MonoBehaviour
{
    [SerializeField] GameObject levelPrefab;
    void Start()
    {
        for (int i = 0; i < Configs.currentLevel; i++)
        {
            if (i >= Configs.levelQuantity)
            {
                break;
            }
            CreateLevel(i+1);
        }
    }
    public void ChooseLevel(TextMeshProUGUI text)
    {
        int level = int.Parse(text.text);
        SceneController.GoToScene(level + 1);
    }
    public void Exit()
    {
        SceneController.GoToScene(0);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Configs.currentLevel++;
            SaveSystem.Singleton.UpdateCurrentLevelFromConfigs();
            CreateLevel(Configs.currentLevel);
            
        }
    }
    void CreateLevel(int levelNumber)
    {
        GameObject level = Instantiate(levelPrefab);
        level.SetActive(true);
        level.name = "Level " + levelNumber;
        level.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = levelNumber + "";
        level.transform.SetParent(levelPrefab.transform.parent, false);
        // load star data
        string dataStar = SaveSystem.Singleton.Load("StarLevel" + levelNumber);
        if (dataStar != null)
        {
            int starQuantity = int.Parse(dataStar);
            for (int i = 0; i < starQuantity; i++)
            {
                level.transform.GetChild(2).GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
