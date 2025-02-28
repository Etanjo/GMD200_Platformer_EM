using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
   public RuntimeSettings settings;
   [SerializeField] bool needPortal = false;
   [SerializeField] GameObject portal;
   [SerializeField] string scene;

    // Start is called before the first frame update
    void Start()
    {
      if(needPortal){
         portal = GameObject.FindGameObjectWithTag("Portal");
      }
      if(scene ==""){
         scene = settings.lastScene.name;
      }
        
    }


    public void LoadScene(){
     if(needPortal){
         portal.GetComponent<portal>().scene = scene;
      }else{
         settings.lastScene = SceneManager.GetActiveScene();
         settings.currentScene = SceneManager.GetSceneByName(scene);
         SceneManager.LoadScene(scene);
      }

   }
   
}
