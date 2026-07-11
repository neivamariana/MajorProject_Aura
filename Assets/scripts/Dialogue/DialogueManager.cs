using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    [Header("UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueTxt;
    [SerializeField] private TextMeshProUGUI npcNameTxt;

    [SerializeField] private Transform buttonParent;
    [SerializeField] private GameObject choiceButtonPrefab;

    private DialogueData currentDialogue;

    private NPCDialogue currentNpc;

    private int currentConversation;
    private int currentPage;
    private bool isDialogueActive;

    public bool IsDialogueActive => isDialogueActive;

    private void Awake()
    {
        instance = this;
    }

    public void StartDialogue(DialogueData dialogue, int conversationIndex = 0, NPCDialogue npc = null)
    {
        if (dialogue == null)
        {
            Debug.Log("no dialogue found :((((((");
            return;
        }

        if (dialogue.conversations.Length == 0)
        {
            Debug.Log("this dialogue npc has nothing to yap about lol");
            return;
        }

        if (conversationIndex >= dialogue.conversations.Length)
        {
            Debug.Log("convo doesnt exist");
            return;
        }

        Debug.Log("dialogue has started yippeeeee!!!");

        currentDialogue = dialogue;
        currentNpc = npc;
        currentConversation = conversationIndex;
        currentPage = 0;
        isDialogueActive = true;

        dialoguePanel.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        ShowPage();
    }

    private void ShowPage()
    {
        DialogueConversation conversation = currentDialogue.conversations[currentConversation];
        DialoguePage page = conversation.pages[currentPage];

        Debug.Log("Showing page " + currentPage);
        Debug.Log("Conversation: " + conversation.conversationType);
        Debug.Log("NPC: " + currentDialogue.npcName);
        Debug.Log("Dialogue: " + page.dialogueText);

        npcNameTxt.text = currentDialogue.npcName;
        dialogueTxt.text = page.dialogueText;

        if(page.action != DialogueAction.None)
        {
            PerformAction(page.action);

        }

        ClearButtons();

        if (page.choices != null && page.choices.Length > 0)
        {
            ShowChoices(page.choices);
        }
    }


    public void ProgressDialogue()
    {
        if (!isDialogueActive)
            return;

        DialogueConversation conversation = currentDialogue.conversations[currentConversation];
        DialoguePage page = conversation.pages[currentPage];

        Debug.Log("Progressing dialogue...");
        Debug.Log("Current page: " + currentPage);
        Debug.Log("Next page: " + page.nextPage);

        if (page.choices != null && page.choices.Length > 0)
            return;


        if (page.endConversation)
        {
            EndDialogue();
            return;
        }


        if (page.nextPage == -1)
        {
            EndDialogue();
            return;
        }


        currentPage = page.nextPage;

        ShowPage();
    }


    public void ChooseOption(int nextPage)
    {
        Debug.Log("next up: " + nextPage);

        if (nextPage == -1)
        {
            EndDialogue();
            return;
        }

        currentPage = nextPage;

        ShowPage();
    }


    private void ShowChoices(DialogueChoice[] choices)
    {
        foreach (DialogueChoice choice in choices)
        {
            GameObject button = Instantiate(choiceButtonPrefab, buttonParent);

            DialogueChoiceButton buttonScript = button.GetComponent<DialogueChoiceButton>();

            buttonScript.Setup(choice);
        }

        Debug.Log("Button has entered the chat :)");
    }


    public void PerformAction(DialogueAction action)
    {
        switch (action)
        {
            case DialogueAction.None:
                break;


            case DialogueAction.StartQuest:
                //QuestManager.instance.StartQuest(currentNpc.questData);
                Debug.Log("start quest works!!");
                break;


            case DialogueAction.OpenTarotBook:
                Debug.Log("book opens yayyy");
                break;


            case DialogueAction.CompleteQuest:
                Debug.Log("quest completed hurrayyy!!! :DD");
                break;


            case DialogueAction.EndConversation:
                Debug.Log("ending convo works adios");
                EndDialogue();
                break;
        }
    }


    private void ClearButtons()
    {
        foreach (Transform child in buttonParent)
        {
            Destroy(child.gameObject);
        }
    }


    private void EndDialogue()
    {
        Debug.Log("Dialogue is done :D");

        isDialogueActive = false;

        dialoguePanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        ClearButtons();
    }
}