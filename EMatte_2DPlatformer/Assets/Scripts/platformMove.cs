using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class platformMove : MonoBehaviour
{

   [SerializeField] bool isVertical = false;
   public Animator animator;

   private void Start(){
      animator = gameObject.GetComponent<Animator>();
   }

   private void OnCollisionEnter2D(Collision2D collision)
   {
      if(collision.gameObject.CompareTag("Player")){
         animator.SetBool("IsMoving", true);
      }
   }
   private void OnCollisionExit2D(Collision2D collision){
      if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("IsMoving", false);
        }
   }
}
