using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCompany.BFE
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed;
        [SerializeField]
        private Rigidbody2D rb;

      
        private Joystick joystick;
        private Vector2 movement;

        private void Start()
        {
            joystick = FindObjectOfType<Joystick>();
        }

        private void Update()
        {
            //movement.x = Input.GetAxisRaw("Horizontal");
            //movement.y = Input.GetAxisRaw("Vertical");


            movement.x = joystick.Horizontal;
            movement.y = joystick.Vertical;
        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}