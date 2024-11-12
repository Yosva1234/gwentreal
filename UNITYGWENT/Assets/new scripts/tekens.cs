using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tokens : MonoBehaviour
{
    // Start is called before the first frame update
        public int fila {get; set;}
        public int columna {get; set;}
        public string tipo {get; set;}
        string nombre {get; set;}
        public Tokens(string name, string tipe, int fill, int column)
        {
            nombre = name;
            tipo = tipe;
            fill = fila;
            column = columna;
        }
}
