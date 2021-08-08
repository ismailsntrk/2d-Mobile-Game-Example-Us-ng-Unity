
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public CharacterController2D controller;
    float HorizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    public Animator animator;



    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(HorizontalMove));
        HorizontalMove = joystick.Horizontal * runSpeed;

        if (joystick.Vertical > 0.3)
        {
            jump = true;
            for (float i = 0; i <= 2; i++)
            {

                animator.SetFloat("jumpSpeed", 1);
                i = i + 1;
            }
        }




        }
        private void FixedUpdate()
        {
            controller.Move(HorizontalMove * Time.fixedDeltaTime, false, jump);
            jump = false;
        }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.name);
            Destroy(collision.gameObject);
        }



    } 
