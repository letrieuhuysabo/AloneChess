using UnityEngine;

public class Portal : MonoBehaviour
{
    public static Portal instance;

    void Awake()
    {
        instance = this;

    }
    public void CompleteLevel()
    {
        Configs.currentLevel++;

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
