using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

 namespace Gwent{
public class elementos : MonoBehaviour
{
     
public TMP_Text puntaje1, puntaje2, partidasj1, partidasj2 , efecto;
public Image taparcarta1, taparcarta2, cartagrande, tipodecarta;
public Sprite muestracartaponerasedio, cartacuerpoacuerpo, cartadistancia, cartaintermedia;
public Button jefe1, jefe2;
public List <Button> asediobutton = new List<Button> ();
public List <GameObject> mazo = new List<GameObject>();
public List <GameObject> mazo1 = new List<GameObject>();
public List <GameObject> mazo2 = new List<GameObject>();
public List <GameObject> manodeljugador1 = new List<GameObject>();
public List <GameObject> manodeljugador2 = new List<GameObject>();
public List <GameObject> actualizacionmano1 = new List<GameObject>();
public List <GameObject> actualizacionmano2 = new List<GameObject>();
public List <int> valordistancia1 = new List<int>();
public List <int> valordistancia2 = new List<int>();
public List <GameObject> distancia1 = new List<GameObject>();
public List <GameObject> distancia2 = new List<GameObject>();
public List <GameObject> actualizaciondistancia1 = new List<GameObject>();
public List <GameObject> actualizaciondistancia2 = new List<GameObject>();
public List <int> valorcuerpoacuerpo1 = new List<int>();
public List <int> valorcuerpoacuerpo2 = new List<int>();
public List <GameObject> cuerpoacuerpo1 = new List<GameObject>();
public List <GameObject> cuerpoacuerpo2 = new List<GameObject>();
public List <GameObject> actualizacioncuarpoacuerpo1 = new List<GameObject>();
public List <GameObject> actualizacioncuerpoacuerpo2 = new List<GameObject>();
public List <int> valorintermedio1 = new List<int>();
public List <int> valorintermedio2 = new List<int>();
public List <GameObject> intermedia1 = new List<GameObject>();
public List <GameObject> intermedia2 = new List<GameObject>();
public List <GameObject> actualizacionintermedia1 = new List<GameObject>();
public List <GameObject> actualizacionintermedia2 = new List<GameObject>();
public bool turno = true, bmk = true, bpekka = true, bsenuelo = false;
public int cardposition = 0;
public int asedioposition = 0, senueloposition = 0;
public List <GameObject> senueloslist = new List<GameObject>();
public List <int>  senueloval = new List<int>();
public int pass = 0;
}
}
