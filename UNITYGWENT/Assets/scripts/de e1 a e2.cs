using UnityEngine;
using UnityEngine.SceneManagement;

 namespace Gwent{
public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad;

    public void LoadSceneOnClick()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
 }