using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlLoader : MonoBehaviour
{
    [SerializeField] int indexScene;
    
    public void Load()
    {
        SceneManager.LoadScene(indexScene);
    }
}
