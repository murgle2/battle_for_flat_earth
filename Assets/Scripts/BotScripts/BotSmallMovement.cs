using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameCompany.BFE
{
    public class BotSmallMovement : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed;
        [SerializeField]
        private bool isMoving;

        [SerializeField]
        private float moveTime;
        private float moveCounter;

        [SerializeField]
        private float waitTime;
        private float waitCounter;

        private int moveDirection;

        
        public bool hasTarget = false;

        private Rigidbody2D rb;
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            waitCounter = waitTime;
            moveCounter = moveTime;

            ChooseDirection();
        }


        void Update()
        {
            if (!hasTarget)
            {

                if (isMoving)
                {
                    moveCounter -= Time.deltaTime;

                    switch (moveDirection)
                    {
                        case 0:
                            rb.velocity = new Vector2(0, moveSpeed);
                            break;
                        case 1:
                            rb.velocity = new Vector2((moveSpeed * Mathf.Sqrt(2)) / 2, (moveSpeed * Mathf.Sqrt(2)) / 2);

                            break;
                        case 2:
                            rb.velocity = new Vector2(moveSpeed, 0);
                            break;
                        case 3:
                            rb.velocity = new Vector2((moveSpeed * Mathf.Sqrt(2)) / 2, -(moveSpeed * Mathf.Sqrt(2)) / 2);
                            break;
                        case 4:
                            rb.velocity = new Vector2(0, -moveSpeed);
                            break;
                        case 5:
                            rb.velocity = new Vector2(-(moveSpeed * Mathf.Sqrt(2)) / 2, -(moveSpeed * Mathf.Sqrt(2)) / 2);
                            break;
                        case 6:
                            rb.velocity = new Vector2(-moveSpeed, 0);
                            break;
                        case 7:
                            rb.velocity = new Vector2(-(moveSpeed * Mathf.Sqrt(2)) / 2, (moveSpeed * Mathf.Sqrt(2)) / 2);
                            break;
                    }

                    if (moveCounter < 0)
                    {
                        isMoving = false;
                        moveCounter = moveTime;
                    }
                }
                else
                {
                    waitCounter -= Time.deltaTime;

                    rb.velocity = Vector2.zero;

                    if (waitCounter < 0)
                    {
                        ChooseDirection();
                    }
                }
            }

        }

        private void ChooseDirection()
        {
            moveDirection = Random.Range(0, 8);
            isMoving = true;
            moveCounter = moveTime;
        }

    }
}
