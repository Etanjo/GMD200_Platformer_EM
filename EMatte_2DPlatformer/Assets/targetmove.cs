using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetmove : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] int _maxHeight = 3;
    [SerializeField] Rigidbody2D _rb;
    bool movingUp = true;

    // Update is called once per frame
    void Update()
    {
        if(_rb.position.y >= _maxHeight && movingUp == true ){

            _speed *= -1;
            movingUp = false;
        }else if(0-_rb.position.y >= _maxHeight && !movingUp){
            _speed *= -1;
            movingUp = true;
        }
        _rb.velocity = new Vector2(0,_speed);
        
    }
}
