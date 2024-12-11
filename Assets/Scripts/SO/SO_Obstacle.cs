using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "ScriptableObjects/Obstacle")]
public class SO_Obstacle : ScriptableObject
{
    public List<Sprite> GroundSprite;
    public List<Sprite> AirSprite;
}
