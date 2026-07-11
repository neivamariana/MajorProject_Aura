using UnityEngine;

[System.Serializable]
public class Quest
{
    [Header("Quest Info")]
    public string questName;

    [TextArea(3,5)]
    public string description;


    [Header("Tarot Card")]
    public Cards correctCard;
}