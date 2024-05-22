
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
public class definitivomecanicas : funcionlistas
{
   // elementos escena = new elementos();
    mezclar objetomezclar = new mezclar();
    robarcarta objetorobar = new robarcarta();
    actualizacioncampo objetoactualizar  =  new actualizacioncampo();
    botones objetoboton =  new botones();
    jefes objetojefe = new jefes();
    ponercartagrande objetocartagrande = new ponercartagrande();


    void Start()
    {
        objetomezclar.rellenarmazo(mazo, mazo1, 24 );
        objetomezclar.rellenarmazo(mazo, mazo2, 24 ); 

        objetorobar.robar(10,mazo1,actualizacionmano1,manodeljugador1);
        objetorobar.robar(10,mazo2,actualizacionmano2,manodeljugador2);
    }
    void Update()
    {
      objetoactualizar.actualizarcartas(actualizacionmano1, manodeljugador1);
      objetoactualizar.actualizarcartas(actualizacionmano2, manodeljugador2);
      objetoactualizar.actualizarcartas(actualizacioncuarpoacuerpo1, cuerpoacuerpo1);
      objetoactualizar.actualizarcartas(actualizacionintermedia1, intermedia1);
      objetoactualizar.actualizarcartas(actualizaciondistancia1, distancia1);
      objetoactualizar.actualizarcartas(actualizacioncuerpoacuerpo2, cuerpoacuerpo2);
      objetoactualizar.actualizarcartas(actualizaciondistancia2, distancia2);
      objetoactualizar.actualizarcartas(actualizacionintermedia2, intermedia2);

     puntaje1.text = (objetoactualizar.actualizarpuntos(valorcuerpoacuerpo1, puntaje1) + objetoactualizar.actualizarpuntos(valorintermedio1, puntaje1) + objetoactualizar.actualizarpuntos(valordistancia1, puntaje1)).ToString();
     puntaje2.text = (objetoactualizar.actualizarpuntos(valorcuerpoacuerpo2,puntaje2) + objetoactualizar.actualizarpuntos(valorintermedio2,puntaje2) + objetoactualizar.actualizarpuntos(valordistancia2, puntaje2)).ToString();
      
     objetoactualizar.taparacartas(turno, taparcarta1, taparcarta2); 

     objetoactualizar.muerto(valorcuerpoacuerpo1,actualizacioncuarpoacuerpo1);
     objetoactualizar.muerto(valorintermedio1,actualizacionintermedia1);
     objetoactualizar.muerto(valorintermedio2,actualizacionintermedia2);
     objetoactualizar.muerto(valorcuerpoacuerpo2, actualizacioncuerpoacuerpo2);
     objetoactualizar.muerto(valordistancia1, actualizaciondistancia1);
     objetoactualizar.muerto(valordistancia2, actualizaciondistancia2);


     objetoactualizar.mostrarjefes(jefe1,jefe2,turno,bmk,bpekka);
    
    if(objetoactualizar.ganar(pass,puntaje1,puntaje2,partidasj1,partidasj2))
    {
      objetojefe.pekka(valorintermedio2);
      objetojefe.pekka(valorintermedio1);
      objetojefe.pekka(valorcuerpoacuerpo2);
      objetojefe.pekka(valorcuerpoacuerpo1);
      objetojefe.pekka(valordistancia2);
      objetojefe.pekka(valordistancia1);
      for (int x = 0; x < asediobutton.Count; x++) asediobutton[x].image.sprite = muestracartaponerasedio;
      pass = 0;
      bmk = true;
      bpekka = true;
      objetorobar.robar(2,mazo1,actualizacionmano1,manodeljugador1);
      objetorobar.robar(2,mazo2,actualizacionmano2,manodeljugador2);
    }
    }
   public void botonmano(int n) 
   {
    detall script = new detall();
    efectos efectscript = new efectos();
       if(turno)
       {
        script = actualizacionmano1[n-1].GetComponent<detall>();
        efectscript = actualizacionmano1[n-1].GetComponent<efectos>();
        entrada(efectscript);

        if(script.LP == 0) senuelo(script);
        if(script.ai) objetoboton.jugarcarta(actualizacionmano1[n-1],intermedia1,actualizacionintermedia1,valorintermedio1);
        if(script.ad) objetoboton.jugarcarta(actualizacionmano1[n-1],distancia1,actualizaciondistancia1,valordistancia1);
        if(script.cc) objetoboton.jugarcarta(actualizacionmano1[n-1],cuerpoacuerpo1,actualizacioncuarpoacuerpo1,valorcuerpoacuerpo1);
        if(script.asedio) funcionasedio(n);
        else actualizacionmano1.RemoveAt(n-1);
        turno = !turno;
        asedioposition = 0;
        pass = 0;
        return;
       
       }
      else 
      {
        script = actualizacionmano2[n-1].GetComponent<detall>();
        efectscript = actualizacionmano2[n-1].GetComponent<efectos>();
        entrada(efectscript);

        if(script.LP == 0) senuelo(script);
        if(script.ai) objetoboton.jugarcarta(actualizacionmano2[n-1],intermedia2,actualizacionintermedia2,valorintermedio2);
        if(script.ad) objetoboton.jugarcarta(actualizacionmano2[n-1],distancia2,actualizaciondistancia2,valordistancia2);
        if(script.cc) objetoboton.jugarcarta(actualizacionmano2[n-1],cuerpoacuerpo2,actualizacioncuerpoacuerpo2,valorcuerpoacuerpo2);
        if(script.asedio) funcionasedio(n);
        else actualizacionmano2.RemoveAt(n-1);
        asedioposition = 0;
        turno = !turno;
        pass = 0;
      }
   }
  public void funcionasedio(int n)
  {
        if(asedioposition == 0){  turno = !turno; return ;}

        List <GameObject> aux =  new List<GameObject>();
        if(turno) aux=actualizacionmano1;
        else aux=actualizacionmano2;

            if(asedioposition == 1) objetoboton.jugarasedio(n,valorintermedio2,asediobutton[0],aux);
            if(asedioposition == 2) objetoboton.jugarasedio(n,valordistancia2,asediobutton[1],aux);
            if(asedioposition == 3) objetoboton.jugarasedio(n,valorcuerpoacuerpo2,asediobutton[2],aux);
            if(asedioposition == 4) objetoboton.jugarasedio(n,valorcuerpoacuerpo1,asediobutton[3],aux);
            if(asedioposition == 5) objetoboton.jugarasedio(n,valordistancia1,asediobutton[4],aux);
            if(asedioposition == 6) objetoboton.jugarasedio(n,valorintermedio1,asediobutton[5],aux);    
  }
   public void botonasedio(int n)
   {
    asedioposition = n;
   }
  public void botonsenuelo(int n)
  {
   if(!bsenuelo) return ;
   senueloposition = n;
   intercambiosenuelo(n);
  }
  public void mk()
    {
      if(bsenuelo) return;
     objetojefe.mk(valorcuerpoacuerpo2,valorintermedio2,valordistancia2);
     turno = false;
     bmk = false;
    }
 public void pekka()
    {
      if(bsenuelo) return;
     objetojefe.pekka(valorcuerpoacuerpo1);
     turno = true;
     bpekka = false;
    }
  public void pase()
  {
    pass++;
    turno = !turno;
  }
public void botonagrandar(int n)
{
  if(turno)
  {
   objetocartagrande.ponerla(manodeljugador1[n-1] , cartagrande);
   objetocartagrande.tipo(cartacuerpoacuerpo,muestracartaponerasedio,cartaintermedia,cartadistancia,tipodecarta,actualizacionmano1[n-1].GetComponent<detall>(), efecto);
  }
  else
  {
   objetocartagrande.ponerla(manodeljugador2[n-1] , cartagrande);
   objetocartagrande.tipo(cartacuerpoacuerpo,muestracartaponerasedio,cartaintermedia,cartadistancia,tipodecarta,actualizacionmano2[n-1].GetComponent<detall>(), efecto);
  }


  
}
public void botonquitar ()
{
   objetocartagrande.quitar(cartagrande,tipodecarta, efecto);
}

 }
 }