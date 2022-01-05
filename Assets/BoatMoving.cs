using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class BoatMoving : MonoBehaviour
{
    [SerializeField] private float second;
    [SerializeField] private Image aurora;
    [SerializeField] private Text auroraText;
    [SerializeField] private GameObject ui;

    public void Move()
    {
        SoundManager.Instance.SetEffectSound(9);
        StartCoroutine(MoveBoat());
    }

    private IEnumerator MoveBoat()
    {
        transform.DOMove(Vector2.zero, second);
        transform.DOScale(Vector2.zero, second);
        ui.SetActive(false);

        yield return new WaitForSeconds(second / 2);
        GetComponent<Image>().DOFade(0f, 1f);
        yield return new WaitForSeconds(second / 2 + 1);

        aurora.DOFade(1f, 3f);
        yield return new WaitForSeconds(second / 4f);
        auroraText.DOFade(1f, 1f);

        yield return new WaitForSeconds(1f);

        aurora.DOColor(Color.black, 2f);

        yield return new WaitForSeconds(2f);

        GameManager.Instance.GameEnd();

    }
}