using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "Scriptable Objects/DialogueData")]
public class DialogueData : ScriptableObject
{
    public string npcName;

    public DialogueConversation[] conversations;
}


[System.Serializable]
public class DialogueConversation
{
    public ConversationType conversationType;

    public DialoguePage[] pages;
}


[System.Serializable]
public class DialoguePage
{
    [TextArea(3,5)]
    public string dialogueText;

    public DialogueChoice[] choices = new DialogueChoice[0];

    public int nextPage = -1;

    public bool endConversation;
}


[System.Serializable]
public class DialogueChoice
{
    public string choiceText;

    public int nextPage;

    public DialogueAction action;
}