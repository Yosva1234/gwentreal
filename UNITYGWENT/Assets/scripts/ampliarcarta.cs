using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ampliarcarta : MonoBehaviour
{
    // Start is called before the first frame update

    public Image carta;
    public Button cartaaux;
    
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()){
            carta.GetComponent<Image>().enabled = true;
            carta.sprite = cartaaux.image.sprite;
        }
    }
}
