
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
public class ponercartagrande : MonoBehaviour
{
    // Start is called before the first frame update
   

    public void ponerla(GameObject mano, Image carta)
    {
       carta.sprite =  mano.GetComponentInChildren<Button>().image.sprite;
       carta.GetComponent<Image>().enabled = true;
    }

    public void quitar(Image carta, Image tipo, TMP_Text efecto)
    {
        carta.GetComponent<Image>().enabled = false;
        tipo.GetComponent<Image>().enabled = false;
        efecto.text = "";
    }

    public void tipo(Sprite cc, Sprite asedio, Sprite ai, Sprite ad, Image poner, detall script, TMP_Text efecto)
    {
        poner.GetComponent<Image>().enabled = true;
        if(script.cc) poner.sprite = cc;
        if(script.asedio) poner.sprite=asedio;
        if(script.ad) poner.sprite = ad;
        if(script.ai) poner.sprite = ai;

        efecto.text = script.efectoc;
    }

}
