using TMPro;
using UnityEngine;
   using UnityEngine.UI;

   public class ModificarTexto : MonoBehaviour
   {
       public TMP_Text NOMBRE, LP, TIPO ;  // Variable para guardar el componente Text
void Cambio (string nombre, string lp, string tipo){

   NOMBRE.text = nombre;
   LP.text = lp;
   TIPO.text = tipo;

}

       
   }
   
