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

public TMP_Text puntaje1, puntaje2, partidasj1, partidasj2;
public Image taparcarta1, taparcarta2, cartagrande, tipodecarta;
public Sprite muestracartaponerasedio, cartacuerpoacuerpo, cartadistancia, cartaintermedia;
public Button jefe1, jefe2;
public List <Button> asediobutton = new List<Button> ();
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
     Button aux3 = manodeljugador1[actualizacionmano1.Count].GetComponentInChildren<Button>();
     aux3.GetComponent<Image>().enabled = true;
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
     Button aux3 = manodeljugador2[actualizacionmano2.Count].GetComponentInChildren<Button>();
     aux3.GetComponent<Image>().enabled = true;
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
 {
   script = actualizacionmano1[n-1].GetComponent<detall>();
   Button aux = actualizacionmano1[n-1].GetComponentInChildren<Button>();
   asediobutton[ponerasedio-1].image.sprite = aux.image.sprite;
 }
 
  
  else 
  {
     script = actualizacionmano2[n-1].GetComponent<detall>();
     Button aux = actualizacionmano2[n-1].GetComponentInChildren<Button>();
     asediobutton[ponerasedio-1].image.sprite = aux.image.sprite;
  }
 

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


// funciones correspondientes a las cartas de senuelo
bool toquesenuelo = false;

// en esta funcion vamos a apagar o encender las imagenes de las cartas en el campo 
// en dependencia de las necesidades
  void onofcard(List <GameObject> lista, int size , bool b)
  {
    for (int x = 0; x < size ; x++)
    {
      Button aux = lista[x].GetComponentInChildren<Button>();
      aux.GetComponent<Image>().enabled = b;
    }
  }

// en esta funcion vamos a usar la funcion onofcard para apagar y encenderlas cartas 
// necesarias para que el senuelo pueda hacer el swap
void senuelo(detall script){

 toquesenuelo = true;
 
  char c = script.tipo;

    onofcard(cuerpoacuerpo1,actualizacioncuarpoacuerpo1.Count, false);
  
    onofcard(cuerpoacuerpo2, actualizacioncuerpoacuerpo2.Count, false);

    onofcard(distancia1, actualizaciondistancia1.Count, false);

    onofcard(distancia2, actualizaciondistancia2.Count, false);

    onofcard(intermedia1, actualizacionintermedia1.Count, false);
  
    onofcard(intermedia2, actualizacionintermedia2.Count, false);

    onofcard(manodeljugador1, actualizacionmano1.Count, false);

    onofcard(manodeljugador2, actualizacionmano2.Count, false);

  if( c == 'c')
  {
      if (turno) 
      onofcard(cuerpoacuerpo1, actualizacioncuarpoacuerpo1.Count, true);

      else
      onofcard(cuerpoacuerpo2, actualizacioncuerpoacuerpo2.Count, true);
  }

  if( c == 'd' )
  {
    if (turno) 
    onofcard(distancia1 , actualizaciondistancia1.Count, true);

    else
     onofcard(distancia2, actualizaciondistancia2.Count, true);

  if( c == 'i' )
  {
    if (turno)  
   onofcard(intermedia1, actualizacionintermedia1.Count, true);
   
   else
   onofcard(intermedia2, actualizacionintermedia2.Count, true);
  } 

}
}

