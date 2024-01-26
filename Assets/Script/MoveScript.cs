using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScript : MonoBehaviour
{
    public string Main; // 移動先のシーン名


    private void Start()
    {

    }

    void Update()
    {
        // マウスの左クリックを検知


    }
    public void MoveScriptCall()
    {


        SceneManager.LoadScene(Main);

    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}

