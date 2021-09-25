using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBooleans
    {
    public static bool left = false;
    public static bool right = false;
    public static bool up = false;
    public static bool down = false;
    }

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]private float speed;
    [SerializeField]private Animator animator;
    private Rigidbody2D rb;


    private void Awake()
        {
        rb = gameObject.GetComponent<Rigidbody2D>();
        }
    void Update()
        {
        float newVelocityY = 0f;
        float newVelocityx = 3f;


        //movimento destra,sinistra
#if UNITY_EDITOR || UNITY_STANDALONE

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
#endif
#if UNITY_IOS || UNITY_ANDROID 


        if (ArrowBooleans.left)
            {
            newVelocityx = -speed;
            animator.SetInteger("DirezioneX", -1);
            }
        else if (ArrowBooleans.right)
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

        if (ArrowBooleans.down)
            {
            newVelocityY = -speed;
            animator.SetInteger("DirezioneY", -1);
            }
        else if (ArrowBooleans.up)
            {
            newVelocityY = speed;
            animator.SetInteger("DirezioneY", 1);
            }
        else
            {
            newVelocityY = 0;
            animator.SetInteger("DirezioneY", 0);
            }
#endif

        rb.velocity = new Vector2(newVelocityx, newVelocityY);
    }



}
