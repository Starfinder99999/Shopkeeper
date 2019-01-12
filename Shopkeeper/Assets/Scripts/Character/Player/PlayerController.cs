using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {

        private Rigidbody2D rigidbody;

        ///[SerializeField] private AudioSource sound;
        ///[SerializeField] public Animator animator;
        [SerializeField] public float movementSpeed;
        [SerializeField] private float acceleration;
        [SerializeField] public float attackSpeed;


        // Use this for initialization
        void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateMovement();
        }

        private void UpdateMovement()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            Vector2 movementInput = acceleration * movementSpeed * (new Vector2(x, y));


            if (x != 0)
            {
                if (Mathf.Abs(rigidbody.velocity.x) >= movementSpeed)
                {
                    movementInput.x = 0;
                    if (Mathf.Abs(rigidbody.velocity.x) > 1.01 * movementSpeed)
                    {
                        movementInput.x = -rigidbody.velocity.x + movementSpeed;
                    }
                }
                else if (y != 0 && rigidbody.velocity.y != 0 && Mathf.Abs(rigidbody.velocity.x) >= (0.61f * movementSpeed))
                {
                    movementInput.x = 0;
                    if (Mathf.Abs(rigidbody.velocity.x) >= 0.62f * movementSpeed)
                    {
                        movementInput.x = -rigidbody.velocity.x + (0.61f * movementSpeed);
                    }
                }
                if (y == 0)
                {
                    if (x > 0)
                    {
                        SwitchTrigger("WalkRight");
                    }
                    else
                    {
                        SwitchTrigger("WalkLeft");
                    }
                }

            }
            else
            {
                movementInput.x = 0;
            }
            if (y != 0)
            {
                if (Mathf.Abs(rigidbody.velocity.y) >= movementSpeed)
                {
                    movementInput.y = 0;
                    if (Mathf.Abs(rigidbody.velocity.y) > 1.01 * movementSpeed)
                    {
                        movementInput.y = -rigidbody.velocity.y + movementSpeed;
                    }
                }
                else if (x != 0 && rigidbody.velocity.x != 0 && Mathf.Abs(rigidbody.velocity.y) >= (0.62f * movementSpeed))
                {
                    movementInput.y = 0;
                    if (Mathf.Abs(rigidbody.velocity.y) >= 0.62f * movementSpeed)
                    {
                        movementInput.y = -rigidbody.velocity.y + (0.61f * movementSpeed);
                    }
                }
                if (y > 0)
                {
                    SwitchTrigger("WalkUp");
                }
                else
                {
                    SwitchTrigger("WalkDown");
                }
            }
            else
            {
                movementInput.y = 0;
            }
            if (x == 0 && y == 0)

                SwitchTrigger("Idle");
            rigidbody.AddForce(movementInput);
        }

        private void SwitchTrigger(string triggerName)
        {
            ///if (!animator.GetCurrentAnimatorStateInfo(0).IsName(triggerName))
            ///    animator.SetTrigger(triggerName);
        }

    }
}