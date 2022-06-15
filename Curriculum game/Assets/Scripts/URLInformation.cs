using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class URLInformation : MonoBehaviour
{
   
   private void OnTriggerStay(Collider other) {
       
       if(other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.Space))
       {

        switch(gameObject.tag)
        {
            case "GitHub":
                Application.OpenURL("https://www.youtube.com/watch?v=mqlCuHST7f0");       
                break;
                
            case "LinkedIn":
                Application.OpenURL("https://www.youtube.com/watch?v=QP5P2A6DHe4");       
                break;
            
            case "Youtube":
                Application.OpenURL("https://www.youtube.com/watch?v=QP5P2A6DHe4");       
                break;
            
            case "Gmail":
                Application.OpenURL("https://www.youtube.com/watch?v=QP5P2A6DHe4");       
                break;
            }
       }
   }
}
