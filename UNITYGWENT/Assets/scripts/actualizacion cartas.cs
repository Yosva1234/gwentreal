using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


namespace Gwent{
public class actualizacioncampo : MonoBehaviour
{

  SceneLoader ganador = new SceneLoader();

    public void actualizarcartas (List <GameObject> auxiliar , List <GameObject> visual)
    {


            for (int x = 0 ; x < auxiliar.Count; x++)
            {
                Button aux = visual[x].GetComponentInChildren<Button>();
              //  aux.GetComponent<Image>().enabled = true;
               aux.image.sprite = auxiliar[x].GetComponentInChildren<Button>().image.sprite;
            }
            for(int x = auxiliar.Count; x < visual.Count; x++)
            {
                visual[x].GetComponentInChildren<Button>().GetComponent<Image>().enabled = false;
            }

    }

    public int actualizarpuntos (List <int> valores, TMP_Text puntos)
    {

        int c = 0;

        for (int x = 0; x < valores.Count; x++) c+=valores[x];

       return c;

    }
    public void taparacartas( bool b, Image j1, Image j2)
    {

        j1.GetComponent<Image>().enabled = !b;
        j2.GetComponent<Image>().enabled = b;

    }

    public void muerto(List <int> val, List <GameObject> campo)
    {
        for(int x = 0 ; x<val.Count; x++)
        {
            if(val[x]<0)
            {
                val.RemoveAt(x);
                campo.RemoveAt(x);
                x--;
            }
        }
    }

  public void mostrarjefes (Button j1, Button j2, bool turno, bool bj1, bool bj2)
  {

        if(bj1) 
        {
            j1.GetComponent<Image>().enabled = turno;
        }
        else j1.GetComponent<Image>().enabled = false;

        if(bj2)
        {
            j2.GetComponent<Image>().enabled = !turno;
        }

        else j2.GetComponent<Image>().enabled = false;

  }

  public bool ganar ( int pass,TMP_Text j1, TMP_Text j2, TMP_Text p1, TMP_Text p2)
  {
       if(pass != 2) return false;


            if(int.Parse(j1.text) > int.Parse(j2.text))
            {
                p1.text = (int.Parse(p1.text)+1).ToString();
                 if(p1.text == "2") 
                {
                    ganador.sceneToLoad = "win j1";
                    ganador.LoadSceneOnClick();
                }
               
            }

            if(int.Parse(j2.text) > int.Parse(j1.text))
            {
                p2.text = (int.Parse(p2.text)+1).ToString();
                
                 if(p2.text == "2") 
                {
                    ganador.sceneToLoad = "win j2";
                    ganador.LoadSceneOnClick();
                }
            }

            if(int.Parse(j1.text) == int.Parse(j2.text))
            {
                p1.text = (int.Parse(p1.text)+1).ToString();
                p2.text = (int.Parse(p2.text)+1).ToString();
                if(p1.text == "2")
                {
                    ganador.sceneToLoad = "empate";
                    ganador.LoadSceneOnClick();
                }
                 
            }

               
           

            j1.text="0";
            j2.text="0";
            return true; 

  }

}
}