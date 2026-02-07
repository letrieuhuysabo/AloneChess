using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMoveEffectPooling : MonoBehaviour
{
    public static CanMoveEffectPooling instance;
    Queue <GameObject> pool;
    [SerializeField] int numberSpawnedAtStartGame;
    [SerializeField] GameObject canMoveEffectPrefab;
    void Awake()
    {
        instance = this;
        pool = new();
    }
    void Start()
    {
        for (int i = 0; i < numberSpawnedAtStartGame; i++)
        {
            GameObject effect = Instantiate(canMoveEffectPrefab);
            effect.SetActive(false);
            effect.transform.SetParent(transform,false);
            pool.Enqueue(effect);
        }
    }
    public GameObject TakeObj()
    {
        GameObject effect;
        if (pool.Count > 0)
        {
            effect = pool.Dequeue();
        }
        else
        {
            effect = Instantiate(canMoveEffectPrefab);
        }
        effect.SetActive(true);
        effect.transform.SetParent(null,false);
        return effect;
    }
    public void ReturnObj(GameObject effect)
    {
        Destroy(effect);
        return;
        // effect.SetActive(false);
        // effect.transform.SetParent(transform,false);
        // pool.Enqueue(effect);
    }
    public void ReturnObj(GameObject effect, float delay)
    {
        StartCoroutine(ReturnObjCoroutine(effect,delay));
    }
    IEnumerator ReturnObjCoroutine(GameObject effect, float delay)
    {
        yield return new WaitForSeconds(delay);
        ReturnObj(effect);
    }
}
