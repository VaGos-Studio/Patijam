using UnityEngine;

public class TheOneController : MonoBehaviour
{
    public static TheOneController Instance { get; private set; }

    string _floorLayerName = "floor";
    string _obstaclesLayerName = "obstacle";
    string _goalLayerName = "goal";

    bool _isGrounded = true;
    bool _isDead = false;
    bool _isGoal = false;
    public bool IsGrounded { get { return _isGrounded; } }

    Vector2 _lastPos = new Vector2(0.5f, 0.5f);

    bool _canFall = true;
    int _canHit = 0;
    int _flyTime = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MoveForward(int steps)
    {
        LeanTween.cancel(gameObject);
        Vector2 currentPos = transform.position;
        Vector2 newPos = currentPos + (Vector2.right * steps);
        float time = 0.5f * steps;
        LeanTween.value(transform.position.x, newPos.x, time).setOnUpdate(val =>
            transform.position = new Vector3(val, transform.position.y, 0));
        //PlayAnimacion
        StopFlying();
    }

    public void MoveBackward(int steps)
    {
        LeanTween.cancel(gameObject);
        Vector2 currentPos = transform.position;
        Vector2 newPos = currentPos + (Vector2.left * steps);
        float time = 0.5f * steps;
        LeanTween.value(transform.position.x, newPos.x, time).setOnUpdate(val =>
            transform.position = new Vector3(val, transform.position.y, 0));
        //PlayAnimacion
        StopFlying();
    }

    public void MoveUpward(int steps)
    {
        LeanTween.cancel(gameObject);
        Vector2 currentPos = transform.position;
        Vector2 newPos = currentPos + (Vector2.up * steps);
        float time = 0.25f * steps;
        LeanTween.value(transform.position.y, newPos.y, time).setOnUpdate(val =>
            transform.position = new Vector3(transform.position.x, val, 0));
        //PlayAnimacion
    }

    public void MoveDownward(int steps)
    {
        LeanTween.cancel(gameObject);
        Vector2 currentPos = transform.position;
        Vector2 newPos = currentPos + (Vector2.down * steps);
        float time = 0.25f * steps;
        LeanTween.value(transform.position.y, newPos.y, time).setOnUpdate(val =>
            transform.position = new Vector3(transform.position.x, val, 0));
        //PlayAnimacion
    }

    void StopFlying()
    {
        if (_flyTime > 0)
        {
            _flyTime--;
            if (_flyTime == 0)
            {
                MoveDownward(2);
            }
        }
    }

    public void RestartPos()
    {
        transform.position = _lastPos;
    }

    public void NewLastPost()
    {
        _lastPos += Vector2.one * 10;
    }

    public void Die()
    {
        _isDead = true;
        GeneralController.Instance.TheOneDied();
        //PlayAnimacion
    }

    void Goal()
    {
        _isGoal = true;
        GeneralController.Instance.Goal();
        _lastPos = transform.position;
    }

    public void NewTurn()
    {
        _isDead = false;
        _isGoal = false;
        _canFall = true;
        _canHit = 0;
        if (_flyTime > 0)
        {
            _flyTime = 0;
            if (_flyTime == 0)
            {
                MoveDownward(2);
            }
        }
    }

    public void CanFall(bool action)
    {
        _canFall = action;
    }

    public void CanHit(int time)
    {
        _canHit = time;
    }

    public void SetFlyMove(int time)
    {
        _flyTime = time;
    }

    private void Update()
    {
        if (GameStateController.Instance.CurrentState == GAMESTATE.ACTION_FASE ||
            GameStateController.Instance.CurrentState == GAMESTATE.TIME_OVER)
        {
            if (_canFall)
            {
                CheckGround();
            }
            CheckcollisionForward();
            CheckcollisionUpward();
            CheckcollisionGoal();
        }
    }

    void CheckGround()
    {
        // Asignar la LayerMask utilizando el nombre del layer
        int layerMask = 1 << LayerMask.NameToLayer(_floorLayerName);

        RaycastHit hit;

        // Lanzar el Raycast desde el objeto hacia abajo
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, 1f, layerMask);

        // Dibujar el Raycast en la Scene view
        Debug.DrawRay(transform.position, Vector3.down * (hit.distance > 0 ? hit.distance : 1), _isGrounded ? Color.red : Color.green);

        if (_isGrounded)
        {
            if (hit.collider != null && !_isDead)
            {
                Debug.Log("El objeto de abajo tiene el layer 'floor': " + hit.collider.name);
            }
        }
        else
        {
            Debug.Log("No se detectó ningún objeto con el layer 'floor' debajo.");
        }
    }

    void CheckcollisionForward()
    {
        int layerMask = 1 << LayerMask.NameToLayer(_obstaclesLayerName);

        RaycastHit hit;

        bool ishitted = Physics.Raycast(transform.position, Vector3.right, out hit, 1f, layerMask);

        Debug.DrawRay(transform.position, Vector3.right * (hit.distance > 0 ? hit.distance : 1), ishitted ? Color.red : Color.green);

        if (ishitted)
        {
            if (hit.collider != null && !_isDead)
            {
                if (_canHit == 0)
                {
                    Die();
                }
                else
                {
                    _canHit--;
                }
                Debug.Log("se detecto objeto': " + hit.collider.name);
            }
        }
        else
        {
            Debug.Log("No se detectó objeto.");
        }
    }

    void CheckcollisionUpward()
    {
        int layerMask = 1 << LayerMask.NameToLayer(_obstaclesLayerName);

        RaycastHit hit;

        bool ishitted = Physics.Raycast(transform.position, Vector3.up, out hit, 1f, layerMask);

        Debug.DrawRay(transform.position, Vector3.up * (hit.distance > 0 ? hit.distance : 1), ishitted ? Color.red : Color.green);

        if (ishitted)
        {
            if (hit.collider != null && !_isDead)
            {
                if (_canHit == 0)
                {
                    Die();
                }
                else
                {
                    _canHit--;
                }
                Debug.Log("se detecto objeto': " + hit.collider.name);
            }
        }
        else
        {
            Debug.Log("No se detectó objeto.");
        }
    }

    void CheckcollisionGoal()
    {
        int layerMask = 1 << LayerMask.NameToLayer(_goalLayerName);

        RaycastHit hit;

        bool ishitted = Physics.Raycast(transform.position, Vector3.right, out hit, 0.5f, layerMask);

        Debug.DrawRay(transform.position, Vector3.right * (hit.distance > 0 ? hit.distance : 0.5f), ishitted ? Color.red : Color.green);

        if (ishitted)
        {
            if (hit.collider != null && !_isGoal)
            {
                Goal();
                Debug.Log("se detecto Goal': " + hit.collider.name);
            }
        }
        else
        {
            Debug.Log("No se detectó Goal.");
        }
    }
}