public void efectocampo( int x )
{

  if (toquesenuelo)
  {
     
    detall script;
    GameObject botoncampo = mazo[0];
    Button aux;
  
    if(turno) 
    {
      script = actualizacionmano1[n-1].GetComponent<detall>();
      
      if (script.tipo == 'c') 
      {
        aux = cuerpoacuerpo1[actualizacioncuarpoacuerpo1.Count].GetComponentInChildren<Button>();
        aux.GetComponent<Image>().enabled = true;
        invocarcarta( actualizacioncuarpoacuerpo1, valorcuerpoacuerpo1);
        botoncampo = actualizacioncuarpoacuerpo1[x-1];
        valorcuerpoacuerpo1[x-1]=-1;
      }


      if(script.tipo == 'd')
      {
        aux = distancia1[actualizaciondistancia1.Count].GetComponentInChildren<Button>();
        aux.GetComponent<Image>().enabled = true;
        invocarcarta( actualizaciondistancia1,valordistancia1);
        botoncampo = actualizaciondistancia1[x-1];
        valordistancia1[x-1]=-1;
      }
      if(script.tipo == 'i')
      {
        aux = intermedia1[actualizacionintermedia1.Count].GetComponentInChildren<Button>();
        aux.GetComponent<Image>().enabled = true;
        invocarcarta (actualizacionintermedia1, valorintermedio1);
        botoncampo = actualizacionintermedia1[x-1];
        valorintermedio1[x-1]=-1;
      }

      mazo1.Insert(0 , botoncampo);
      robar(1,true,false);

      turno = false;

    }
    else
    {
      script = actualizacionmano2[n-1].GetComponent<detall>();
      
      if (script.tipo == 'c') 
      {
        aux = cuerpoacuerpo2[actualizacioncuerpoacuerpo2.Count].GetComponentInChildren<Button>();
        aux.GetComponent<Image>().enabled = true;
        invocarcarta( actualizacioncuerpoacuerpo2, valorcuerpoacuerpo2);
        botoncampo = actualizacioncuerpoacuerpo2[x-1];
        valorcuerpoacuerpo2[x-1]=-1;
      }


      if(script.tipo == 'd')
      {
        aux = distancia2[actualizaciondistancia2.Count].GetComponentInChildren<Button>();
        aux.GetComponent<Image>().enabled = true;
        invocarcarta( actualizaciondistancia2,valordistancia2);
        botoncampo = actualizaciondistancia2[x-1];
        valordistancia2[x-1]=-1;
      }
      if(script.tipo == 'i')
      {
        aux = intermedia2[actualizacionintermedia2.Count].GetComponentInChildren<Button>();
        aux.GetComponent<Image>().enabled = true;
        invocarcarta (actualizacionintermedia2, valorintermedio2);
        botoncampo = actualizacionintermedia2[x-1];
        valorintermedio2[x-1]=-1;
      }

      mazo2.Insert(0 , botoncampo);
      robar(1,false,true);

      turno = true;

    } 
  
    onofcard(cuerpoacuerpo1,actualizacioncuarpoacuerpo1.Count, true);
  
    onofcard(cuerpoacuerpo2, actualizacioncuerpoacuerpo2.Count, true);

    onofcard(distancia1, actualizaciondistancia1.Count, true);

    onofcard(distancia2, actualizaciondistancia2.Count, true);

    onofcard(intermedia1, actualizacionintermedia1.Count, true);
  
    onofcard(intermedia2, actualizacionintermedia2.Count, true);

    onofcard(manodeljugador1, actualizacionmano1.Count, true);

    onofcard(manodeljugador2, actualizacionmano2.Count, true);

    toquesenuelo = false;

  }

}

// esta funcion pone una carta del deck directamente en la mano
void ponercartamano(List<GameObject> deck , string name)
{
    
    for (int x = 0; x<deck.Count ; x++)
    {
        detall aux = deck[x].GetComponent<detall>();
        if( aux.nombrecarta == name )
        {
           if(turno)
           {
            mazo1.Insert(0,deck[x]);
            robar(1,true,false);
            //deck.RemoveAt(x+1);
           }
           else
           {
             mazo2.Insert(0,deck[x]);
             robar(1,false,true);
           } 
           return ;
        }
    }
}

