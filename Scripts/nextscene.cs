using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class nextscene : MonoBehaviour
{
    public string scenename;

    public string test;
    
 
 void OnTriggerEnter(Collider other){
  if(other.CompareTag("Player")){
      SceneManager.LoadScene(scenename);
  }
 }
}
