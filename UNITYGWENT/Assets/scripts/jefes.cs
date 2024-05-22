
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

 namespace Gwent{
public class jefes : MonoBehaviour
{


    public void mk (List <int>cc, List <int>inter , List<int> dist )
    {
      eliminarelemento(cc);
      eliminarelemento(inter);
      eliminarelemento(dist);

    }

   public void eliminarelemento(List <int> aux)
    {
        if(aux.Count == 0 ) return;

        System.Random random = new System.Random();

        int n = random.Next(0,aux.Count-1);

        aux[n]=-1;
    }

    public void pekka(List <int>cc)
    {
            for(int x = 0; x < cc.Count; x++) cc[x]=-1;
    }

}
 }