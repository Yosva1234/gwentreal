using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace gwentII{
  public class Tokenizar 
{

public List <Tokens> wordskey = new List<Tokens>();

public List <string> lines {get; set;}

public Tokenizar (List <string> liststring)
{
    lines = new List<string> (liststring);
    start(0,0);
}

public void start(int i, int j)
{

    string s ="";
    
   for (int x = i; x<lines.Count; x++)
   {
   for(int y = j; y<lines[x].Length; x++)
   {
    
      

   }
   }

}

}}
