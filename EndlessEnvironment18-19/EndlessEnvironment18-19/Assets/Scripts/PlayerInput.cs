using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {

	Player player;
	Animator playAnim;
	SpriteRenderer flipPlayer;
	bool leftOrRight;

	void Start () {
		player = GetComponent<Player> ();
		playAnim = GetComponent<Animator>();
		flipPlayer = GetComponent<SpriteRenderer>();
	}

	void Update () {
		Vector2 directionalInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		player.SetDirectionalInput (directionalInput);

		if (Input.GetKeyDown (KeyCode.Space)) {
			player.OnJumpInputDown ();
            playAnim.Play("Jump");
		}
		if (Input.GetKey(KeyCode.Space)) {
			player.OnJumpInputUp ();
            playAnim.Play("Jump");
		}
	    else if(Input.GetKey(KeyCode.LeftArrow)){
			playAnim.Play("walk");
			if(leftOrRight == true){
				flipPlayer.flipX = true;
                leftOrRight = false;
			}
		}
        else if (Input.GetKey(KeyCode.RightArrow))
        {
			playAnim.Play("walk");
            if (leftOrRight == false)
            {
                flipPlayer.flipX = false;
				leftOrRight = true;
            }
        }
		else{
			playAnim.Play("idle");
		}
	}
}
