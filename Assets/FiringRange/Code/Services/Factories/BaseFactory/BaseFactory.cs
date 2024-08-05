using Cysharp.Threading.Tasks;
using FiringRange.Code.Data.StaticData;
using FiringRange.Code.Data.StaticData.Location;
using FiringRange.Code.Services.Assets;
using FiringRange.Code.Services.EntityContainer;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace FiringRange.Code.Services.Factories.BaseFactory
{
    public abstract class BaseFactory : IBaseFactory
    {
        protected readonly IAssets _assets;
        protected readonly IEntityContainer _entityContainer;

        protected BaseFactory(IAssets assets, IEntityContainer entityContainer)
        {
            _assets = assets;
            _entityContainer = entityContainer;
        }

        public async UniTask<T> InstantiateAsRegistered<T>(Location location, Transform parent = null) where T : Object, IFactoryEntity =>
            await InstantiateAsRegistered<T>(location.Position, Quaternion.Euler(location.Rotation), parent);

        public async UniTask<T> InstantiateAsRegistered<T>(Vector3 at, Quaternion rotation, Transform parent = null) where T : Object, IFactoryEntity
        {
            GameObject instantiatedObject = await _assets.Instantiate<GameObject>(typeof(T).Name, at, rotation, parent);
            T component = instantiatedObject.GetComponent<T>();
            _entityContainer.RegisterEntity(component);
            return component;
        }
        
        public async UniTask<T> InstantiateAsRegistered<T>(Transform parent = null) where T : Object, IFactoryEntity
        {
            GameObject instantiatedObject = await _assets.Instantiate<GameObject>(typeof(T).Name, parent);
            T component = instantiatedObject.GetComponent<T>();
            _entityContainer.RegisterEntity(component);
            return component;
        }

        public async UniTask<T> Instantiate<T>(Location location, Transform parent = null) where T : Object => 
            await Instantiate<T>(location.Position, location.Rotation, parent);

        public async UniTask<T> Instantiate<T>(Vector3 at, Vector3 rotation, Transform parent = null) where T : Object
        {
            GameObject instantiatedObject = await _assets.Instantiate<GameObject>(typeof(T).Name, parent);
            instantiatedObject.transform.position = at;
            instantiatedObject.transform.rotation = Quaternion.Euler(rotation);
            return instantiatedObject.GetComponent<T>();
        }

        public async UniTask<T> Instantiate<T>(Transform parent = null) where T : Object
        {
            GameObject instantiatedObject = await _assets.Instantiate<GameObject>(typeof(T).Name, parent);
            return instantiatedObject.GetComponent<T>();
        }

        public async UniTask<T> Instantiate<T>(AssetReference asset, Transform parent = null) where T : Object
        {
            GameObject instantiatedObject = await _assets.Instantiate<GameObject>(asset, parent);
            return instantiatedObject.GetComponent<T>();
        }
    }
}