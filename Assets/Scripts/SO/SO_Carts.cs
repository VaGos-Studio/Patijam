using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "ScriptableObjects/Carts")]
public class SO_Carts : ScriptableObject
{
    public List<CartID> Carts;
}

[Serializable]
public struct CartID
{
    public SPECIALACTION SpecialAction;
    public string CartText;
}
