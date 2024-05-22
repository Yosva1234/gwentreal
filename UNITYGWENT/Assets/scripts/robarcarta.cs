
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

 namespace Gwent{
public class robarcarta : MonoBehaviour
{

   public void robar (int n ,List <GameObject> mazo, List<GameObject> manoaux, List<GameObject> manovisual){
     int caux = manoaux.Count;
   int c = caux;

   if (c==manovisual.Count)  return ;

   c = Math.Min( n, Math.Abs(manovisual.Count - c));

   for (int x=0;  x<c; x++)
   { 
     Button aux3 = manovisual[manoaux.Count].GetComponentInChildren<Button>();
     aux3.GetComponent<Image>().enabled = true;
     manoaux.Add(mazo[0]);
     Button aux  = manoaux[manoaux.Count-1].GetComponentInChildren<Button>();
     Button aux2 = mazo[0].GetComponentInChildren<Button>();
     aux.image.sprite = aux2.image.sprite; 
     mazo.RemoveAt(0);
   } 
    }

}
 }
