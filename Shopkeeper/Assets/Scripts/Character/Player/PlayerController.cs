using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Player
{
    public class PlayerController : MonoBehaviour
    {

        private Rigidbody2D rigidbody;
        private LayerMask mask;
        private ContactFilter2D filter;
        private RaycastHit2D[] hits;
        private bool interactcooldown = false;
        private int uiCooldown = 0;

        ///[SerializeField] private AudioSource sound;
        ///[SerializeField] public Animator animator;
        [SerializeField] public float movementSpeed;
        [SerializeField] private float acceleration;
        [SerializeField] public float attackSpeed;
        [SerializeField] public Dictionary<System.Type, string> hotkeys = new Dictionary<System.Type, string>();
        [SerializeField] public Player player;
        [SerializeField] public GameUI.InventoryUI inventory;


        // Use this for initialization
        void Awake()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            hotkeys.Add(typeof(Actions.DamageRy), "Fire1");
            hotkeys.Add(typeof(Actions.SelfHeal), "Hotbar1");
            LayerMask mask = LayerMask.GetMask("Default", "Item");
            filter = new ContactFilter2D();
            filter.useTriggers = false;
            filter.useLayerMask = true;
            filter.layerMask = mask;
            
            
        }

        // Update is called once per frame
        void Update()
        {
            UpdateMovement();
            foreach (System.Type key in hotkeys.Keys)
            {
                if (Input.GetAxis(hotkeys[key]) != 0)
                {
                    this.GetComponent<Player>().abilityManager.UseAbility(key);
                }
            }
            if (Input.GetAxis("Interact") != 0 && !interactcooldown)
            {
                hits = new RaycastHit2D[10];
                interactcooldown = true;
                RaycastHit2D nearestHit;
                Physics2D.Raycast(GetComponent<Rigidbody2D>().position,
                    Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(GetComponent<Rigidbody2D>().position.x, GetComponent<Rigidbody2D>().position.y),
                    filter, hits, 3);
                
                nearestHit = hits[0];
                foreach (RaycastHit2D hit in hits)
                {
                    if (Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Vector3(hit.point.x, hit.point.y)) 
                        < 
                        Vector3.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), new Vector3(nearestHit.point.x, nearestHit.point.y)))
                    {
                        nearestHit = hit;
                    } 
                }
                if (nearestHit.collider != null)
                {
                    Debug.DrawLine(GetComponent<Rigidbody2D>().position, nearestHit.point, new Color(200f, 0f, 0), 0.4f, false);
                    nearestHit.rigidbody.BroadcastMessage("Interact", this.gameObject.GetComponent<Player>(), SendMessageOptions.DontRequireReceiver);
                }
                else Debug.DrawRay(GetComponent<Rigidbody2D>().position, Camera.main.ScreenToWorldPoint(Input.mousePosition) - new Vector3(GetComponent<Rigidbody2D>().position.x, GetComponent<Rigidbody2D>().position.y), new Color(0f, 200f, 0f), 0.4f, false);



            }else if (Input.GetAxis("Interact") == 0 && interactcooldown)
            {
                interactcooldown = false;
            }

            if (Input.GetAxis("Inventory") != 0 && uiCooldown == 0)
            {
                uiCooldown = 20;
                inventory.ToggleInventory();
            }
            else if(uiCooldown != 0)
            {
                uiCooldown --;
                Debug.Log(uiCooldown);
            }
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