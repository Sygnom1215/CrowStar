using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class DialogDisplay : MonoBehaviour
{
    public Conversation conversation = null;

    public GameObject talkerLeft;
    public GameObject talkerRight;

    public GameObject talkerObserver;

    public TalkUI talkerUILeft;
    public TalkUI talkerUIRight;

    public TalkUI talkerUIObserver;

    //public GameObject endSceneImage;

    private int activeLineIndex = 0;

    private void Start()
    {
        talkerUILeft = talkerLeft.GetComponent<TalkUI>();
        talkerUIRight = talkerRight.GetComponent<TalkUI>();

        talkerUIObserver = talkerObserver.GetComponent<TalkUI>();

        //talkerUILeft.Talker = conversation.talkerLeft;
        //talkerUIRight.Talker = conversation.talkerRight;

        //talkerUIObserver.Talker = conversation.talkerObserver;

        AdvanceConversation();
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            AdvanceConversation();
        }
    }
    void AdvanceConversation()
    {
        if (activeLineIndex < conversation.lines.Length)
        {
            DisplayLine();
            activeLineIndex += 1;
        }
        else
        {
            talkerUILeft.Hide();
            talkerUIRight.Hide();
            talkerUIObserver.Hide();
            activeLineIndex = 0;
            //endSceneImage.transform.DOMove(new Vector3(0, 0), 1);
        }
    }
    void DisplayLine()
    {
        Line line = conversation.lines[activeLineIndex];
        Character character = line.character;

        if (talkerUILeft.TalkerIs(character))
        {
            SetDialog(talkerUILeft, talkerUIRight, line.text);
        }
        else if(talkerUIRight.TalkerIs(character))
        {
            SetDialog(talkerUIRight, talkerUILeft, line.text);
        }
        else
        {
            SetDialog(talkerUIObserver, talkerUIRight, line.text);
        }
    }
    void SetDialog(TalkUI activeTalkerUI, TalkUI inactiveTalkerUI, string text)
    {
        inactiveTalkerUI.Hide();
        activeTalkerUI.Dialog = text;
        activeTalkerUI.Show();
    }
}