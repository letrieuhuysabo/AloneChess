using UnityEngine;

public class LoadingCover : MonoBehaviour
{
    
    Animator anim;
    public static LoadingCover instance;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Show()
    {
        anim.SetTrigger("show");
    }
    public void Hide()
    {
        anim.SetTrigger("hide");
    }
}
