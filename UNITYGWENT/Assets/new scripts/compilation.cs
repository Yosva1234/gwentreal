
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Gwent;


namespace gwentII{
public class NewBehaviourScript : MonoBehaviour
{
public TMP_Text codigo;

List <string> lines = new List<string>();

// funcion adjunta al boton de run del compilador
public void run ()
{
        string line = "";
        for (int x = 0; x < codigo.text.Length; x++)
        {
              if(codigo.text[x] == '\n')
              {
                lines.Add(line);
                line = "";
              }
              else line+=codigo.text[x];
        }       
        lines.Add(line); 
}


     

}
}
