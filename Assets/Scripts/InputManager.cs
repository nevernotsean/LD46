using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityAtoms.BaseAtoms;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Vector3Variable MouseWorldPosition;
    [SerializeField] private Vector3Variable MoveDirection;
    public LayerMask hitLayer;

    [SerializeField] private VoidEvent Fire1Event;

    Ray ray;
    Vector2 mouseViewportPoint = Vector2.zero;
    Camera cam;
    Vector3 forward;
    Vector3 right;

    Vector3 _moveInput = Vector3.zero;

    private void Start ()
    {
        cam = Camera.main;
    }

    void Update ()
    {
        tickMouseCursor ();

        tickMoveDirection ();

        if (Input.GetMouseButtonDown (0))
            Fire1Event.Raise ();
    }

    void tickMouseCursor ()
    {
        mouseViewportPoint = cam.ScreenToViewportPoint (Input.mousePosition);

        ray = cam.ViewportPointToRay (mouseViewportPoint);

        if (Physics.Raycast (ray, out RaycastHit hit, cam.farClipPlane, hitLayer, QueryTriggerInteraction.Ignore))
        {
            MouseWorldPosition.Value = hit.point;
        }
    }

    void tickMoveDirection ()
    {
        // get camera directions
        forward = cam.transform.forward.normalized;
        forward.y = 0;
        right = Quaternion.Euler (0, 90, 0) * forward;

        // input
        _moveInput.x = Input.GetAxis ("Horizontal");
        _moveInput.z = Input.GetAxis ("Vertical");

        _moveInput = Vector3.ClampMagnitude (_moveInput, 1f);

        if (forward != Vector3.zero && right != Vector3.zero)
            _moveInput = (right * _moveInput.x + forward * _moveInput.z).normalized;

        MoveDirection.Value = _moveInput;
    }
}