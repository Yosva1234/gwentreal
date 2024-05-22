using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

 namespace Gwent{
public class botones : MonoBehaviour
{
      
   public void jugarcarta(GameObject mano,List<GameObject> visual , List<GameObject> campo, List<int> val) 
    {
      campo.Add(mano);
      val.Add(mano.GetComponent<detall>().LP);
    
      visual[campo.Count-1].GetComponentInChildren<Button>().GetComponent<Image>().enabled = true;
    }


   public void jugarasedio(int n, List <int> val, Button boton, List <GameObject> mano)
   {
   boton.image.sprite = mano[n-1].GetComponentInChildren<Button>().image.sprite;

   for(int x = 0; x < val.Count; x++) val[x]+=mano[n-1].GetComponent<detall>().LP;

   mano.RemoveAt(n-1);
   }

}
}