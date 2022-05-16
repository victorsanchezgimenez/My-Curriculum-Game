using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate : MonoBehaviour
{
    // Start is called before the first frame update
   void Awake() {
       QualitySettings.vSyncCount = 0;
       Application.targetFrameRate = 60;
       
   }
}
