using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
   public RuntimeSettings settings;
   public string scene;
   [SerializeField] bool playerNear = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(playerNear = true && Input.GetKeyDown(KeyCode.E)) {
         settings.lastScene = SceneManager.GetActiveScene();
         settings.currentScene = SceneManager.GetSceneByName(scene);
         SceneManager.LoadScene(scene);
      }
    }
   private void OnTriggerEnter2D(Collider2D collision)
   {
      if(collision.gameObject.CompareTag("Player")){
         playerNear = true;
      }
   }
   private void OnTriggerExit2D(Collider2D collision){
      playerNear = false;
   }
}
