using UnityEngine;

[CreateAssetMenu(fileName = "SO", menuName = "ScriptableObjects/Enviroment")]
public class SO_Enviroment : ScriptableObject
{
    [SerializeField] int _level;
    [SerializeField] Sprite _enviromentBackground;
    [SerializeField] Sprite[] _enviromentFloor;
    [SerializeField] int _blocksNum;
    [SerializeField] int[] _floorConfig;

    public int Level { get { return _level; } }
    public Sprite EnviromentBackground { get { return _enviromentBackground; } }
    public Sprite[] EnviromentFloor { get { return _enviromentFloor; } }
    public int BlocksNum { get { return _blocksNum; } }
    public int[] FloorConfig { get { return _floorConfig; } }
}
