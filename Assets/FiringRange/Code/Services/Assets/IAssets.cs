using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace FiringRange.Code.Services.Assets
{
    public interface IAssets : IGlobalService
    {
        UniTask<T> Load<T>(string address) where T : class;
        UniTask<T> Load<T>(AssetReference assetReference) where T : class;
        void CleanUp();
        UniTask<T> Instantiate<T>(string address, Transform parent = null) where T : Object;
        UniTask<T> Instantiate<T>(string address, Vector3 at, Quaternion rotation, Transform parent = null) where T : Object;
        UniTask<T> LoadPersistent<T>(string address) where T : class;
        UniTask<T> Instantiate<T>(AssetReference assetReference, Transform parent = null) where T : Object;
    }
}