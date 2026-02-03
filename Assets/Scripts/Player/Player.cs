using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    Animator anim;
    bool falling;
    
    public Animator Anim { get => GetComponentInChildren<Animator>(); set => anim = value; }
    public bool Falling { get => falling; set => falling = value; }

    void Awake()
    {
        instance = this;
        falling = true;
    }
    void Start()
    {
        Fall();
    }
    public void Fall(float delay = 0)
    {
        falling = true;
        StartCoroutine(FallCoroutine(delay));
    }
    IEnumerator FallCoroutine(float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        
        float fallDuration = 0.3f;
        while (true)
        {
            Vector3 pos = transform.position;
            Vector3 target = pos + Vector3.down;
            if (MapController.instance.IsEmpty(target))
            {

                float duration = fallDuration;
                while (duration > 0)
                {

                    transform.position = new Vector3(pos.x, Mathf.Lerp(target.y, pos.y, duration / fallDuration), 0);
                    duration -= Time.deltaTime;
                    yield return null;
                }
                transform.position = target;
            }
            else
            {

                break;
            }
        }
        falling = false;
        ChessPiece.clicked = false;
    }
    
}
