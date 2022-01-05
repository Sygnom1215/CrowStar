using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class DialogDisplay : MonoBehaviour
{
    public Conversation conversation = null;
    public GameObject talkerOther;
    public TalkUI talkerUIOther;

    private DialogueManager dialogueManager = null;
    private int activeLineIndex = 0;

    private int index = 1;

    private void Awake()
    {
        talkerUIOther = talkerOther.GetComponent<TalkUI>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        conversation = Resources.Load<Conversation>("TalkData/Conversation/StartConversation");
    }

    private void Start()
    {
        int value = 0;
        SoundManager.Instance.SetBGM(value);
        AdvanceConversation();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AdvanceConversation();
        }
    }

    public void ChooseConversation(string conversationData)
    {
        switch (conversationData)
        {
            case "Start":
                conversation = Resources.Load<Conversation>("TalkData/Conversation/StartConversation");
                break;
            default:
                break;
        }
        AdvanceConversation();
    }

    private void AdvanceConversation()
    {
        dialogueManager.SkipCheck();
        if (dialogueManager.isTypingCheck || dialogueManager.isSkipCheck) return;
        if (activeLineIndex < conversation.lines.Length)
        {
            DisplayLine();
            activeLineIndex += 1;
        }
        else
        {
            talkerUIOther.Hide();
            activeLineIndex = 0;
            DataManager.Instance.CurrentPlayer.watchedStory = true;
            SoundManager.Instance.SetBGM(index);
            SceneManager.LoadScene(ConstantManager.MAIN_SCENE);
        }
    }

    private void DisplayLine()
    {
        Line line = conversation.lines[activeLineIndex];
        Character character = line.character;
        Sprite characterImage = line.character.characterImage;
        string characterName = line.character.name;

        SetDialog(talkerUIOther, talkerUIOther, line.text, characterImage, characterName);
    }

    private void SetDialog(TalkUI activeTalkerUI, TalkUI inactiveTalkerUI, string text, Sprite image, string name)
    {
        Text dialogueText = activeTalkerUI.dialog;
        inactiveTalkerUI.Hide();
        activeTalkerUI.nameText.text = name;
        activeTalkerUI.characterImage.sprite = image;
        if (activeTalkerUI.characterImage.sprite == null)
        {
            activeTalkerUI.characterImage.DOFade(0, 0);
            activeTalkerUI.nameWindowImage.DOFade(0, 0);
        }
        else
        {
            activeTalkerUI.characterImage.DOFade(1, 0);
            activeTalkerUI.nameWindowImage.DOFade(1, 0);
        }
        activeTalkerUI.Dialog = text;
        activeTalkerUI.Show();
        StartCoroutine(dialogueManager.Typing(text, dialogueText));
    }
}