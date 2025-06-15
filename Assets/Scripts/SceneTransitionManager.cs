using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{

    public float changeTime;
    public string sceneName;

    private void Update()
    {
        changeTime -= Time.deltaTime;
        if(changeTime <= 0){
            SceneManager.LoadScene(sceneName);
        }
    }
}
