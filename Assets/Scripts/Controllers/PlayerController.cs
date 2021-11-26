using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject cameraHolder;
    [SerializeField] PhotonView PV;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] private float mouseSensitivity;
    Vector2 moveAmount;
    Vector2 smoothSpeed;

    [SerializeField] float sprintSpeed;
    [SerializeField] float walkSpeed;
    [SerializeField] float smoothTime;

    private void Start()
    {
        if (!PV.IsMine)
        {
            Destroy(cameraHolder.gameObject);
            Destroy(rb);
        }
    }

    private void Update()
    {
        if (!PV.IsMine)
            return;
        Look();
        Move();
    }

    void Look()
    {
        transform.Rotate(Vector3.forward * Input.GetAxisRaw("Mouse X") * mouseSensitivity);
    }

    void Move()
    {
        Vector2 moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        moveAmount = Vector2.SmoothDamp(moveAmount, moveDir * (Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed), ref smoothSpeed, smoothTime);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (Vector2)transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }
}
