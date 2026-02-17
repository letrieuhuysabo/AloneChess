using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
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
    public Stack<GameObject> TakenSwitch { get => takenSwitch; set => takenSwitch = value; }


    [SerializeField] GameObject explosionVfxPrefab;
    Stack<GameObject> takenSwitch; // xử lý việc sau khi biến đổi thì lại chết

    void Awake()
    {
        instance = this;
        falling = false;
        dead = false;
        takenSwitch = new();
    }
    void Start()
    {
        CheckCanFall();
        // xử lý việc sau khi biến đổi thì lại chết
        MyEventTrigger.instance.PlayerFallEventTriggers.Add(() =>
        {
            StartCoroutine(ClearTakenSwitchCoroutine());
            StartCoroutine(UpdateCurrentPiece());
        });
        MyEventTrigger.instance.PlayerDeadEventTriggers.Add(() =>
        {
            while (takenSwitch.Count > 0)
            {
                GameObject switchPiece = takenSwitch.Pop();
                switchPiece.SetActive(true);
            }

            StartCoroutine(UndoPieceCoroutine());
        });
    }
    IEnumerator ClearTakenSwitchCoroutine()
    {
        // yield return new WaitForSeconds(1f);
        yield return null;
        takenSwitch.Clear();
    }
    IEnumerator UpdateCurrentPiece()
    {
        // yield return new WaitForSeconds(1f);
        yield return null;
        while (transform.childCount > 1)
        {
            Destroy(transform.GetChild(0).gameObject);
            yield return null;
            // Debug.Log(transform.childCount);
        }
        // Debug.Log("hello");
    }
    IEnumerator UndoPieceCoroutine()
    {
        while (transform.childCount > 1)
        {
            Destroy(transform.GetChild(1).gameObject);
            yield return null;
            // Debug.Log(transform.childCount);
        }
        yield return new WaitForSeconds(1f);
        transform.GetChild(0).gameObject.SetActive(true);
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
        falling = true;
        fallCoroutine = StartCoroutine(FallCoroutine(delay));
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
                EnemyAttack[] enemyAttacks = FindObjectsByType<EnemyAttack>(FindObjectsSortMode.None);
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
                    yield return new WaitForSeconds(0.2f);
                    MyEventTrigger.instance.OnPlayerFall();
                }

                break;
            }
        }
        // yield return new WaitForSeconds(1f);
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
        Destroy(explosionVfx, 3);
        MyEventTrigger.instance.OnPlayerDead();
        dead = true;
        Anim.SetTrigger("Respawn");
        await Task.Delay(1000);
        transform.position = beforePos;
        dead = false;
        falling = false;
    }
}
