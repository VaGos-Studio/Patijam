using UnityEngine;

public class TheOneController : MonoBehaviour
{
    public static TheOneController Instance { get; private set; }

    string _floorLayerName = "floor";
    string _obstaclesLayerName = "obstacle";
    string _goalLayerName = "goal";

    bool _isGrounded = true;
    bool _isDead = false;
    public bool IsGrounded { get { return _isGrounded; } }

    Vector2 _lastPos = new Vector2(0.5f, 0.5f);

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
        LeanTween.value(transform.position.x, newPos.x, 1).setOnUpdate(val =>
            transform.position = new Vector3(val, transform.position.y, 0));
        //PlayAnimacion
    }

    public void MoveBackward(int steps)
    {
        LeanTween.cancel(gameObject);
        Vector2 currentPos = transform.position;
        Vector2 newPos = currentPos + (Vector2.left * steps);
        LeanTween.value(transform.position.x, newPos.x, 1).setOnUpdate(val =>
            transform.position = new Vector3(val, transform.position.y, 0));
        //PlayAnimacion
    }

    public void MoveUpward(int steps)
    {
        LeanTween.cancel(gameObject);
        Vector2 currentPos = transform.position;
        Vector2 newPos = currentPos + (Vector2.up * steps);
        LeanTween.value(transform.position.y, newPos.y, 0.5f).setOnUpdate(val =>
            transform.position = new Vector3(transform.position.x, val, 0));
        //PlayAnimacion
    }

    public void MoveDownward(int steps)
    {
        LeanTween.cancel(gameObject);
        Vector2 currentPos = transform.position;
        Vector2 newPos = currentPos + (Vector2.down * steps);
        LeanTween.value(transform.position.y, newPos.y, 0.5f).setOnUpdate(val =>
            transform.position = new Vector3(transform.position.x, val, 0));
        //PlayAnimacion
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
        GeneralController.Instance.Goal();
        _lastPos = transform.position;
    }

    private void Update()
    {
        if (GameStateController.Instance.CurrentState == GAMESTATE.ACTION_FASE)
        {
            CheckGround();
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
                Die();
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
                Die();
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
            if (hit.collider != null)
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
