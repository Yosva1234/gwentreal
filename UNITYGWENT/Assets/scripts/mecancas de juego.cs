using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

namespace Program{
public class campo : MonoBehaviour 
{

public TMP_Text puntaje1, puntaje2, partidasj1, partidasj2;
public Image taparcarta1, taparcarta2;
public List <GameObject> mazo = new List<GameObject>();
 List <GameObject> mazo1 = new List<GameObject>();
 List <GameObject> mazo2 = new List<GameObject>();
public List <GameObject> manodeljugador1 = new List<GameObject>();
public List <GameObject> manodeljugador2 = new List<GameObject>();
 List <GameObject> actualizacionmano1 = new List<GameObject>();
 List <GameObject> actualizacionmano2 = new List<GameObject>();
public List <GameObject> distancia1 = new List<GameObject>();
public List <GameObject> distancia2 = new List<GameObject>();
List <GameObject> actualizaciondistancia1 = new List<GameObject>();
 List <GameObject> actualizaciondistancia2 = new List<GameObject>();
public List <GameObject> cuerpoacuerpo1 = new List<GameObject>();
public List <GameObject> cuerpoacuerpo2 = new List<GameObject>();
List <GameObject> actualizacioncuarpoacuerpo1 = new List<GameObject>();
List <GameObject> actualizacioncuerpoacuerpo2 = new List<GameObject>();
public List <GameObject> intermedia1 = new List<GameObject>();
public List <GameObject> intermedia2 = new List<GameObject>();
List <GameObject> actualizacionintermedia1 = new List<GameObject>();
 List <GameObject> actualizacionintermedia2 = new List<GameObject>();

// ====================================================== mezclar ambos mazos hasta que tengan 24 cartas.
void mezclar(int cantidad) {
for (int x=0; x<mazo.Count; x++){
  mazo1.Add(mazo[x]);
  mazo2.Add(mazo[x]);
}

while (mazo1.Count!=cantidad){
   System.Random random = new System.Random();
 int n = random.Next(0,mazo1.Count-1);
 mazo1.RemoveAt(n);
}

while (mazo2.Count!=cantidad){
   System.Random random = new System.Random();
 int n = random.Next(0,mazo2.Count-1);
 mazo2.RemoveAt(n);
}

}


//================================================================== cuantas cartas debe robar cada jugador

void robar(int n, bool j1, bool j2) {

 if (j1) {

   int caux = actualizacionmano1.Count;
   int c = caux;
   if (c == manodeljugador1.Count) return ;
   c = Math.Min(n,Math.Abs(manodeljugador1.Count - c));

   for (int x=0 ;  x<c; x++){

       actualizacionmano1.Add(mazo1[0]);
       Button aux  = actualizacionmano1[actualizacionmano1.Count-1].GetComponentInChildren<Button>();
       Button aux2 = mazo1[0].GetComponentInChildren<Button>();
       aux.image.sprite = aux2.image.sprite;
      
      mazo1.RemoveAt(0);
   }
  
 }

 if (j2) {

   int caux = actualizacionmano2.Count;
   int c = caux;
   if (c == manodeljugador2.Count) return ;
   c = Math.Min(n,Math.Abs(manodeljugador2.Count - c));

   for (int x=0 ;  x<c; x++){

     actualizacionmano2.Add(mazo2[0]);
       Button aux  = actualizacionmano2[actualizacionmano2.Count-1].GetComponentInChildren<Button>();
        Button aux2 = mazo2[0].GetComponentInChildren<Button>();
       aux.image.sprite = aux2.image.sprite;

       mazo2.RemoveAt(0);
 }

}
}
 //============================================================= jugarcarta bool jugador es true si juega el jugador 1, sino es false.

bool turno = true ; // cualdo turno tiene valor true le toca jugarb al jugador 1 si es false le toca jugar al jugador 2.

 int n;
 int cdepass = 0;

 public void jugarcarta(int aux){
   
   n=aux;
  
 }

