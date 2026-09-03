using Unity.AppUI.Core;
using Unity.Hierarchy.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float JumpForce;

    [Header("References")]
    public Rigidbody2D PlayerRigidBody;
    public Animator PlayernAnimator;

    private bool isGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded){
            //Method 1
            /*
            PlayerRigidBody.linearVelocityX = 10;
            PlayerRigidBody.linearVelocityY = 10;
            */
            PlayerRigidBody.AddForceY(JumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            PlayernAnimator.SetInteger("state", 1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Platform")
        {
            if (!isGrounded)
            {
                PlayernAnimator.SetInteger("state", 2);
            }
            isGrounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "enemy")
        {
            
        }
        else if(collider.gameObject.tag == "food")
        {
            
        }
        else if(collider.gameObject.tag == "golden")
        {
            
        }
    }
}
