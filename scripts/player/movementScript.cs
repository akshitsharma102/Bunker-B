
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace player
{
    public class movementScript : MonoBehaviour
    {
        public CharacterController controller;
        public float speed = 12f;
        public float gravity = -9.81f;
        public Transform groundCheck;
        public float groundDisctance = 0.4f;
        Vector3 velocity;
        public LayerMask groundMask;
        bool isGrounded;
        public float jumphight = 3f;
        public Animator anim;
        void Start()
        {

        }


        void Update()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDisctance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumphight * -2f * gravity);
            }
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                anim.SetBool("IsMoveing", true);
            }
            else
            {
                anim.SetBool("IsMoveing", false);
            }
        }
    }
}
