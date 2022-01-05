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

    private int index = 1;

    private void Start()
    {
        SoundManager.Instance.SetBGM(index);
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
        Debug.Log(DataManager.Instance);
        if (DataManager.Instance.CurrentPlayer.watchedStory)
        {
            int value = 0;
            SoundManager.Instance.SetEffectSound(value);
            SceneManager.LoadScene(ConstantManager.MAIN_SCENE);
        }

        else
        {
            int value = 0;
            SoundManager.Instance.SetEffectSound(value);
            SceneManager.LoadScene(ConstantManager.STORY_SCENE);
        }
    }

    public void OnClickNewGame()
    {
        int value = 0;
        SoundManager.Instance.SetEffectSound(value);
        DataManager.Instance.DataClear();
        SceneManager.LoadScene(ConstantManager.STORY_SCENE);
    }
}
