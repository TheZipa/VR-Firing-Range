using System;

namespace FiringRange.Code.Services.SceneLoader
{
    public interface ISceneLoader : IGlobalService
    {
        void LoadScene(string sceneName, Action onLoaded = null);
    }
}