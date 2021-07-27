using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]private float speed;
    [SerializeField]private Animator animator;

    void Update()
    {   //movimento destra,sinistra
        float newVelocityx = 3f;
        if (Input.GetKey(KeyCode.LeftArrow))
            {
            newVelocityx = -speed;
            animator.SetInteger("DirezioneX", -1);
            }
        else if (Input.GetKey(KeyCode.RightArrow))
            {
            newVelocityx = speed;
            animator.SetInteger("DirezioneX", 1);
            }
        else
            {
            newVelocityx = 0f;
            animator.SetInteger("DirezioneX", 0);
            }

        //movimento alto,basso
        float newVelocityY = 0f;
        if (Input.GetKey(KeyCode.DownArrow))
            {
            newVelocityY = -speed;
            animator.SetInteger("DirezioneY", -1);
            }
        else if (Input.GetKey(KeyCode.UpArrow))
            {
            newVelocityY = speed;
            animator.SetInteger("DirezioneY", 1);
            }
        else
            {
            newVelocityY = 0;
            animator.SetInteger("DirezioneY", 0);
            }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(newVelocityx, newVelocityY);
    }
}
