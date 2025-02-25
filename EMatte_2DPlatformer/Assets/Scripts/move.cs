using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class move : MonoBehaviour
{
    public PlayerControllerSettings settings;
    public float speed = 13f;
    public float jumpHieght = 2.2f;
    public bool facingRight = true;
    public Rigidbody2D body;
    [SerializeField] int jumps = 2;
    [SerializeField] bool _onGround = true;
    Vector2 _input;
    
    // Start is called before the first frame update
    void Start()
    {
       
    body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.down, 1.5f, settings.groundLayer);

        _onGround = (rayHit.collider != null);

        Debug.DrawLine(transform.position, transform.position + Vector3.down * 1.5f, _onGround ? Color.green : Color.red);

        if(_onGround){
            jumps = 2;
        }
 
        _input = new Vector2(Input.GetAxis("Horizontal"),0);

    
        if(Input.GetKeyDown(KeyCode.W) && jumps >0){
            body.velocity += new Vector2(0,speed*.66f);
            jumps-=1;
        }
        body.velocity = new Vector2(_input.x*speed,body.velocity.y);

        if(transform.position.y <= settings.deathY){
            body.velocity = new Vector2(0,0);
            transform.position = settings.spawnPoint;
        }
    }
    
        
    
}
