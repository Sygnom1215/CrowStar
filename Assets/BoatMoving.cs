using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class BoatMoving : MonoBehaviour
{
    [SerializeField] private float second;
    [SerializeField] private Image aurora;
    public void Move()
    {
        StartCoroutine(MoveBoat());
    }

    private IEnumerator MoveBoat()
    {
        transform.DOMove(Vector2.zero, second);
        transform.DOScale(Vector2.zero, second);
        GameManager.Instance.UIManager.SetActiveButton();
        GameManager.Instance.UIManager.HideOrAppearInventory();

        yield return new WaitForSeconds(second + 1);

        aurora.DOFade(1f, 1f);
    }
}