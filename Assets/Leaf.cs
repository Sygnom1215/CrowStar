using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Leaf : MonoBehaviour
{
    private bool isDestroying;
    [SerializeField] private Color32[] colors;

    private void Start()
    {
       GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];
    }

    private void OnMouseEnter()
    {
        if (isDestroying) return;
        if (!Input.GetMouseButton(0)) return;

        isDestroying = true;
        GetComponent<SpriteRenderer>().DOFade(0f, 0.5f).OnComplete(() => Destroy(gameObject));
    }
    private void OnMouseUp()
    {
        if (isDestroying) return;
        isDestroying = true;
        GetComponent<SpriteRenderer>().DOFade(0f, 0.5f).OnComplete(() => Destroy(gameObject));
    }
}
