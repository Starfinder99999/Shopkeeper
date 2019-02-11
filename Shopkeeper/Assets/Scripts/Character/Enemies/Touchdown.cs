using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Touchdown : Character
    {
        GameObject target;

        private void Update()
        {
            if (target)
            {
                Debug.Log("Update");
                Vector2 direction = Vector3.Normalize(gameObject.transform.position - this.transform.position);
                this.GetComponent<Rigidbody2D>().AddForce(direction*10);
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.GetComponent<Player.Player>())
            {
                collision.gameObject.GetComponent<Player.Player>().TakeDamage(100, "");
            }
        }

        private void Interact()
        {
            Debug.Log("Hello");
        }

        private void OnMouseOver()
        {
            GetComponent<SpriteRenderer>().color = Color.cyan;
        }

        private void OnMouseExit()
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("triggered");
            if (collision.GetComponent<Player.Player>())
            {
                Debug.Log("Player");
                target = collision.gameObject;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject == target)
            {
                target = null;
            }
        }
    }
}