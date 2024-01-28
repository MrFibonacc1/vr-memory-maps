using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class introButton : MonoBehaviour
{
    public string scenename;


public void NewGameButton(){
    print("yes");
    SceneManager.LoadScene(scenename);
}
}