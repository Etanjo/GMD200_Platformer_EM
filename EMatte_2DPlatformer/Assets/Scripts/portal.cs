using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{
   public string scene;
   [SerializeField] bool playerNear = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(playerNear == true && Input.GetKeyDown(KeyCode.E)) {
         PlayerPrefs.SetString("LastLevel", UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
         PlayerPrefs.Save();
         Debug.Log(PlayerPrefs.GetString("LastLevel"));
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
      if (collision.CompareTag("Player"))
        {
            playerNear = false;
        }
   }
}
