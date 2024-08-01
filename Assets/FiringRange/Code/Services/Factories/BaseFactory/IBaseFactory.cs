using Cysharp.Threading.Tasks;
using FiringRange.Code.Data.StaticData;
using FiringRange.Code.Services.EntityContainer;
using UnityEngine;

namespace FiringRange.Code.Services.Factories.BaseFactory
{
    public interface IBaseFactory
    {
        UniTask<T> InstantiateAsRegistered<T>(Vector3 at, Quaternion rotation, Transform parent = null) where T : Object, IFactoryEntity;
        UniTask<T> InstantiateAsRegistered<T>(Transform parent = null) where T : Object, IFactoryEntity;
        UniTask<T> Instantiate<T>(Transform parent = null) where T : Object;
        UniTask<T> Instantiate<T>(string assetKey, Transform parent = null) where T : Object;
        UniTask<T> InstantiateAsRegistered<T>(Location location, Transform parent = null) where T : Object, IFactoryEntity;
    }
}