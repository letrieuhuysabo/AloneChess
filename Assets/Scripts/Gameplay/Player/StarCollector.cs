using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class StarCollector : MonoBehaviour
{
    int starCollected;
    public static StarCollector instance;
    TextMeshProUGUI starText;
    [SerializeField] GameObject gainStarVfxPrefab;
    Stack <GameObject> cacheStars;

    public int StarCollected { get => starCollected; set => starCollected = value; }

    void Start()
    {
        instance = this;
        cacheStars = new();
        starText = GameObject.Find("Canvas").transform.Find("StarCollected").Find("Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>();
        starCollected = 0;
        MyEventTrigger.instance.PlayerFallEventTriggers.Add(() => {cacheStars.Clear();});
        MyEventTrigger.instance.PlayerDeadEventTriggers.Add(() =>
        {
            while (cacheStars.Count > 0)
            {
                GameObject star = cacheStars.Pop();
                star.gameObject.SetActive(true);
                starCollected--;
                UpdateStarCollected();
            }
        });
        UpdateStarCollected();
    }
    public void CollectStar(GameObject star)
    {
        starCollected++;
        cacheStars.Push(star);
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
