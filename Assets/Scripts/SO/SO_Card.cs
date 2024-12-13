using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "ScriptableObjects/Card")]
public class SO_Card : ScriptableObject
{
    public CARDACTIONS CardAction;
    [TextArea]
    public string CardText;
}
