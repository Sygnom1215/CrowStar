using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Leaf : MonoBehaviour
{
    private bool isDestroying;
    private void OnMouseEnter()
    {
        if (isDestroying) return;
        if (!Input.GetMouseButton(0)) return;

        isDestroying = true;
        GetComponent<SpriteRenderer>().DOFade(0f, 0.5f).OnComplete(() => Destroy(gameObject));
    }
}
