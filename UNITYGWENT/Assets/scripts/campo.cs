using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Yosva {
public class mecancasdejuego : MonoBehaviour 

{
           
    // Start is called before the first frame update
    
   public TMP_Text round, LP, name1, name2;
   
   
   public void names (string s1, string s2){
    name1.text = s1;
    name2.text = s2;
   }
    

    void Start()
    {
     
     round.text = "ronda 1";


    }

    // Update is called once per frame
   // void Update()
   // {
        
   // }
}
}
