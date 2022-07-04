using UnityEngine;

public class HeartView : MonoBehaviour
{
    private bool _isActive;

    public bool IsActive => _isActive;
    public void Activate()
    {
        _isActive = true;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }
}