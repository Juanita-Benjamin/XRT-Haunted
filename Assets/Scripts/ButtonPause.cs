using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonPause : MonoBehaviour
{
   public Button pause;

   public Button unpause;
   
   public void Pause()
   {
      Time.timeScale = 0;
   }

   public void Unpause()
   {
      Time.timeScale = 1;
   }
}
