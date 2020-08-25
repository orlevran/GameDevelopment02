using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    private float _speed = 0.08f, _rotation;
    private Vector3 _direction;
    private CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        this._direction = Vector3.zero;
        this._characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        this._rotation = Input.GetAxis("Horizontal") * (float)Math.PI * 10f;

        if (Input.GetKey(KeyCode.UpArrow) && this._speed <= 1.5f)
        {
            this._speed += 0.1f;
            this._direction = Vector3.forward;
        }
        /*
        else if (Input.GetKey(KeyCode.DownArrow) && this._speed >= -1.5f)
        {
            this._speed -= 0.1f;
            this._direction = Vector3.back;
        }*/
        transform.Rotate(0, this._rotation * Time.deltaTime * this._speed, 0);
        this._characterController.Move(transform.TransformDirection(this._direction * Time.deltaTime * this._speed));
    }
}
