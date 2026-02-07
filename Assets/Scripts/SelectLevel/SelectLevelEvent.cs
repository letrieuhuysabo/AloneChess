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
    public void ChooseLevel(TextMeshProUGUI text)
    {
        int level = int.Parse(text.text);
        SceneController.GoToScene(level+1);
    }
    public void Exit()
    {
       SceneController.GoToScene(0);
    }
}
