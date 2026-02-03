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
        CompleteGameController.completed = true;
        OpenCompletePanel();
    }
    void OpenCompletePanel()
    {
        GameObject.Find("Canvas").transform.Find("CompletePanel").gameObject.SetActive(true);
    }
}
