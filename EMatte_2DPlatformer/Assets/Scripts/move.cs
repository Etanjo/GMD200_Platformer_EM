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
    public Vector2 spawnPoint = new Vector2(0, -2.5f);
    Vector2 _input;


    // Start is called before the first frame update

    GameObject findClosestGrapplePoint()
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

    float distanceFromGameObject(GameObject go)
    {
        float dist;
        Vector2 diff;
        diff = go.transform.position - transform.position;
        dist = diff.sqrMagnitude;
        return dist;
    }

    Vector2 vectorToGameObject(GameObject go)
    {
        Vector2 diff = go.transform.position - transform.position;
        Debug.Log(diff);
        return diff;
    }
    void Start()
    {

        body = GetComponent<Rigidbody2D>();
        grapplePoints = GameObject.FindGameObjectsWithTag("grapple");
        
    }

    private void Update()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.down, 1f, settings.groundLayer);

        _onGround = (rayHit.collider != null);

        Debug.DrawLine(transform.position, transform.position + Vector3.down * 1f, _onGround ? Color.green : Color.red);


        if (_onGround)
        {
            jumps = 1;
            if (rayHit.transform.gameObject.CompareTag("mover"))
            {
                transform.SetParent(rayHit.transform.gameObject.transform, true);

            }
        }
        else
        {
            transform.SetParent(null);
            body.bodyType = RigidbodyType2D.Dynamic;
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
            }
            /*if (transform.parent != null)
            {
                transform.SetParent(null);
                body.bodyType = RigidbodyType2D.Dynamic;
            }*/
        }
       
            body.AddForce(_input * settings.walkSpeed);
        
        if (transform.position.y <= settings.deathY)
        {
            body.velocity = new Vector2(0, 0);
            transform.position = spawnPoint;
        }
        nearestGrapple = findClosestGrapplePoint();
        distanceFromGrapple = distanceFromGameObject(nearestGrapple);

        if(Input.GetKeyDown(KeyCode.F)&&distanceFromGrapple <= 135)
        {
            Vector2 grapple = vectorToGameObject(nearestGrapple);
            _onGround = false;
            body.AddForce(grapple*settings.grappleForce,ForceMode2D.Impulse);
        }

        
    }


    void FixedUpdate()
    {
       /* if (_onGround)
        {
            body.velocity= Vector2.ClampMagnitude(body.velocity, speed);
        }
       */
    }

  
}



