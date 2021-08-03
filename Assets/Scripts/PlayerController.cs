using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Berry

public class PlayerController : MonoBehaviour
{
    private float vertical;
    private float horizontal;
    public float speed;
    public GameController gameController;
    private Rigidbody rb;
    private bool canMove;
    public int score;
    public int orbValue;
    private AudioSource orbcollect;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canMove = true;
        orbcollect = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        //checks to make sure the player has not reached the capsule yet, then
        //   allows player to move
        if (canMove)
        {
            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
            rb.AddForce(movement * speed);
        }
        else
        {
            //makes sure the player immediately stops once the capsule is reached
            rb.Sleep();
        }

    }

    void Update()
    {
        if (score != 0 && canMove)
        {
            score -= 1;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //enables player to pick up the capsule
        if (other.CompareTag("Macguffin"))
        {
            other.gameObject.SetActive(false);
            //ends the game
            gameController.GameWin();
        }
        if (other.CompareTag("Orb"))
        {
            orbcollect.Play();
            other.gameObject.SetActive(false);
            score += orbValue;
        }
    }

    //lets the Game Controller stop the player from moving
    public void CanMove(bool b)
    {
        canMove = b;
    }

}
