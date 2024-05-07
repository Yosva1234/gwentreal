using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;



public class campo : MonoBehaviour
{

public TMP_Text puntaje1, puntaje2, partidasj1, partidasj2, tipodecarta;
public Image taparcarta1, taparcarta2, cartagrande;
public Button jefe1, jefe2;
public List <GameObject> mazo = new List<GameObject>();
List <GameObject> mazo1 = new List<GameObject>();
List <GameObject> mazo2 = new List<GameObject>();
public List <GameObject> manodeljugador1 = new List<GameObject>();
public List <GameObject> manodeljugador2 = new List<GameObject>();
List <GameObject> actualizacionmano1 = new List<GameObject>();
List <GameObject> actualizacionmano2 = new List<GameObject>();
List <int> valordistancia1 = new List<int>();
List <int> valordistancia2 = new List<int>();
public List <GameObject> distancia1 = new List<GameObject>();
public List <GameObject> distancia2 = new List<GameObject>();
List <GameObject> actualizaciondistancia1 = new List<GameObject>();
List <GameObject> actualizaciondistancia2 = new List<GameObject>();
List <int> valorcuerpoacuerpo1 = new List<int>();
List <int> valorcuerpoacuerpo2 = new List<int>();
public List <GameObject> cuerpoacuerpo1 = new List<GameObject>();
public List <GameObject> cuerpoacuerpo2 = new List<GameObject>();
List <GameObject> actualizacioncuarpoacuerpo1 = new List<GameObject>();
List <GameObject> actualizacioncuerpoacuerpo2 = new List<GameObject>();
List <int> valorintermedio1 = new List<int>();
List <int> valorintermedio2 = new List<int>();
public List <GameObject> intermedia1 = new List<GameObject>();
public List <GameObject> intermedia2 = new List<GameObject>();
List <GameObject> actualizacionintermedia1 = new List<GameObject>();
List <GameObject> actualizacionintermedia2 = new List<GameObject>();

/*

 vamos a mezclar el mazo de cada jugador con 24 cartas la cual llamaremos desde el Start() y va a meter 
 en las listas de Game Object mazo1 y mazo2 (que son los mazos del jugador1 y el jugador2 respectivamente)
 los prefabs de las cartas correspondientes.

*/
void mezclar (int cantidad) 
{
 for (int x=0; x<mazo.Count; x++)
 {
   mazo1.Add( mazo[x] );
   mazo2.Add( mazo[x] );
 }
 
 while (mazo1.Count!=cantidad)
 {
   System.Random random = new System.Random();
   int n = random.Next(0,mazo1.Count-1);
   mazo1.RemoveAt(n);
 }

 while (mazo2.Count!=cantidad)
 {
   System.Random random = new System.Random();
   int n = random.Next(0,mazo2.Count-1);
   mazo2.RemoveAt(n);
 }

 for (int x = 0; x< 40; x++)
 {
   System.Random random1 = new System.Random();
   int n1 = random1.Next(0,mazo1.Count-1);
   System.Random random2 = new System.Random();
   int n2 = random2.Next(0,mazo1.Count-1);
   
   GameObject aux = mazo1[n1];
   mazo1[n1] = mazo1[n2];
   mazo1[n2] = aux;
 }

  for (int x = 0; x< 40; x++)
 {
   System.Random random1 = new System.Random();
   int n1 = random1.Next(0,mazo2.Count-1);
   System.Random random2 = new System.Random();
   int n2 = random2.Next(0,mazo2.Count-1);
   
   GameObject aux = mazo2[n1];
   mazo2[n1] = mazo2[n2];
   mazo2[n2] = aux;
 }

}


/*

la funcion robar es una funcion que como su nombre lo dice roba n cartas al jugador1 si bool j1
le mandamos el valor true de lo contrario no robara el j1 y lo mismo para el jugador 2. si ambos son true 
pues robaran ambos.

*/

void robar(int n, bool j1, bool j2) {

 if (j1)
  {
   int caux = actualizacionmano1.Count;
   int c = caux;

   if (c==manodeljugador1.Count)  return ;

   c = Math.Min( n, Math.Abs(manodeljugador1.Count - c));

   for (int x=0;  x<c; x++)
   {
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

   if (c == manodeljugador2.Count)  return ;

   c = Math.Min( n, Math.Abs(manodeljugador2.Count - c));

   for (int x=0;  x<c; x++)
   {
     actualizacionmano2.Add(mazo2[0]);
     Button aux  = actualizacionmano2[actualizacionmano2.Count-1].GetComponentInChildren<Button>();
     Button aux2 = mazo2[0].GetComponentInChildren<Button>();
     aux.image.sprite = aux2.image.sprite;
     mazo2.RemoveAt(0);
   }
 }
}
// si bool turno es true pues le toca jugar al jugador 1 y si es false pues le toca al jugador 2
bool turno = true; 

// int cdpass en esta variable vamos a llevar la cuenta de cuantas veces el jugador le dio al poton de pass 
// oooo jugo el efecto de su lider para una ves que llegue a dos veces consecutivas pues termina una ronda
// y cada ves que juegues una carta que que no sea el lider pues esta variable se reiniciara.
int cdepass = 0;

// como su nombre lo dices esta variable vamos a usar para ver en que fila vamos a poner la carta de asedio 
// que ha sido jugada 
int ponerasedio=0;

// en esta variable n vamos a guardar la posicion en la mano de la carta que ha sido jugada para posteriormente 
// pasarla al campo y eliminarla de la mano
int n;

// funcion adjunta a los botones que estan en el borde de cada fila del campo de batalla para saber donde colocar 
// la carta de asedio.
public void dponerasedio(int x)
{
  ponerasedio = x;
}


// funcion para el efecto de las cartas de asedio de suma o resta de la fila que ha sido seleccionada
void asedio()
{
 detall script;

 if(turno)
 script = actualizacionmano1[n-1].GetComponent<detall>();
  
  else 
  script = actualizacionmano2[n-1].GetComponent<detall>();

  if (ponerasedio == 6)
   for (int x=0; x<valorintermedio1.Count; x++)
     valorintermedio1[x]+=script.LP;
  
  if (ponerasedio == 5)
   for (int x=0; x<valordistancia1.Count; x++)
      valordistancia1[x]+=script.LP;
      
  if(ponerasedio == 4)
    for (int x=0; x<valorcuerpoacuerpo1.Count; x++)
      valorcuerpoacuerpo1[x]+=script.LP;
      
  if(ponerasedio == 3)
    for(int x=0; x<valorcuerpoacuerpo2.Count; x++)
     valorcuerpoacuerpo2[x]+=script.LP;
        
  if(ponerasedio == 2)
    for (int x=0; x<valordistancia2.Count; x++)
      valordistancia2[x]+=script.LP;
      
  if(ponerasedio == 1)
    for(int x=0; x<valorintermedio2.Count; x++)
     valorintermedio2[x]+=script.LP;
         
  ponerasedio = 0;
}

// funciones adjuntas a los botones de las cartas en cada mano para poder invocarlas al campo.
public void jugarcarta (int x)
{
  n=x;
}

public void jugarcarta2( )
{ 
 cdepass = 0;

 if (turno)
 {
   detall script = actualizacionmano1[n-1].GetComponent<detall>();

   if(script.tipo == 'c' ) 
   {
     actualizacioncuarpoacuerpo1.Add(actualizacionmano1[n-1]);
     valorcuerpoacuerpo1.Add(script.LP);
   }

   if(script.tipo == 'd' ) 
   {
     actualizaciondistancia1.Add(actualizacionmano1[n-1]);
     valordistancia1.Add(script.LP);
   }

   if(script.tipo == 'i' )
   {
     actualizacionintermedia1.Add(actualizacionmano1[n-1]);
     valorintermedio1.Add(script.LP);
   }

   if(script.tipo == 'a' ) 
   {
     if (ponerasedio == 0 ) 
     return ;
     asedio();
   }
   
   ponerasedio = 0;
   actualizacionmano1.RemoveAt(n-1);
   turno = false;

   return ;
  }

  if(!turno)
  {
   detall script = actualizacionmano2[n-1].GetComponent<detall>();

   if(script.tipo == 'c' ) 
   {
     actualizacioncuerpoacuerpo2.Add(actualizacionmano2[n-1]);
     valorcuerpoacuerpo2.Add(script.LP);
   }

   if(script.tipo == 'd' )
   {
     actualizaciondistancia2.Add(actualizacionmano2[n-1]);
     valordistancia2.Add(script.LP);
   }

   if(script.tipo == 'i' ) 
   {
     actualizacionintermedia2.Add(actualizacionmano2[n-1]);
     valorintermedio2.Add(script.LP);
   }

   if(script.tipo == 'a' )
   {

     if (ponerasedio == 0 ) 
     return;

     asedio();
    }
   ponerasedio = 0;
   actualizacionmano2.RemoveAt(n-1);
   turno = true;
   

  }



}


// funcion adjunta a los botones de las cartas jefe y el parametro m si es == a 1 pues la carta jefe que ha sido 
// seleccionada es el mk y se activara su efecto el cual es elegir un numero de fila aleatorio del campo del contrario
// y si esa fila tiene monstruos pues elegira uno de ellos al azar y los elimina del campo de batalla y sino 
// tiene monstruos pues perdiste el turno. y si m == 2 pues se activa el efecto del pekka y roba una carta.

public void jugarjefe( int m )
{

 cdepass ++;
  
  if(m==1)
  {

    if (turno == false)  return ;

    System.Random random = new System.Random();

    System.Random random2 = new System.Random();
    int aux = random2.Next(1,3);

    if(aux==1)
    {

      if(actualizacioncuerpoacuerpo2.Count == 0 )
      goto azul;

      int eliminar = random.Next(0,actualizacioncuerpoacuerpo2.Count-1);
      actualizacioncuerpoacuerpo2.RemoveAt(eliminar);
      valorcuerpoacuerpo2.RemoveAt(eliminar);
      
    }

    if(aux==2)
    {

      if(actualizaciondistancia2.Count == 0 )
      goto azul;

      int eliminar = random.Next(0,actualizaciondistancia2.Count-1);
      actualizaciondistancia2.RemoveAt(eliminar);
      valordistancia2.RemoveAt(eliminar);
     
    }

    if(aux==3)
    {

     if(actualizacionintermedia2.Count == 0 )
     goto azul;

      int eliminar = random.Next(0,actualizacionintermedia2.Count-1);
      actualizacionintermedia2.RemoveAt(eliminar);
      valorintermedio2.RemoveAt(eliminar);

    }

    azul :
    turno = false;
    return ;

  }

  if (m==2)
  {

   if(turno == true) return ; 

    robar(1,false, true);
    turno = true;
    return ;
  }

}

// funcion adjunta al boton de paso de turno 
public void pasarturno()
{
 cdepass++;

 if(!turno)
  turno = true;

 else 
 turno = false;

}

//funcion start de unity

private void Start() 
{

  turno = true;

 puntaje1.text = "0";
 puntaje2.text = "0";
 partidasj1.text = "0";
 partidasj2.text = "0";

 mezclar(24);

 robar (10 , true , true);
   
}



void funcionatualizar(List <GameObject> listvisual , List <GameObject> listaaux){


  for(int x=0 ; x<listaaux.Count ; x++)
  {
   Button aux = listvisual[x].GetComponentInChildren<Button>();

   if(!aux.GetComponent<Image>().enabled) 
   aux.GetComponent<Image>().enabled = true;

   Button aux2 = listaaux[x].GetComponentInChildren<Button>();
   aux.image.sprite = aux2.image.sprite;
  }

  for(int x = listaaux.Count; x < listvisual.Count; x++)
  {
    Button aux = listvisual[x].GetComponentInChildren<Button>();
    aux.GetComponent<Image>().enabled = false;
  }


}


int actualizarpuntos( List <int> listaval, List <GameObject> listavisual)
{

  int c =0;

  for(int x=0; x< listaval.Count; x++)
  {
    salto:

    if(listaval.Count == x)
    break;

    if(listaval[x]<=0)
    {
      listavisual.RemoveAt(x);
      listaval.RemoveAt(x);

      goto salto;
    }
    c+=listaval[x];
  }

  return c;

}

void actualizacion()
{
 
  if(turno)
  {
    taparcarta1.enabled = false;
    taparcarta2.enabled = true;
    jefe1.GetComponent<Image>().enabled = true;
    jefe2.GetComponent<Image>().enabled = false;
  }

  else
  {
    taparcarta1.enabled = true;
    taparcarta2.enabled = false;
    jefe1.GetComponent<Image>().enabled = false;
    jefe2.GetComponent<Image>().enabled = true;
  }

  int c=0;

 c+= actualizarpuntos(valorcuerpoacuerpo1,actualizacioncuarpoacuerpo1);

 c+= actualizarpuntos(valordistancia1, actualizaciondistancia1);

 c+= actualizarpuntos(valorintermedio1, actualizacionintermedia1);

  puntaje1.text = c.ToString();

  c=0;

 c+= actualizarpuntos(valorcuerpoacuerpo2,actualizacioncuerpoacuerpo2);

 c+= actualizarpuntos(valordistancia2, actualizaciondistancia2);

 c+= actualizarpuntos(valorintermedio2, actualizacionintermedia2);

  puntaje2.text = c.ToString();

  // actualizamos la mano del jugador 1 en cada frame.

 funcionatualizar(manodeljugador1, actualizacionmano1);

  // actualizamos la mano del jugador 2 en cada frame.

  funcionatualizar(manodeljugador2, actualizacionmano2);

   // actualizemos la fila de ataque cuerpo a cuerpo del jugador 1.

  funcionatualizar(cuerpoacuerpo1, actualizacioncuarpoacuerpo1);
   // actualizemos la fila de ataque cuerpo a cuerpo del jugador 2.

    funcionatualizar(cuerpoacuerpo2, actualizacioncuerpoacuerpo2);
   // actualizemos la fila de ataque a distancia del jugador 1.

    funcionatualizar (distancia1, actualizaciondistancia1);

   // actualizemos la fila de ataque a distancia del jugador 2.
    funcionatualizar (distancia2, actualizaciondistancia2);
  
   // actualizemos la fila de ataque intermedio del jugador 1.
   funcionatualizar(intermedia1, actualizacionintermedia1);

   // actualizemos la fila de ataque intermedio del jugador 2.
   funcionatualizar(intermedia2 , actualizacionintermedia2);
}

// funcion para limpiar todo el campo de ser necesario.
void limpiarcampo()
{

 actualizacioncuarpoacuerpo1.Clear();
 actualizacioncuerpoacuerpo2.Clear();
 actualizaciondistancia1.Clear();
 actualizaciondistancia2.Clear();
 actualizacionintermedia1.Clear();
 actualizacionintermedia2.Clear();
 valorcuerpoacuerpo1.Clear();
 valorcuerpoacuerpo2.Clear();
 valordistancia1.Clear();
 valordistancia2.Clear();
 valorintermedio1.Clear();
 valorintermedio2.Clear();
}
  
// verificar si alguien gano alguna partida
void ganar()
{
 if(cdepass==2)
 {     
   if(int.Parse(puntaje1.text)>int.Parse(puntaje2.text))
   {
     int c = int.Parse(partidasj1.text);
     c++;
     partidasj1.text = c.ToString();
   }
   
   if(int.Parse(puntaje1.text)<int.Parse(puntaje2.text))
   {
      int c = int.Parse(partidasj2.text);
      c++;
      partidasj2.text = c.ToString();
   }

   if(puntaje1.text==puntaje2.text)
   {
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
    juegoacabado(); 
 }

}

// erificar si alguno de los jugadores gano el juego
void juegoacabado()
{
  if(partidasj1.text == partidasj2.text && partidasj1.text == "2")
  {
    SceneManager.LoadScene("empate");

    return ;
  }

  if(partidasj1.text == "2")
  {
    SceneManager.LoadScene("win j1");
  }

  if(partidasj2.text == "2")
  {
    SceneManager.LoadScene("win j2");
  }

}

// funcion Update de Unity.
private void Update() 

{
  actualizacion();
  ganar();   

}

 public void mostrarcasrta (int n){

  Button aux;
  detall script;

  if(turno)
  {
    aux = manodeljugador1[n-1].GetComponentInChildren<Button>();
    script = actualizacionmano1[n-1].GetComponent<detall>();
  } 
  else
  {
    aux =  manodeljugador2[n-1].GetComponentInChildren<Button>();
    script = actualizacionmano2[n-1].GetComponent<detall>();
  } 

  cartagrande.GetComponent<Image>().enabled = true;
  cartagrande.sprite = aux.image.sprite;
  tipodecarta.text += script.tipo;

}

public void quitarcartagrande()
{
  cartagrande.GetComponent<Image>().enabled = false;
  tipodecarta.text="";

}

}