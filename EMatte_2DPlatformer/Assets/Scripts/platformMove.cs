using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class platformMove : MonoBehaviour
{

   [SerializeField] Rigidbody2D _rb;
   [SerializeField] int speed = 5, maxMove = 10;
   [SerializeField] bool isVertical = false;
   Vector2 startPoint;
   // Start is called before the first frame update
   void Start()
   {
      _rb = GetComponent<Rigidbody2D>();
      startPoint = transform.position;
      if (isVertical)
      {
         _rb.velocity = new Vector2(0, speed);
         

      }
      else
      {
         _rb.velocity = new Vector2(speed, 0);
      }
   }

   // Update is called once per frame
   void Update()
   {
      float xChange = transform.position.x - startPoint.x;
      float yChange = transform.position.y - startPoint.y;
      if (Mathf.Abs(xChange) >= maxMove || Mathf.Abs(yChange) >= maxMove)
      {
         _rb.velocity *= -1;
      }
   }
}
