using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MainSceneButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Text text;
    [SerializeField] Color color;
    Color originColor;

    private void Start()
    {
        text = GetComponentInChildren<Text>();
        originColor = text.color;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = color;
        transform.DOScale(1.2f, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = originColor;
        transform.DOScale(1f, 0.3f);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void OnClickPlay()
    {
        SceneManager.LoadScene(ConstantManager.STORY_SCENE);
    }
}
