using UnityEngine;

public class SwitchPiece : MonoBehaviour
{
    [SerializeField] GameObject piecePrefab;
    [SerializeField] GameObject switchVfxPrefab;

    public GameObject PiecePrefab { get => piecePrefab; set => piecePrefab = value; }
    void OnDestroy()
    {
        GameObject switchVfx = Instantiate(switchVfxPrefab);
        switchVfx.transform.position = transform.position;
        Destroy(switchVfx,5);
    }
}
