using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject target;

    public float smoothSpeed;
    public Vector3 offset;
    Vector3 velocity = Vector3.zero;
    PlayerControlls controls;

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void Awake()
    {
        controls = new PlayerControlls();
        controls.Gameplay.ZoomIn.started += ctx => ZoomIn();
        controls.Gameplay.ZoomOut.started += ctx => ZoomOut();

    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.GetComponentInChildren<Rigidbody>().position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition,ref velocity, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target.GetComponentInChildren<Rigidbody>().position);

    }
    void ZoomIn()
    {
        if (offset.magnitude >= 4)
            offset *= 0.5f;

    }
    void ZoomOut()
    {
        if (offset.magnitude <= 16)
            offset *= 1.5f;

    }
}
