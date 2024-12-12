using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "ScriptableObjects/Carts")]
public class SO_Cards : ScriptableObject
{
    public List<CardID> Cards;
}

[Serializable]
public struct CardID
{
    public SPECIALACTION SpecialAction;
    [TextArea]
    public string CardText;
}
