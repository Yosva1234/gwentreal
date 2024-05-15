using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgrandarCarta : MonoBehaviour
{
  private Vector3 originalScale; // Tamaño original de la carta
    public float enlargementFactor = 1.1f; // Factor de agrandamiento
  
    private void Start()
    {
        // Guarda el tamaño original de la carta al inicio
        originalScale = transform.localScale;
    }

    private void Update()
    {
        // Verifica si el cursor está sobre la carta
        if (RectTransformUtility.RectangleContainsScreenPoint(
            GetComponent<RectTransform>(), Input.mousePosition))
        {
            // Agrandar la carta
            transform.localScale = originalScale * enlargementFactor;
        }
        else
        {
            // Restaurar el tamaño original
            transform.localScale = originalScale;
        }
        
    }
}
