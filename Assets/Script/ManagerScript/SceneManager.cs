using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    //いまのシーンを確認用
    public bool isTittleScene,isLoadingScene, isTutorialScene, isMainGameScene;
    //シーンの名前
    [SerializeField]
    private string TitleSceneName,TutorialSceneName,MainGameSceneName;

    [SerializeField]
    private SceneController _scene;

    [SerializeField]
    private Slider _loadingBar;

    private void Awake()
    {
            if (_scene == null) 
            {
                //_scene = GameObject.FindGameObjectWithTag("SceneControll").GetComponent<SceneController>();
            }


        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "LoadingScene")
        {
            StartCoroutine(LoadLevel(GameObject.Find("SceneCheck").GetComponent<SceneController>().SceneName));
        }
    }

    private void Update()
    {
        if (isTittleScene)
        {
            Cursor.visible = true;
        }
        //else 
        //{
        //    Cursor.visible = false;
        //}

    }


    public void ToTutorialScene() 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_scene.SceneName);
    }

    public void ToMainScene()
    {
        _scene.SceneName = MainGameSceneName;
        UnityEngine.SceneManagement.SceneManager.LoadScene(MainGameSceneName);
    }
    
    public void LoadingScene(string SceneName) 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoadingScene");
        GameObject.Find("SceneCheck").GetComponent< SceneController > ().SceneName = SceneName;
    }

    public void BackToTitle() 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(TitleSceneName);
    }

    public void ExitGame() 
    {
        Application.Quit();
    }

    IEnumerator LoadLevel(string SceneName) 
    {
        yield return new WaitForSeconds(3.0f);
        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SceneName);

        operation.allowSceneActivation = false;

        while (!operation.isDone) 
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            _loadingBar.value = progress;

            if (operation.progress >= 0.9f) 
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
