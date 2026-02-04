using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class StarCollector : MonoBehaviour
{
    int starCollected;
    public static StarCollector instance;
    TextMeshProUGUI starText;
    void Start()
    {
        instance = this;
        starText = GameObject.Find("Canvas").transform.Find("StarCollected").Find("Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>();
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
        starText.text = "x" + starCollected;
    }
}
