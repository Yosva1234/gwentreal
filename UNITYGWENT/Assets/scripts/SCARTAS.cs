using TMPro;
using UnityEngine;
using UnityEngine.UI;

   public class ModificarTexto : MonoBehaviour
   {
public scriptableobject PLANTILLA;

public TMP_Text nombre , lp , tipo;
public Image foto;

void Start(){

   nombre.text =PLANTILLA.nombre;
   lp.text = PLANTILLA.lp.ToString();
   tipo.text = PLANTILLA.tipo;
   foto.sprite=PLANTILLA.personaje;
}

       
   }
   
