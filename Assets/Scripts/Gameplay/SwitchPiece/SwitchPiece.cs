using UnityEngine;

public class SwitchPiece : MonoBehaviour
{
    [SerializeField] GameObject piecePrefab;
    [SerializeField] GameObject switchVfxPrefab;

    public GameObject PiecePrefab { get => piecePrefab; set => piecePrefab = value; }
    public GameObject SwitchVfxPrefab { get => switchVfxPrefab; set => switchVfxPrefab = value; }
}
