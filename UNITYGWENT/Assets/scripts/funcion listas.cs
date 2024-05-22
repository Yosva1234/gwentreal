using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
namespace Gwent{
public class funcionlistas : funcionefectos
{
    public void apagarcampo( bool b)
{
   apagar(cuerpoacuerpo1,b);
   apagar(cuerpoacuerpo2, b);
   apagar(intermedia1, b);
   apagar(intermedia2, b);
   apagar(distancia1, b);
   apagar(distancia2, b);
   apagar(manodeljugador1, b);
   apagar(manodeljugador2, b);

}

public void apagar(List <GameObject> aux, bool b)
{
    for(int x = 0; x<aux.Count; x++) aux[x].GetComponentInChildren<Button>().GetComponent<Image>().enabled = b;
}

public void senuelo(detall script)
  {
    bsenuelo = true;
   apagarcampo(false);
   if(turno)
   {
    if(script.cc) {apagar(cuerpoacuerpo1, true);   senueloslist = actualizacioncuarpoacuerpo1;  senueloval = valorcuerpoacuerpo1;}
    if(script.ai) {apagar(intermedia1, true);      senueloslist = actualizacionintermedia1;     senueloval = valorintermedio1;}
    if(script.ad) {apagar(distancia1,true);        senueloslist = actualizaciondistancia1;      senueloval = valordistancia1;}
   }
   else
   {
    if(script.cc) {apagar(cuerpoacuerpo2, true);   senueloslist = actualizacioncuerpoacuerpo2;  senueloval = valorcuerpoacuerpo2;} 
    if(script.ai) {apagar(intermedia2, true);      senueloslist = actualizacionintermedia2;     senueloval = valorintermedio2;}
    if(script.ad) {apagar(distancia2,true);        senueloslist = actualizaciondistancia2;      senueloval = valordistancia2;}
   }
  }

  public void intercambiosenuelo(int n)
{
    robarcarta aux = new robarcarta();

     if(!turno) 
     {
        mazo1.Insert(0,senueloslist[n-1]);
        aux.robar(1,mazo1,actualizacionmano1,manodeljugador1);
     }
     else 
     {
        mazo2.Insert(0,senueloslist[n-1]);
        aux.robar(1,mazo2,actualizacionmano2,manodeljugador2);
     }
    
     if(senueloslist[n-1].GetComponent<detall>().LP == 0 ) turno = !turno;
     senueloval[n-1] = -1;
     bsenuelo = false;

     apagarcampo(true);
}
    
}
}