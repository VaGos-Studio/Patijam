using System.Collections.Generic;
using UnityEngine;

public class EnviromentController : MonoBehaviour
{
    public static EnviromentController Instance { get; private set; }

    [SerializeField] List<SO_Enviroment> _SO_Enviroments;
    [SerializeField] GameObject _blockPref;
    [SerializeField] List<SpriteRenderer> _startingFloors = new();
    [SerializeField] List<SpriteRenderer> _background = new();
    [SerializeField] GameObject _Penombra;


    int _currentLevel = 0;
    List<Block> _blocks = new();
    List<int> _config1 = new();
    List<int> _config2 = new();
    List<int> _config3 = new();
    List<int> _config4 = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _currentLevel = GameStateController.Instance.CurrentLevel;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        int totalBlocks = _SO_Enviroments[_currentLevel].BlocksNum;
        for (int i = 0; i < totalBlocks; i++)
        {
            Vector3 pos = new Vector3((10 * i), 0, 0);
            GameObject newBlock = Instantiate(_blockPref, pos, Quaternion.identity, transform);
            _blocks.Add(newBlock.GetComponent<Block>());
        }

        for (int i = 0; i < _blocks.Count; i++)
        {
            List<int> config = new();
            int starting = i * 10;
            int ending = starting + 10;
            for (int j = starting; j < ending; j++)
            {
                config.Add(_SO_Enviroments[_currentLevel].FloorConfig[j]);
            }
            switch (i)
            {
                case 0:
                    _config1 = config;
                    break;
                case 1:
                    _config2 = config;
                    break;
                case 2:
                    _config3 = config;
                    break;
                case 3:
                    _config4 = config;
                    break;
            }
            _blocks[i].SetSprites(_SO_Enviroments[_currentLevel].EnviromentFloor);
            _blocks[i].SetFloor(config);
        }

        foreach (SpriteRenderer item in _startingFloors)
        {
            int selected = Random.Range(0, _SO_Enviroments[_currentLevel].EnviromentFloor.Length);
            item.sprite = _SO_Enviroments[_currentLevel].EnviromentFloor[selected];
        }

        for (int i = 0; i < _background.Count; i++)
        {
            _background[i].sprite = _SO_Enviroments[_currentLevel].EnviromentBackground[i];
        }
    }

    public void SetBlockConfig(List<int> config)
    {
        int block = GeneralController.Instance.CurrentBlock();
        _blocks[block].SetFloor(config);
    }

    public void Flip()
    {
        int block = GeneralController.Instance.CurrentBlock();
        _blocks[block].Flip();
    }

    public void Penombra(bool action)
    {
        _Penombra.SetActive(action);
        int block = GeneralController.Instance.CurrentBlock() + 1;
        _Penombra.transform.position = new Vector3(block * 10, 0, -1);
    }

    public void NewTurn()
    {
        switch (GeneralController.Instance.CurrentBlock())
        {
            case 0:
                SetBlockConfig(_config1);
                break;
            case 1:
                SetBlockConfig(_config2);
                break;
            case 2:
                SetBlockConfig(_config3);
                break;
            case 3:
                SetBlockConfig(_config4);
                break;
        }
    }
}
