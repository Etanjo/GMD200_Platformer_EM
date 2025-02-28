using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Platformer/Runtime Settings")] 
public class RuntimeSettings : ScriptableObject
{
   public Scene lastScene;
   public Scene currentScene;
   
}
