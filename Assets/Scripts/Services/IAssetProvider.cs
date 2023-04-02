using UnityEngine;

namespace Services
{
    public interface IAssetProvider : IService
    {
        public T Load<T>(string path) where T : Object;
    }
}