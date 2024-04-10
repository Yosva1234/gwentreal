using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

namespace Program{
   public class campo : MonoBehaviour 
{     
     public List <GameObject> mazoinspector = new List <GameObject> ();
     public List <scriptableobject> detallesinspector = new List <scriptableobject> ();

//--------------------------------------------------------------ambos mazos

      List <GameObject> mazo1 = new List <GameObject> ();
      List <scriptableobject> detalles1 = new List <scriptableobject> ();
      List <GameObject> mazo2 = new List <GameObject> ();
      List <scriptableobject> detalles2 = new List <scriptableobject> ();

      //---------------------------------------------------------------manos

      public List <scriptableobject> mano1 = new List <scriptableobject>();
      public List <scriptableobject> mano2 = new List <scriptableobject>();

//-------------------------------------------------mezclar cartas

      void mezclar (){
         while(mazo1.Count!=24){
            System.Random random = new System.Random ();
            int x = random.Next(0,mazo1.Count-1);
            mazo1.RemoveAt(x);
            detalles1.RemoveAt(x);
         }
         
          while(mazo1.Count!=24){
            System.Random random = new System.Random ();
            int x = random.Next(0,mazo2.Count-1);
            mazo2.RemoveAt(x);
            detalles2.RemoveAt(x);
         }

      }

   //---------------------------------------------------------------cuantas cartas tengo

   int cuantascartastengo(bool quejugadores){

    if(quejugadores){
      for (int x=0; x<mano1.Count; x++){
         if(mano1[x].nombre=="")  return x;
      }
      return -1;
    }
    else{
        for (int x=0; x<mano2.Count; x++){
         if(mano2[x].nombre=="")  return x;
      }
      return -1;
    }
 }

   //-----------------------------------------------------------------robar

   void robar (int n, bool robaj1 , bool robaj2 ){

      if(robaj1){
         int c=cuantascartastengo(true);
         for (int x=0; x<n; x++){
            if(c+x < detalles1.Count){
            mano1[c+x].nombre = detalles1[x].nombre;
            mano1[c+x].lp = detalles1[x].lp;
            mano1[c+x].tipo = detalles1[x].tipo;
            mano1[c+x].personaje = detalles1[x].personaje;
          }
         }
      }

       if(robaj2){
         int c=cuantascartastengo(false);
         for (int x=0; x<n; x++){
            if(c+x < detalles2.Count){
            mano2[c+x].nombre = detalles2[x].nombre;
            mano2[c+x].lp = detalles2[x].lp;
            mano2[c+x].tipo = detalles2[x].tipo;
            mano2[c+x].personaje = detalles2[x].personaje;
          }
         }
      }

   }
       
//---------------------------------------------------------------------start


  void Start() {
      
      for (int x=0 ;  x<mazoinspector.Count ; x++){
         mazo1.Add(mazoinspector[x]);
         detalles1.Add(detallesinspector[x]);
         mazo2.Add(mazoinspector[x]);
         detalles2.Add(detallesinspector[x]);
      }
      mezclar();
  
      robar(1, true , true);
  
  }

  //-----------------------------------------------------------------------update

  void Update() {
   

  }
  
}
}
