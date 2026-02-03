using TMPro;
using UnityEngine;

public class StarCollector : MonoBehaviour
{
    int starCollected;
    public static StarCollector instance;
    void Start()
    {
        instance = this;
        starCollected = 0;
        UpdateStarCollected();
    }
    public void CollectStar()
    {
        starCollected++;
        UpdateStarCollected();
    }
    public void UpdateStarCollected()
    {
        GameObject.Find("Canvas").transform.Find("StarCollected").Find("Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text = "x" + starCollected;
    }
}