 public void jugarcarta2(){
  
  cdepass = 0;

  if (turno){
 detall script = actualizacionmano1[n-1].GetComponent<detall>();
  if(script.tipo == 'c' ) actualizacioncuarpoacuerpo1.Add(actualizacionmano1[n-1]);
  if(script.tipo == 'd' ) actualizaciondistancia1.Add(actualizacionmano1[n-1]);
  if(script.tipo == 'i' ) actualizacionintermedia1.Add(actualizacionmano1[n-1]);
  actualizacionmano1.RemoveAt(n-1);
  turno = false;
  return ;
  }

  if(!turno){
  detall script = actualizacionmano2[n-1].GetComponent<detall>();
  if(script.tipo == 'c' ) actualizacioncuerpoacuerpo2.Add(actualizacionmano2[n-1]);
  if(script.tipo == 'd' ) actualizaciondistancia2.Add(actualizacionmano2[n-1]);
  if(script.tipo == 'i' ) actualizacionintermedia2.Add(actualizacionmano2[n-1]);
  actualizacionmano2.RemoveAt(n-1);
  turno = true;
  }
  
 }

// si n=1 entonces se activa el mk si es=2 se activa la pekka

 public void jugarjefe(int n){

  cdepass = 0;
  
  if(n==1){
    if (turno == false) return ;

    System.Random random = new System.Random();
    bool b = true; 

   
    System.Random random2 = new System.Random();
    int aux = random2.Next(1,3);
    if(aux==1){
      if(actualizacioncuerpoacuerpo2.Count == 0 ) goto azul;
      int eliminar = random.Next(0,actualizacioncuerpoacuerpo2.Count-1);
      actualizacioncuerpoacuerpo2.RemoveAt(eliminar);
      
    }
    if(aux==2){
      if(actualizaciondistancia2.Count == 0 ) goto azul;
      int eliminar = random.Next(0,actualizaciondistancia2.Count-1);
      actualizaciondistancia2.RemoveAt(eliminar);
     
    }
     if(aux==3){
      if(actualizacionintermedia2.Count == 0 ) goto azul;
      int eliminar = random.Next(0,actualizacionintermedia2.Count-1);
      actualizacionintermedia2.RemoveAt(eliminar);
     
    }
    azul :
    turno = false;
    return ;
  }

  if (n==2){
    if(turno == true) return ; 

    robar(1,false, true);
    turno = true;
    return ;
  }

 }


 public void pasarturno(){

 cdepass++;
 if(!turno) turno = true;
 else turno = false;

 }


//=============================================================== START

 private void Start() {
 puntaje1.text = "0";
 puntaje2.text = "0";
 partidasj1.text = "0";
 partidasj2.text = "0";
 mezclar(24);
 robar (10 , true , true);
   
 }

