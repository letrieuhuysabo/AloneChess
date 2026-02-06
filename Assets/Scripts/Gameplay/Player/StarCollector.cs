using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class StarCollector : MonoBehaviour
{
    int starCollected;
    public static StarCollector instance;
    TextMeshProUGUI starText;
    [SerializeField] GameObject gainStarVfxPrefab;

    public int StarCollected { get => starCollected; set => starCollected = value; }

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
        SoundGameplayController.instance.PlayGainStarSound();
        UpdateStarCollected();
    }
    public void SpawnGainStarVfx(Vector3 pos)
    {
        GameObject gainStarVfx = Instantiate(gainStarVfxPrefab);
        gainStarVfx.transform.position = pos;
        Destroy(gainStarVfx,3);
    }
    public void UpdateStarCollected()
    {
        starText.text = "x" + starCollected;
    }
}
