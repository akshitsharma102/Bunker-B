using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace player
{
    public class mouselook : MonoBehaviour
    {
        public float mouseSencitiviy = 100f;
        public Transform playerbody;
        float xrotation = 0f;
        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }


        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSencitiviy * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSencitiviy * Time.deltaTime;


            xrotation -= mouseY;
            xrotation = Mathf.Clamp(xrotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
            playerbody.Rotate(Vector3.up * mouseX);
        }
    }
}
