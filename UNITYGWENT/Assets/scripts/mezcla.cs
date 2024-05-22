
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


 namespace Gwent{

public class mezclar: MonoBehaviour
{


  public void rellenarmazo(List <GameObject> mazoprincipal, List<GameObject> mazorellenar, int count)
  {

  for (int x=0; x<mazoprincipal.Count; x++)    mazorellenar.Add( mazoprincipal[x] );
  
 
 while (mazorellenar.Count!=count)
 {
   System.Random random = new System.Random();
   int n = random.Next(0,mazorellenar.Count-1);
   mazorellenar.RemoveAt(n);
 }

 for (int x = 0; x< 40; x++)
 {
   System.Random random1 = new System.Random();
   int n1 = random1.Next(0,mazorellenar.Count-1);
   System.Random random2 = new System.Random();
   int n2 = random2.Next(0,mazorellenar.Count-1);
   
   GameObject aux = mazorellenar[n1];
   mazorellenar[n1] = mazorellenar[n2];
   mazorellenar[n2] = aux;
 }

 }
 }
 }