// funcion utilizada para invocar cartas
void invocarcarta(  List <GameObject> campo, List <int> val )
{

  detall script ;

  if (turno)
  {
    script = actualizacionmano1[n-1].GetComponent<detall>();
    val.Add(script.LP);
    campo.Add(actualizacionmano1[n-1]);
    actualizacionmano1.RemoveAt(n-1);
  }

  else
  {
    script = actualizacionmano2[n-1].GetComponent<detall>();
    val.Add(script.LP);
    campo.Add(actualizacionmano2[n-1]);
    actualizacionmano2.RemoveAt(n-1);
  }


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
    
   if ( script.tipo != 'a' && script.LP == 0) 
   {
     senuelo(script);
     return;
   }

   if(script.tipo == 'c' ) 
   {
    if(actualizacioncuarpoacuerpo1.Count >=8 ) return ;
     // si tiene 0 ptos de vida pues seria un senuelo.
     actualizacioncuarpoacuerpo1.Add(actualizacionmano1[n-1]);
     valorcuerpoacuerpo1.Add(script.LP);
     Button aux =  cuerpoacuerpo1[actualizacioncuarpoacuerpo1.Count-1].GetComponentInChildren<Button>();
     aux.GetComponent<Image>().enabled = true;
   }
    

   if(script.tipo == 'd' ) 
   {
    if(actualizaciondistancia1.Count >= 8) return ;

     actualizaciondistancia1.Add(actualizacionmano1[n-1]);
     valordistancia1.Add(script.LP);
      Button aux =  distancia1[actualizaciondistancia1.Count-1].GetComponentInChildren<Button>();
     aux.GetComponent<Image>().enabled = true;
   }

   if(script.tipo == 'i' )
   {
    if(actualizacionintermedia1.Count >= 8) return ;

     actualizacionintermedia1.Add(actualizacionmano1[n-1]);
     valorintermedio1.Add(script.LP);
     Button aux =  intermedia1[actualizacionintermedia1.Count-1].GetComponentInChildren<Button>();
     aux.GetComponent<Image>().enabled = true;
   }

   if(script.tipo == 'a' ) 
   {
     if (ponerasedio == 0 ) 
     return ;
     asedio();
   }
   
   ponerasedio = 0;
   actualizacionmano1.RemoveAt(n-1);
   efectoinvocar(script);
   turno = false;

   return ;
  }

  if(!turno)
  {
   detall script = actualizacionmano2[n-1].GetComponent<detall>();

   if ( script.tipo != 'a' && script.LP == 0) 
   {
     senuelo(script);
     return;
   }

   if(script.tipo == 'c' ) 
   {
    if(actualizacioncuerpoacuerpo2.Count >= 8 ) return ;

     actualizacioncuerpoacuerpo2.Add(actualizacionmano2[n-1]);
     valorcuerpoacuerpo2.Add(script.LP);
     Button aux =  cuerpoacuerpo2[actualizacioncuerpoacuerpo2.Count-1].GetComponentInChildren<Button>();
     aux.GetComponent<Image>().enabled = true;
   }

   if(script.tipo == 'd' )
   {
    if(actualizaciondistancia2.Count >= 8) return ;

     actualizaciondistancia2.Add(actualizacionmano2[n-1]);
     valordistancia2.Add(script.LP);
      Button aux =  distancia2[actualizaciondistancia2.Count-1].GetComponentInChildren<Button>();
     aux.GetComponent<Image>().enabled = true;
   }

   if(script.tipo == 'i' ) 
   {
    if(actualizacionintermedia2.Count >= 8) return ;

     actualizacionintermedia2.Add(actualizacionmano2[n-1]);
     valorintermedio2.Add(script.LP);
     Button aux =  intermedia2[actualizacionintermedia2.Count-1].GetComponentInChildren<Button>();
     aux.GetComponent<Image>().enabled = true;
   }

   if(script.tipo == 'a' )
   {

     if (ponerasedio == 0 ) 
     return;

     asedio();
    }

   ponerasedio = 0;
   actualizacionmano2.RemoveAt(n-1);
   efectoinvocar(script);
   turno = true;
  }



}

