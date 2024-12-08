using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TheOneController : MonoBehaviour
{
    public static TheOneController Instance { get; private set; }

    string layerName = "floor";

    bool _isGrounded = true;
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
        GeneralController.Instance.TheOneDied();
        //PlayAnimacion
    }

    private void Update()
    {
        CheckGround();
        CheckcollisionForward();
        CheckcollisionUpward();
    }

    void CheckGround()
    {
        // Asignar la LayerMask utilizando el nombre del layer
        int layerMask = 1 << LayerMask.NameToLayer(layerName);

        RaycastHit hit;

        // Lanzar el Raycast desde el objeto hacia abajo
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, 1f, layerMask);

        // Dibujar el Raycast en la Scene view
        Debug.DrawRay(transform.position, Vector3.down * (hit.distance > 0 ? hit.distance : 1), _isGrounded ? Color.red : Color.green);

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

    void CheckcollisionForward()
    {
        RaycastHit hit;

        // Lanzar el Raycast desde el objeto hacia abajo
        bool ishitted = Physics.Raycast(transform.position, Vector3.right, out hit, 1f);

        // Dibujar el Raycast en la Scene view
        Debug.DrawRay(transform.position, Vector3.right * (hit.distance > 0 ? hit.distance : 1), ishitted ? Color.red : Color.green);

        if (ishitted)
        {
            if (hit.collider != null)
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
        RaycastHit hit;

        // Lanzar el Raycast desde el objeto hacia abajo
        bool ishitted = Physics.Raycast(transform.position, Vector3.up, out hit, 1f);

        // Dibujar el Raycast en la Scene view
        Debug.DrawRay(transform.position, Vector3.up * (hit.distance > 0 ? hit.distance : 1), ishitted ? Color.red : Color.green);

        if (ishitted)
        {
            if (hit.collider != null)
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
}
