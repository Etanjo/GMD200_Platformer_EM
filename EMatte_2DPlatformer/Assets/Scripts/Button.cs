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
      if(scene == ""){
         scene = PlayerPrefs.GetString("LastLevel");
         Debug.Log(scene);
      }
        
    }


    public void LoadScene(){
     if(needPortal){
         portal.GetComponent<portal>().scene = scene;
      }else{
         PlayerPrefs.SetString("LastLevel", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
         PlayerPrefs.Save();
         Debug.Log("Loading " + scene);
         SceneManager.LoadScene(scene);
      }

   }
   
}