// funciones ligadas a los efectos de morir e invocar 
void efectoinvocar(detall script){

  string nombre = script.nombrecarta;
  
  if( nombre == "barbaros de elite")
  {
    if(turno) 
    {
      Button aux = cuerpoacuerpo1[actualizacioncuarpoacuerpo1.Count].GetComponentInChildren<Button>();
      aux.GetComponent<Image>().enabled = true;
      actualizacioncuarpoacuerpo1.Add(actualizacioncuarpoacuerpo1[actualizacioncuarpoacuerpo1.Count-1]);
      valorcuerpoacuerpo1.Add(script.LP);
    }

    else
    {
      Button aux = cuerpoacuerpo2[actualizacioncuerpoacuerpo2.Count].GetComponentInChildren<Button>();
      aux.GetComponent<Image>().enabled = true;
      actualizacioncuerpoacuerpo2.Add(actualizacioncuerpoacuerpo2[actualizacioncuerpoacuerpo2.Count-1]);
      valorcuerpoacuerpo2.Add(script.LP);
    }
  }

  if( nombre == "espiritu electrico")
  {     
    ponercartamano(mazo,"gigante electrico");
    
  }
 
  if( nombre == "espiritu de fuego")
  {
    ponercartamano(mazo,"cohete");
  }

  if( nombre == "golem")
  {
    int c = 0;
    char c1 = '0' ;
    int pos = int.MaxValue;

    if (turno)
    {
     
      for (int x = 0 ; x < valordistancia1.Count; x++)
    {
       if (valordistancia1[x] > c )
        {
          c = valordistancia1[x];
          c1 = 'd';
          pos = x;
        }
    }

    for (int x = 0 ; x < valorintermedio1.Count; x++)
    {
       if (valorintermedio1[x] > c )
        {
          c = valorintermedio1[x];
          c1 = 'i';
          pos = x;
        }
    }

      if (pos == int.MaxValue) return ;

      if(c1 == 'd')   valordistancia1[pos] = -1;
      if(c1 == 'i')   valorintermedio1[pos] = -1;  

    }

    else 
    {
    
      for (int x = 0 ; x < valordistancia2.Count; x++)
    {
       if (valordistancia2[x] > c )
        {
          c = valordistancia2[x];
          c1 = 'd';
          pos = x;
        }
    }

    for (int x = 0 ; x < valorintermedio2.Count; x++)
    {
       if (valorintermedio2[x] > c )
        {
          c = valorintermedio2[x];
          c1 = 'i';
          pos = 0;
        }
    }

      if (pos == int.MaxValue) return ;

      if(c1 == 'd')   valordistancia2[pos] = -1;
      if(c1 == 'i')   valorintermedio2[pos] = -1;  

    }

    

  }

}

void efectomorir( detall script, bool tocajugarenelframe)
{
  if(script.nombrecarta == "golem de elixir")
  {

   // Debug.Log("soiiiiiiii");
    GameObject golem = new GameObject();
    for(int x = 0; x < mazo.Count; x++)
    {
      detall aux = mazo[x].GetComponent<detall>();
      if(aux.nombrecarta == script.nombrecarta) 
      {
        golem = mazo[x];
        break;
      }
    }

    if(tocajugarenelframe)
    {
      Button aux;
      if(actualizacioncuarpoacuerpo1.Count < 8) 
      aux = cuerpoacuerpo1[actualizacioncuarpoacuerpo1.Count].GetComponentInChildren<Button>();
      
      else return;
      
     
      actualizacioncuarpoacuerpo1.Add(golem);
      aux.image.enabled = true; 
      
      if(actualizacioncuarpoacuerpo1.Count < 8) 
      aux = cuerpoacuerpo1[actualizacioncuarpoacuerpo1.Count].GetComponentInChildren<Button>();
      
      else return;
      actualizacioncuarpoacuerpo1.Add(golem);  
      aux.image.enabled = true;
      valorcuerpoacuerpo1.Add(3);
      valorcuerpoacuerpo1.Add(3);
    }

    else
    {
      Button aux;
      if(actualizacioncuerpoacuerpo2.Count < 8 )
      aux = cuerpoacuerpo2[actualizacioncuerpoacuerpo2.Count].GetComponentInChildren<Button>();

      else return;
   
      actualizacioncuerpoacuerpo2.Add(golem);
      aux.image.enabled = true; 
      valorcuerpoacuerpo2.Add(3);
     
      if(actualizacioncuerpoacuerpo2.Count < 8 )
      aux = cuerpoacuerpo2[actualizacioncuerpoacuerpo2.Count].GetComponentInChildren<Button>();

      else return;

      actualizacioncuerpoacuerpo2.Add(golem);  
      aux.image.enabled = true;
      valorcuerpoacuerpo2.Add(3);
    } 

  }
}


