using UnityEngine;

public class AuraAttacktion : MonoBehaviour
{
    public static AuraAttacktion instance;
    void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if (Player.instance != null)
        {
            transform.position = Player.instance.gameObject.transform.position;
        }

    }
    public void ShowAura(bool isShow)
    {
        transform.GetChild(0).gameObject.SetActive(isShow);
    }
}
