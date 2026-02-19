using UnityEngine;

[CreateAssetMenu(fileName = "Cards", menuName = "Scriptable Objects/Cards")]
public class Cards : ScriptableObject
{
    public string cardname;

    public int cardNumber;

    public string description;

    public Sprite art;
    
}
