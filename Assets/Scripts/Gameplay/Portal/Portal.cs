using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public static Portal instance;

    void Awake()
    {
        instance = this;
        CompleteGameController.completed = false;
    }
    public void CompleteLevel()
    {
        SaveSystem.Singleton.Save("StarOfLevel" + Configs.currentLevel, StarCollector.instance.StarCollected + "");
        if (Configs.currentLevel < SceneManager.GetActiveScene().buildIndex)
        {
            Configs.currentLevel = SceneManager.GetActiveScene().buildIndex;
            SaveSystem.Singleton.UpdateCurrentLevelFromConfigs();
        }


        OpenCompletePanel();
        CompleteGameController.completed = true;
    }
    void OpenCompletePanel()
    {
        // Debug.Log(GameObject.Find("Canvas").transform.childCount);
        // Destroy(GameObject.Find("Canvas"),2);
        GameObject.Find("Canvas").transform.Find("CompletePanel").gameObject.SetActive(true);
        // StarCollector.instance.StarText.text = GameObject.Find("Canvas").transform.Find("CompletePanel").gameObject.activeSelf + "";
    }
}
