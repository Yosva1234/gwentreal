using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Cargarescena : MonoBehaviour
{
    private string sceneToLoa = "CAMPO DE JUEGO";
    public TMP_InputField J1,J2;
    

    public void LoadSceneOnClick()
    {
        SceneManager.LoadScene(sceneToLoa);
    }




}



