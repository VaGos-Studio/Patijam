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

    Vector3 _lastPos = new Vector3(0.5f, 0.5f, 0);

    bool _canFall = true;
    int _canHit = 0;
    int _flyTime = 0;
    bool _isMortal = false;
    bool _isFalling = false;

    Animator _animator;
    SpriteRenderer _spriteRenderer;

    [SerializeField] float _dieFallTime = 1;
    [SerializeField] float _dieObstacleTime = 1;

    [SerializeField] AudioClip[] _clips;
    [SerializeField] AudioSource _source;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MoveForward(int steps)
    {
        if (!_isDead)
        {
            LeanTween.cancel(gameObject);
            Vector2 currentPos = transform.position;
            Vector2 newPos = currentPos + (Vector2.right * steps);
            float time = 0.5f * steps;
            LeanTween.value(transform.position.x, newPos.x, time).setOnUpdate(val =>
                transform.position = new Vector3(val, transform.position.y, 0));

            _spriteRenderer.flipX = false;
            if (gameObject.transform.position.y == 0.5f)
            {
                _animator.Play("Walk");
            }
            else
            {
                _animator.Play("Fly");
            }
            StopFlying();
        }
    }

    public void MoveBackward(int steps)
    {
        if (!_isDead)
        {
            LeanTween.cancel(gameObject);
            Vector2 currentPos = transform.position;
            Vector2 newPos = currentPos + (Vector2.left * steps);
            float time = 0.5f * steps;
            LeanTween.value(transform.position.x, newPos.x, time).setOnUpdate(val =>
                transform.position = new Vector3(val, transform.position.y, 0));

            _spriteRenderer.flipX = true;
            if (gameObject.transform.position.y == 0.5f)
            {
                _animator.Play("Walk");
            }
            else
            {
                _animator.Play("Fly");
            }
            StopFlying();
        }
    }

    public void MoveUpward(int steps)
    {
        if (!_isDead)
        {
            LeanTween.cancel(gameObject);
            Vector2 currentPos = transform.position;
            Vector2 newPos = currentPos + (Vector2.up * steps);
            float time = 0.25f * steps;
            LeanTween.value(transform.position.y, newPos.y, time).setOnUpdate(val =>
                transform.position = new Vector3(transform.position.x, val, 0));
            _animator.Play("Rise");
        }
    }

    public void MoveDownward(int steps)
    {
        if (!_isDead)
        {
            LeanTween.cancel(gameObject);
            Vector2 currentPos = transform.position;
            Vector2 newPos = currentPos + (Vector2.down * steps);
            float time = 0.25f * steps;
            LeanTween.value(transform.position.y, newPos.y, time).setOnUpdate(val =>
                transform.position = new Vector3(transform.position.x, val, 0));
            _animator.Play("Fall");
            _isFalling = true;
        }
    }

    void SetAudio(int clip)
    {
        _source.Stop();
        _source.PlayOneShot(_clips[clip]);
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

    public void SetIdel()
    {
        _animator.Play("Idle");
    }

    void RestartPos()
    {
        SetIdel();
        LeanTween.cancelAll();
        transform.position = _lastPos;
    }

    public float Die(string type)
    {
        LeanTween.cancel(gameObject);
        _isDead = true;
        if (type == "Fall")
        {
            _animator.Play("Die by Fall");
            Invoke("RestartPos", _dieFallTime);
            return _dieFallTime;
        }
        else
        {
            _animator.Play("Die by Obstacle");
            Invoke("RestartPos", _dieObstacleTime);
            return _dieObstacleTime;
        }
    }

    void Goal()
    {
        SetIdel();
        LeanTween.cancelAll();
        GeneralController.Instance.Goal();
        _lastPos = new Vector3(_lastPos.x + 10, _lastPos.y, _lastPos.z);
    }

    public void NewTurn()
    {
        _isDead = false;
        _isGoal = false;
        _canFall = true;
        _isMortal = false;
        _canHit = 0;
        if (_flyTime > 0)
        {
            _flyTime = 0;
            if (_flyTime == 0)
            {
                MoveDownward(2);
            }
        }
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 0.5f, 0);
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

    public void Mortal()
    {
        _isMortal = true;
    }

    private void Update()
    {
        if (GameStateController.Instance.CurrentState == GAMESTATE.ACTION_FASE ||
            GameStateController.Instance.CurrentState == GAMESTATE.TIME_OVER)
        {
            if ((_canFall || _isMortal) && _flyTime == 0 && !_isDead)
            {
                CheckGround();
            }
        }
    }

    void CheckGround()
    {
        // Asignar la LayerMask utilizando el nombre del layer
        int layerMask = 1 << LayerMask.NameToLayer(_floorLayerName);

        // Lanzar el Raycast desde el objeto hacia abajo
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, layerMask);
        _isGrounded = hit.collider != null;

        // Dibujar el Raycast en la Scene view
        Debug.DrawRay(transform.position, Vector2.down * (hit.distance > 0 ? hit.distance : 1f), _isGrounded ? Color.red : Color.green);

        if (_isGrounded)
        {
            if (hit.collider != null)
            {
                Debug.Log("El objeto de abajo tiene el layer 'floor': " + hit.collider.name);
            }
        }
        else
        {
            Debug.Log("No se detectó ningún objeto con el layer 'floor' debajo.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("obstacle"))
        {
            if (!_isDead)
            {
                if (_canHit == 0 || _isMortal)
                {
                    GeneralController.Instance.ActionFaseInterrupted();
                }
                else
                {
                    GeneralController.Instance.TurnObstacleOff(collision.collider.transform.parent.name);
                    _canHit--;
                }
            }
        }

        if (collision.collider.CompareTag("goal"))
        {
            Goal();
        }

        if (collision.collider.CompareTag("floor"))
        {
            if (_isFalling && !_isDead)
            {
                _animator.Play("Land");
                _isFalling = false;
            }
        }
    }
}
