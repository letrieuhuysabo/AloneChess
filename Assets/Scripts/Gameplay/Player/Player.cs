using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    Animator anim;
    bool falling, dead;
    Coroutine fallCoroutine;
    Vector3 beforePos;
    
    public Animator Anim { get => GetComponentInChildren<Animator>(); set => anim = value; }
    public bool Falling { get => falling; set => falling = value; }
    public Vector3 BeforePos { get => beforePos; set => beforePos = value; }
    public bool Dead { get => dead; set => dead = value; }
    [SerializeField] GameObject explosionVfxPrefab;

    void Awake()
    {
        instance = this;
        falling = false;
        dead = false;
    }
    void Start()
    {
        CheckCanFall();
    }
    async void CheckCanFall()
    {
        await Task.Yield();
        // await Task.Delay(5000);
        Vector3 bottomPos = transform.position + Vector3.down;
        if (MapController.instance.IsEmpty(bottomPos))
        {
            Fall();
        }
    }
    public void Fall(float delay = 0)
    {
        
        Vector3 bottomPos = transform.position + Vector3.down;
        if (MapController.instance.IsEmpty(bottomPos))
        {
            falling = true;
            fallCoroutine = StartCoroutine(FallCoroutine(delay));
        }
    }
    IEnumerator FallCoroutine(float delay = 0)
    {
        yield return new WaitForSeconds(delay);
        
        float fallDuration = 0.2f;
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
                MyEventTrigger.instance.OnPlayerMove();
            }
            else
            {
                bool flag = true;
                EnemyAttack []enemyAttacks = FindObjectsByType<EnemyAttack>(FindObjectsSortMode.None);
                foreach (EnemyAttack enemyAttack in enemyAttacks)
                {
                    if (enemyAttack.LandingPos == Configs.ConvertVectorToInt(target))
                    {
                        Respawn();
                        flag = false;
                    }
                }
                if (flag)
                {
                    SoundGameplayController.instance.PlayLandingSound();
                    MyEventTrigger.instance.OnPlayerFall();
                }
                
                break;
            }
        }
        falling = false;
        
    }
    public void Move(Vector3 target)
    {
        transform.position = target;
        MyEventTrigger.instance.OnPlayerMove();
        Fall(0.25f);
    }
    public async void Respawn()
    {
        if (fallCoroutine != null)
        {
            StopCoroutine(fallCoroutine);
        }
        SoundGameplayController.instance.PlayAttackedSound();
        GameObject explosionVfx = Instantiate(explosionVfxPrefab);
        explosionVfx.transform.position = transform.position;
        Destroy(explosionVfx,3);
        dead = true;
        Anim.SetTrigger("Respawn");
        await Task.Delay(1000);
        transform.position = beforePos;
        dead = false;
        falling = false;
    }
}