 //====================================================== actualizacion en cada frame de las cartas


void actualizacion(){

  // actualizar la imagen que tapan las cartas en cada turno.

  if(turno){
    taparcarta1.enabled = false;
    taparcarta2.enabled = true;
  }
  else {
    taparcarta1.enabled = true;
    taparcarta2.enabled = false;
  }


  // actualicemos los puntajes en cada frame; 
  // puntage del j1.
  int c=0;

  for (int x=0; x< actualizacioncuarpoacuerpo1.Count; x++){
    detall script = actualizacioncuarpoacuerpo1[x].GetComponent<detall>();
    c+=script.LP;
  }
  for (int x=0; x< actualizaciondistancia1.Count; x++){
    detall script = actualizaciondistancia1[x].GetComponent<detall>();
    c+=script.LP;
  }
  for (int x=0; x< actualizacionintermedia1.Count; x++){
    detall script = actualizacionintermedia1[x].GetComponent<detall>();
    c+=script.LP;
  }
  
  puntaje1.text = c.ToString();

   // puntage del j1.
  c=0;
 
 for (int x=0; x< actualizacioncuerpoacuerpo2.Count; x++){
    detall script = actualizacioncuerpoacuerpo2[x].GetComponent<detall>();
    c+=script.LP;
  }
  for (int x=0; x< actualizaciondistancia2.Count; x++){
    detall script = actualizaciondistancia2[x].GetComponent<detall>();
    c+=script.LP;
  }
  for (int x=0; x< actualizacionintermedia2.Count; x++){
    detall script = actualizacionintermedia2[x].GetComponent<detall>();
    c+=script.LP;
  }
  
  puntaje2.text = c.ToString();

  // actualizamos la mano del jugador 1 en cada frame.

  for(int x=0 ; x<actualizacionmano1.Count ; x++){
      Button aux = manodeljugador1[x].GetComponentInChildren<Button>();
      if(!aux.GetComponent<Image>().enabled) aux.GetComponent<Image>().enabled = true;
      Button aux2 = actualizacionmano1[x].GetComponentInChildren<Button>();
      aux.image.sprite = aux2.image.sprite;
  }
  for(int x = actualizacionmano1.Count; x < manodeljugador1.Count; x++){
    Button aux = manodeljugador1[x].GetComponentInChildren<Button>();
    aux.GetComponent<Image>().enabled = false;
  }

  // actualizamos la mano del jugador 2 en cada frame.

  for(int x=0 ; x<actualizacionmano2.Count ; x++){
      Button aux = manodeljugador2[x].GetComponentInChildren<Button>();
      if(!aux.GetComponent<Image>().enabled) aux.GetComponent<Image>().enabled = true;
      Button aux2 = actualizacionmano2[x].GetComponentInChildren<Button>();
      aux.image.sprite = aux2.image.sprite;
  }
    for(int x = actualizacionmano2.Count; x < manodeljugador2.Count; x++){
    Button aux = manodeljugador2[x].GetComponentInChildren<Button>();
    aux.GetComponent<Image>().enabled = false;
  }

 // actualizemos la fila de ataque cuerpo a cuerpo del jugador 1.

  for(int x=0 ; x<actualizacioncuarpoacuerpo1.Count ; x++){
      Button aux = cuerpoacuerpo1[x].GetComponentInChildren<Button>();
      if(!aux.GetComponent<Image>().enabled) aux.GetComponent<Image>().enabled = true;
      Button aux2 = actualizacioncuarpoacuerpo1[x].GetComponentInChildren<Button>();
      aux.image.sprite = aux2.image.sprite;
  }
  for(int x = actualizacioncuarpoacuerpo1.Count; x < cuerpoacuerpo1.Count; x++){
    Button aux = cuerpoacuerpo1[x].GetComponentInChildren<Button>();
    aux.GetComponent<Image>().enabled = false;
  }

   // actualizemos la fila de ataque cuerpo a cuerpo del jugador 2.

  for(int x=0 ; x<actualizacioncuerpoacuerpo2.Count ; x++){
      Button aux = cuerpoacuerpo2[x].GetComponentInChildren<Button>();
      if(!aux.GetComponent<Image>().enabled) aux.GetComponent<Image>().enabled = true;
      Button aux2 = actualizacioncuerpoacuerpo2[x].GetComponentInChildren<Button>();
      aux.image.sprite = aux2.image.sprite;
  }
  for(int x = actualizacioncuerpoacuerpo2.Count; x < cuerpoacuerpo2.Count; x++){
    Button aux = cuerpoacuerpo2[x].GetComponentInChildren<Button>();
    aux.GetComponent<Image>().enabled = false;
  }

 // actualizemos la fila de ataque a distancia del jugador 1.

  for(int x=0 ; x<actualizaciondistancia1.Count ; x++){
      Button aux = distancia1[x].GetComponentInChildren<Button>();
      if(!aux.GetComponent<Image>().enabled) aux.GetComponent<Image>().enabled = true;
      Button aux2 = actualizaciondistancia1[x].GetComponentInChildren<Button>();
      aux.image.sprite = aux2.image.sprite;
  }
  for(int x = actualizaciondistancia1.Count; x < distancia1.Count; x++){
    Button aux = distancia1[x].GetComponentInChildren<Button>();
    aux.GetComponent<Image>().enabled = false;
  }
  
  // actualizemos la fila de ataque a distancia del jugador 2.

  for(int x=0 ; x<actualizaciondistancia2.Count ; x++){
      Button aux = distancia2[x].GetComponentInChildren<Button>();
      if(!aux.GetComponent<Image>().enabled) aux.GetComponent<Image>().enabled = true;
      Button aux2 =  actualizaciondistancia2[x].GetComponentInChildren<Button>();
      aux.image.sprite = aux2.image.sprite;
  }
  for(int x = actualizaciondistancia2.Count; x < distancia2.Count; x++){
    Button aux = distancia2[x].GetComponentInChildren<Button>();
    aux.GetComponent<Image>().enabled = false;
  }

   // actualizemos la fila de ataque intermedio del jugador 1.

  for(int x=0 ; x<actualizacionintermedia1.Count ; x++){
      Button aux = intermedia1[x].GetComponentInChildren<Button>();
      if(!aux.GetComponent<Image>().enabled) aux.GetComponent<Image>().enabled = true;
      Button aux2 = actualizacionintermedia1[x].GetComponentInChildren<Button>();
      aux.image.sprite = aux2.image.sprite;
  }
  for(int x = actualizacionintermedia1.Count; x < intermedia1.Count; x++){
    Button aux = intermedia1[x].GetComponentInChildren<Button>();
    aux.GetComponent<Image>().enabled = false;
  }

  // actualizemos la fila de ataque intermedio del jugador 1.

  for(int x=0 ; x<actualizacionintermedia1.Count ; x++){
      Button aux = intermedia1[x].GetComponentInChildren<Button>();
      if(!aux.GetComponent<Image>().enabled) aux.GetComponent<Image>().enabled = true;
      Button aux2 = actualizacionintermedia1[x].GetComponentInChildren<Button>();
      aux.image.sprite = aux2.image.sprite;
  }
  for(int x = actualizacionintermedia1.Count; x < intermedia1.Count; x++){
    Button aux = intermedia1[x].GetComponentInChildren<Button>();
    aux.GetComponent<Image>().enabled = false;
  }

    // actualizemos la fila de ataque intermedio del jugador 2.

  for(int x=0 ; x<actualizacionintermedia2.Count ; x++){
      Button aux = intermedia2[x].GetComponentInChildren<Button>();
      if(!aux.GetComponent<Image>().enabled) aux.GetComponent<Image>().enabled = true;
      Button aux2 = actualizacionintermedia2[x].GetComponentInChildren<Button>();
      aux.image.sprite = aux2.image.sprite;
  }
  for(int x = actualizacionintermedia2.Count; x < intermedia2.Count; x++){
    Button aux = intermedia2[x].GetComponentInChildren<Button>();
    aux.GetComponent<Image>().enabled = false;
  }


}
   // ============================================== limpiar todo el campo de ambos jugadores;
   void limpiarcampo(){
    actualizacioncuarpoacuerpo1.Clear();
    actualizacioncuerpoacuerpo2.Clear();
    actualizaciondistancia1.Clear();
    actualizaciondistancia2.Clear();
    actualizacionintermedia1.Clear();
    actualizacionintermedia2.Clear();
   }
  
  //===============================================verificar quien gana en una partida.
  void ganar (){
    if(cdepass==2){

      if(int.Parse(puntaje1.text)>int.Parse(puntaje2.text)){
        int c = int.Parse(partidasj1.text);
        c++;
        partidasj1.text = c.ToString();
      }
      if(int.Parse(puntaje1.text)<int.Parse(puntaje2.text)){
        int c = int.Parse(partidasj2.text);
        c++;
        partidasj2.text = c.ToString();
      }
      if(puntaje1.text==puntaje2.text){
        int c = int.Parse(partidasj1.text);
        c++;
        partidasj1.text = c.ToString();
        int c1 = int.Parse(partidasj2.text);
        c1++;
        partidasj2.text = c1.ToString();
      }
     
     limpiarcampo();
     robar(2, true, true);
     cdepass=0;
    }
  }

 private void Update() {
    actualizacion();
    ganar();    
  }

  




}

}