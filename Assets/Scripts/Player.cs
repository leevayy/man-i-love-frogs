using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Animator animator;
    [SerializeField] private Car car;
    [SerializeField] private CheckPoint checkPoint;
    [SerializeField] private Background background;

    private bool jumpPressed = false;
    private bool goBackPressed = false;

    public int counter = 0;
    public int negCounter = 0;

    private void Update() 
    {
        for(int i = 0; i < Input.touchCount; i++)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            if (touchPosition.x >= 0 && Input.touches[i].phase == TouchPhase.Began)
            {
                jumpPressed = true;
                animator.SetBool("isJumping", jumpPressed);
            }
            else if (touchPosition.x < 0 && Input.touches[i].phase == TouchPhase.Began)
            {
                goBackPressed = true;
                animator.SetBool("isGoingBack", goBackPressed);
            }
        }
    }
    private void FixedUpdate()
    {
        if (jumpPressed)
        {
            jumpPressed = false;
            animator.SetBool("isJumping", jumpPressed);
            background.Move(-1);
            car.Move(-1);
            checkPoint.Move(-1);

            if (negCounter >= 0)
            {
                counter++;
            }
            else
            {
                negCounter++;
            }
        }
        if (goBackPressed)
        {
            goBackPressed = false;
            animator.SetBool("isGoingBack", goBackPressed);
            negCounter -= 1;
            background.Move(1);
            car.Move(1);
            checkPoint.Move(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Car" )
        {
            gameManager.EndGame();
            animator.SetBool("isDead", true);
            collision.collider.gameObject.GetComponent<Rigidbody2D>().Sleep();
        }
    }
}
