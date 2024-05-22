using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Gwent;
using UnityEngine;

public class funcionefectos : elementos
{
   
   public void entrada(efectos script)
   {
    
        if(script.limpiarfila)
        {
            jefes clear = new jefes();
            if(turno)
            {
                if(script.limpiarcc) clear.pekka(valorcuerpoacuerpo2);
                if(script.limpiarad) clear.pekka(valordistancia2);
                if(script.limpiarin) clear.pekka(valorintermedio2);
            }
            else
            {
                if(script.limpiarcc) clear.pekka(valorcuerpoacuerpo1);
                if(script.limpiarad) clear.pekka(valordistancia1);
                if(script.limpiarin) clear.pekka(valorintermedio1);
            }    

        }

        if(script.modificarfila)
        {
            if(script.valormodificar <0 ) turno=!turno;


             if(turno)
             {
                if(script.modificarad) modificar(valordistancia1,script.valormodificar);
                if(script.modificarcc) modificar(valorcuerpoacuerpo1, script.valormodificar);
                if(script.modificarin) modificar(valorintermedio1, script.valormodificar);
             }
             else
             {
                 if(script.modificarad) modificar(valordistancia2,script.valormodificar);
                if(script.modificarcc) modificar(valorcuerpoacuerpo2, script.valormodificar);
                if(script.modificarin) modificar(valorintermedio2, script.valormodificar);
             }
             
             
             if(script.valormodificar <0 ) turno=!turno;
        }
    
        if(script.traercartamano)
        {
            if(turno) 
            actualizacionmano1.Add(script.nombrecartatraermano);

           else 
           actualizacionmano2.Add(script.nombrecartatraermano);

        }
  
        if(script.traercartacampo)
        {   
            traercarta (script.nombrecartatraercampo);
        }
        
        if(script.jugardoble)
        {
            turno = !turno;
        }
  
        if(script.destruirmenor)
        {
            if(turno)
            {
                if(script.menorcc) menor(valorcuerpoacuerpo2);
                if(script.menorad) menor(valordistancia2);
                if(script.menorin) menor(valorintermedio2);
            }
            else{
                 if(script.menorcc) menor(valorcuerpoacuerpo1);
                if(script.menorad) menor(valordistancia1);
                if(script.menorin) menor(valorintermedio1);
            }
        }
 
        if(script.destruirmayor)
        {
            if(turno)
            {
                if(script.mayorcc) mayor(valorcuerpoacuerpo2);
                if(script.mayorad) mayor(valordistancia2);
                if(script.mayorin) mayor(valorintermedio2);
            }
            else{
                 if(script.mayorcc) mayor(valorcuerpoacuerpo1);
                if(script.mayorad) mayor(valordistancia1);
                if(script.mayorin) mayor(valorintermedio1);
            }
        }
   }
 void menor(List <int> val )
 {
    int n = int.MaxValue;
    int pos=-1;

    for (int x = 0; x<val.Count; x++)
    {
        if(val[x] < n) 
        {
            n=val[x];
            pos=x;
        }


    }
  if(pos == -1) return ;

  val[pos] = -1;
 }
 void mayor(List <int> val )
 {
    int n = int.MinValue;
    int pos=-1;

    for (int x = 0; x<val.Count; x++)
    {
        if(val[x] > n) 
        {
            n=val[x];
            pos=x;
        }


    }
  if(pos == -1) return ;

  val[pos] = -1;
 }
   void traercarta(GameObject cartac)
   {
            detall carta = cartac.GetComponent<detall>();
            botones jugar = new botones();
            if(!turno)
            {
               if(carta.ai) jugar.jugarcarta(cartac,intermedia2,actualizacionintermedia2,valorintermedio2);
               if(carta.ad) jugar.jugarcarta(cartac,distancia2,actualizaciondistancia2,valordistancia2);
               if(carta.cc) jugar.jugarcarta(cartac,cuerpoacuerpo2,actualizacioncuerpoacuerpo2,valorcuerpoacuerpo2);
            }
            else
            {
                if(carta.ai) jugar.jugarcarta(cartac,intermedia1,actualizacionintermedia1,valorintermedio1);
               if(carta.ad) jugar.jugarcarta(cartac,distancia1,actualizaciondistancia1,valordistancia1);
               if(carta.cc) jugar.jugarcarta(cartac,cuerpoacuerpo1,actualizacioncuarpoacuerpo1,valorcuerpoacuerpo1);
            }
   }
   void modificar(List <int> aux, int n)
    {
        for (int x = 0; x<aux.Count; x++) aux[x]+=n;
    }
}
