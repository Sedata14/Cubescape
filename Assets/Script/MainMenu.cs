using System;
using UnityEngine.SceneManagement;

public static  class MainMenu { 

    public enum Scene
    {
        Game,
        Loading,
    }

    private static Action onLoaderCallBack;

 

    public static void LoadScene(Scene scene)
    {
        onLoaderCallBack = () =>
        {
            SceneManager.LoadScene(scene.ToString());
        };

        SceneManager.LoadScene(Scene.Loading.ToString());
    }

    public static void LoaderCallBack()
    {
         if(onLoaderCallBack != null)
        {
            onLoaderCallBack();
            onLoaderCallBack = null;
        }
    }

}
