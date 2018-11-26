using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{

    Player player;

    bool negativeGravity = false;
    [SerializeField]
    LayerMask mask;
    [SerializeField]
    private float checkHeight;
    RaycastHit2D hit;
    Animator playAnim;
    SpriteRenderer flipPlayer;
    bool leftOrRight;

    void Start()
    {
        player = GetComponent<Player>();
        playAnim = GetComponent<Animator>();
        flipPlayer = GetComponent<SpriteRenderer>();
    }

    bool checkGrounded()
    {
        //this should make sense it checks if the player is grounded with the use of a raycast. it checks up if player gravity is negative 
        //and down if player has positive gravity
        if (negativeGravity == false)
        {
            hit = Physics2D.Raycast(transform.position, -Vector2.up, checkHeight, mask);
        }
        else if (negativeGravity == true)
        {
            hit = Physics2D.Raycast(transform.position, Vector2.up, checkHeight, mask);
        }

        return hit.collider == null ? false : true;
    }

    void Update()
    {
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.SetDirectionalInput(directionalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.OnJumpInputDown();
            playAnim.Play("Jump");
        }
        if (Input.GetKey(KeyCode.Space))
        {
            player.OnJumpInputUp();
            playAnim.Play("Jump");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (checkGrounded())
            {
                playAnim.Play("walk");
                if (leftOrRight == true)
                {
                    flipPlayer.flipX = true;
                    leftOrRight = false;
                }
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (checkGrounded())
            {
                playAnim.Play("walk");
                if (leftOrRight == false)
                {
                    flipPlayer.flipX = false;
                    leftOrRight = true;
                }
            }
        }
        else
        {
            if (checkGrounded())
                playAnim.Play("idle");
        }
    }
}
