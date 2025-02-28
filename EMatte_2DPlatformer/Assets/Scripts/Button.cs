using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
   [SerializeField] bool needPortal = false;
   [SerializeField] GameObject portal;
   [SerializeField] string scene;

    // Start is called before the first frame update
    void Start()
    {
      if(needPortal){
         portal = GameObject.FindGameObjectWithTag("Portal");
      }

        
    }


    void LoadScene(){
     if(needPortal){

      }else{

      }

   }
   
}
