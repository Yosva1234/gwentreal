using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Yosva {
public class campo : MonoBehaviour 

{
   public TMP_Text round, LP, name1, name2;
   
   // le asigno los nombres a cada jugador 
   void nombredejugadores (){
       
   }
      

    void Start()
    {
     round.text = "ronda 1";
     Cargarescena objeto = new Cargarescena();
       name1.text = objeto.J1.text;
       name2.text = objeto.J1.text;

       Debug.Log (name1.text + name2.text);
    }

    // Update is called once per frame
   // void Update()
   // {
        
   // }
}
}
