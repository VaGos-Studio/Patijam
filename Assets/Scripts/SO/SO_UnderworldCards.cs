using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "ScriptableObjects/UnderworldCarts")]
public class SO_UnderworldCards : ScriptableObject
{
    public List<UnderworldCardID> Cards;
}

[Serializable]
public struct UnderworldCardID
{
    public UNDERWORLDACTION UnderworldAction;
    public string CardText;
}
