using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class move : MonoBehaviour
{
    public PlayerControllerSettings settings;
    public float speed = 13f;
    public bool facingRight = true;
    public Rigidbody2D body;
    [SerializeField] int jumps = 2;
    [SerializeField] bool _onGround = true;
    [SerializeField] GameObject[] grapplePoints;
    [SerializeField] GameObject nearestGrapple;
    [SerializeField] float distanceFromGrapple;
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer sR;
    public bool isFlipping = false;
    float currentSpeed;
    public Vector2 spawnPoint = new Vector2(0, -2.5f);
    Vector2 _input;
    [SerializeField] float previousYVelocity;
    [SerializeField] float previousXVelocity;
    [SerializeField] float previousTVelocity;
   [SerializeField] bool grapplesExist = false;
    // Start is called before the first frame update

    GameObject FindClosestGrapplePoint()
    {
        GameObject closest = null;
        float distance = Mathf.Infinity;
        foreach (GameObject point in grapplePoints)
        {
            Vector2 diff = point.transform.position - transform.position;

            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = point;
                distance = curDistance;
            }

        }
        return closest;
    }

    float DistanceFromGameObject(GameObject go)
    {
        float dist;
        Vector2 diff;
        diff = go.transform.position - transform.position;
        dist = diff.sqrMagnitude;
        return dist;
    }


    Vector2 VectorToGameObject(GameObject go)
    {
        Vector2 diff = go.transform.position - transform.position;
        Debug.Log(diff);
        return diff;
    }
    public void StopFlipping()
    {
        animator.SetBool("IsFlipping", false);
    }
    void Start()
    {

        body = GetComponent<Rigidbody2D>();
        grapplePoints = GameObject.FindGameObjectsWithTag("grapple");
         if (grapplePoints != null) {
         grapplesExist = true;
         }
        animator = GetComponent<Animator>();
        sR = GetComponent<SpriteRenderer>();

    }

    private void Update()
    {
        //animator.SetBool("IsFlipping", isFlipping);
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.down, 1f, settings.groundLayer);

        _onGround = (rayHit.collider != null);

        Debug.DrawLine(transform.position, transform.position + Vector3.down * 1f, _onGround ? Color.green : Color.red);


        if (_onGround)
        {
            jumps = 1;
            if (rayHit.transform.gameObject.CompareTag("mover"))
            {
                //transform.SetParent(rayHit.transform.gameObject.transform, true);

            }
        }
        else
        {
            transform.SetParent(null);
        }
        if (transform.parent != null)
        {
            body.velocity += (Vector2)transform.parent.GetComponent<Rigidbody2D>().velocity;
        }


        _input = new Vector2(Input.GetAxis("Horizontal"), 0);


        if (Input.GetKeyDown(KeyCode.W))
        {
            if (_onGround)
            {
                body.AddForce(transform.up * settings.jumpSpeed, ForceMode2D.Impulse);
            }
            else if (jumps > 0)
            {
                body.AddForce(transform.up * settings.jumpSpeed, ForceMode2D.Impulse);
                jumps -= 1;
                animator.SetTrigger("Flip");
                animator.SetBool("IsFlipping", true);
            }
            /*if (transform.parent != null)
            {
                transform.SetParent(null);
                body.bodyType = RigidbodyType2D.Dynamic;
            }*/
        }
        if (body.velocity.x > 0)
        {
            facingRight = true;
        }
        else if (body.velocity.x < 0)
        {
            facingRight = false;
        }

        sR.flipX = !facingRight;

        if (transform.position.y <= settings.deathY)
        {
            body.velocity = new Vector2(0, 0);
            transform.position = spawnPoint;
        }
      if (grapplesExist)
      {
         nearestGrapple = FindClosestGrapplePoint();
         distanceFromGrapple = DistanceFromGameObject(nearestGrapple);
      }

        if (Input.GetKeyDown(KeyCode.F) && distanceFromGrapple <= 135 && grapplesExist)
        {
            Vector2 grapple = VectorToGameObject(nearestGrapple);
            _onGround = false;
            body.AddForce(grapple * settings.grappleForce, ForceMode2D.Impulse);
            animator.SetTrigger("Flip");
            animator.SetBool("IsFlipping", true);
        }



        currentSpeed = Mathf.Abs(body.velocity.x);

        animator.SetFloat("Speed", currentSpeed);

        if (body.velocity.y > 0)
        {
            animator.SetBool("IsJumping", true);

        }
        else if (body.velocity.y < 0)
        {
            animator.SetBool("IsFalling", true);
            animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("IsFalling", false);
            animator.SetBool("IsJumping", false);
        }
        previousYVelocity = Mathf.Abs(body.velocity.y);
        previousXVelocity = Mathf.Abs(body.velocity.x);
        previousTVelocity = previousXVelocity + previousYVelocity;
    }


    void FixedUpdate()
    {
      body.AddForce(_input * settings.walkSpeed);
      /* if (_onGround)
       {
           body.velocity= Vector2.ClampMagnitude(body.velocity, speed);
       }
      */
   }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("obstacle"))
        {
            transform.position = spawnPoint;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool collisionBelow = collision.transform.position.y < transform.position.y;
        if (collision.gameObject.CompareTag("Ground") && previousTVelocity >= 20 && collisionBelow)
        {
            animator.SetTrigger("Flip");
            animator.SetBool("IsFlipping", true);
        }
    }

}



