using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class eeded : MonoBehaviour
{

    public Button boton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseOver()
    {
        boton.GetComponent<Image>().enabled = false;
    }
    // Update is called once per frame
   
}
