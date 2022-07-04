using UnityEngine;

public class AssetProvider : IAsset
{
    public GameObject Instantiate(string path, Vector3 at)
    {
        var prefab = Resources.Load<GameObject>(path);
        return Object.Instantiate(prefab, at, Quaternion.identity);
    }

    public GameObject Instantiate(string path, Transform container)
    {
        var prefab = Resources.Load<GameObject>(path);
        return Object.Instantiate(prefab, container);
    }

    public GameObject Instantiate(string path)
    {
        var prefab = Resources.Load<GameObject>(path);
        return Object.Instantiate(prefab);
    }

    public GameObject Instantiate(string path, Transform transform, Transform container)
    {
        var prefab = Resources.Load<GameObject>(path);
        return Object.Instantiate(prefab, transform.position, transform.rotation, container);
    }
}
