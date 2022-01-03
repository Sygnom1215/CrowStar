using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LightFade : MonoBehaviour
{
    private float timer = 0f;
    private bool isFade;
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1f)
        {
            if (isFade)
                image.DOFade(0.3f, 1f);

            else
                image.DOFade(1f, 1f);

            isFade = !isFade;
            timer = 0f;
        }
    }

}
