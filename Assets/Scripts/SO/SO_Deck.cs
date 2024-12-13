using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "ScriptableObjects/Deck")]
public class SO_Deck : ScriptableObject
{
    public List<SO_Card> Cards;
}
