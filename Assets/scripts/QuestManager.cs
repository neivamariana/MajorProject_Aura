using UnityEngine;

public class QuestManager : MonoBehaviour
{
 public static QuestManager instance;

 private QuestData currentQuestData;
 private Quest currentQuest;

 public Quest CurrentQuest => currentQuest;

private void Awake()
    {
        instance = this;

    }

    public void StartQuest(QuestData questData, int questIndex = 0)
    {
        if(questData == null)
        {
            Debug.Log("No quest data found :((((((");
            return;
        }

        if(questIndex >= questData.quests.Length)
        {
            Debug.Log("Quest doesn't exist o.O");
            return;

        }

        currentQuestData = questData;

        currentQuest = questData.quests[questIndex];

        Debug.Log("Quest started YIPEEEEEE");
        Debug.Log("Quest:" + currentQuest.questName);
    }

    public void CompleteQuest()
    {
        if(currentQuest == null)
        {
            Debug.Log("No quest complete :((");
            return;
        }

        Debug.Log("Quest Completed HURRAY!! :DDD");
        Debug.Log(currentQuest.questName);

        currentQuest = null;
    }



}
