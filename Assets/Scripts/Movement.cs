using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //public Joystick joystick;
   // public GameObject handleReference;
   // public GameObject joystickReference;
    public float rotateSpeed = 3.0f;
    public float force = 1.0f;
    private Rigidbody2D player;
    private AnimationScript anim;
    public GameObject direction;
    private bool facingRight = true;
    public Vector2 startPos;
    public Vector2 direct;
    bool onPlayer = false;
    CircleCollider2D ccollider2D;
    BoxCollider2D bcollider2D;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        ccollider2D =  GetComponent<CircleCollider2D>();
        bcollider2D = GetComponent<BoxCollider2D>();
        anim = GetComponentInChildren<AnimationScript>();
    }

    // Update is called once per frame
    private void Update()
    {

        anim.SetMovement(System.Math.Abs(player.velocity.x));

        Transform transform = GetComponent<Transform>();
        if (Input.touchCount == 1)
        {
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            if (ccollider2D.OverlapPoint(wp))
            {
                onPlayer = true;
            }
            
        }
        
        Touch touch = Input.GetTouch(0);

        switch (touch.phase)
        {
            case TouchPhase.Began:
                startPos = touch.position;           

                break;

            case TouchPhase.Moved:
                direct = touch.position - startPos;
                
                    direction.SetActive(true);
                
                
                break;

            case TouchPhase.Ended:
                if (player.velocity.x == 0)
                {
                    player.AddForce(direction.transform.right * force, ForceMode2D.Impulse);
                }
                if (transform.localScale.x == 0.8f)
                {
                    transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
                }
                else if (transform.localScale.x == -0.8f)
                {
                    transform.localScale = new Vector3(-0.7f, 0.7f, 0.7f);
                }
                direction.SetActive(false);
                onPlayer = false;
                break;
        }

        if (onPlayer)
        {
            if (transform.localScale.x == 0.7f)
            {
                transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            }
            else if (transform.localScale.x == -0.7f)
            {
                transform.localScale = new Vector3(-0.8f, 0.8f, 0.8f);
            }
        }

        if (direction)
        {
            var angle = Mathf.Atan2(direct.y, direct.x) * Mathf.Rad2Deg;
            direction.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        /*if (Input.touchCount == 1)
        {
            direction.SetActive(true);
        }
        else
        {
            direction.SetActive(false);
        }
        */
    }

   /* void FixedUpdate()
    {         

        if (direction){
            var dir = direct;
            //var dir = handleReference.transform.position - joystickReference.transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            direction.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        if (player.velocity.x == 0 && Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                player.AddForce(direction.transform.right * force, ForceMode2D.Impulse);
            }              
        }
        
    }
    */
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            player.velocity = new Vector2(0f, 0f);
        }
        if (collision.gameObject.name == "LeftWall" && !facingRight || collision.gameObject.name == "RightWall" && facingRight)
        {
            Flip();
        }
    }
}