// funcion adjunta a los botones de las cartas jefe y el parametro m si es == a 1 pues la carta jefe que ha sido 
// seleccionada es el mk y se activara su efecto el cual es elegir un numero de fila aleatorio del campo del contrario
// y si esa fila tiene monstruos pues elegira uno de ellos al azar y los elimina del campo de batalla y sino 
// tiene monstruos pues perdiste el turno. y si m == 2 pues se activa el efecto del pekka y roba una carta.

public void jugarjefe( int m )
{

 if (toquesenuelo) return;

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
   Button aux2 = listaaux[x].GetComponentInChildren<Button>();

   //if(!aux.GetComponent<Image>().enabled) 
   //aux.GetComponent<Image>().enabled = true;

   aux.image.sprite = aux2.image.sprite;
  }

  for(int x = listaaux.Count; x < listvisual.Count; x++)
  {
    Button aux = listvisual[x].GetComponentInChildren<Button>();
    aux.GetComponent<Image>().enabled = false;
  }


}


int actualizarpuntos( List <int> listaval, List <GameObject> listavisual, bool tocajugarenelframe)
{

  int c =0;

  for(int x=0; x< listaval.Count; x++)
  {
    salto:

    if(listaval.Count == x)
    break;

    if(listaval[x]<0)
    {

     detall aux = listavisual[x].GetComponent<detall>();
     
      listavisual.RemoveAt(x);
      listaval.RemoveAt(x);

  efectomorir(aux, tocajugarenelframe); 

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

 c+= actualizarpuntos(valorcuerpoacuerpo1,actualizacioncuarpoacuerpo1, true);

 c+= actualizarpuntos(valordistancia1, actualizaciondistancia1, true);

 c+= actualizarpuntos(valorintermedio1, actualizacionintermedia1, true);

  puntaje1.text = c.ToString();

  c=0;

 c+= actualizarpuntos(valorcuerpoacuerpo2,actualizacioncuerpoacuerpo2, false);

 c+= actualizarpuntos(valordistancia2, actualizaciondistancia2, false);

 c+= actualizarpuntos(valorintermedio2, actualizacionintermedia2, false);

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

  for(int x =0; x<asediobutton.Count; x++) asediobutton[x].image.sprite=muestracartaponerasedio;

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
  
  tipodecarta.GetComponent<Image>().enabled = true;
  if(script.tipo == 'c')
  {
    tipodecarta.sprite = cartacuerpoacuerpo;
  }
  if(script.tipo == 'd')
  {
    tipodecarta.sprite = cartadistancia;
  }
  if(script.tipo == 'i')
  {
    tipodecarta.sprite = cartaintermedia;
  }
  if(script.tipo == 'a')
  {
    tipodecarta.sprite = muestracartaponerasedio;
  }
}

public void quitarcartagrande()
{
  cartagrande.GetComponent<Image>().enabled = false;
  tipodecarta.GetComponent<Image>().enabled = false;

}

}