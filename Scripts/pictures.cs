using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pictures : MonoBehaviour
{
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;
    public GameObject image6;
    public GameObject image7;
    public GameObject image8;
    
    
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            if (!image1.activeInHierarchy)
            {
                image1.SetActive(true);
                image2.SetActive(true);
                image3.SetActive(true);
                image4.SetActive(true);
                image5.SetActive(true);
                image6.SetActive(true);
                image7.SetActive(true);
                image8.SetActive(true);
            }else
            {
                image1.SetActive(false);
                image2.SetActive(false);
                image3.SetActive(false);
                image4.SetActive(false);
                image5.SetActive(false);
                image6.SetActive(false);
                image7.SetActive(false);
                image8.SetActive(false);
                
            }
        }
    }
}
