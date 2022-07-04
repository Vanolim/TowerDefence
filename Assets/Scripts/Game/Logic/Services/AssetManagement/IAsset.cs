using UnityEngine;

public interface IAsset : IService
{
    GameObject Instantiate(string path);
    GameObject Instantiate(string path, Vector3 at);
    GameObject Instantiate(string path, Transform container);
    GameObject Instantiate(string path, Transform transform, Transform container);
}