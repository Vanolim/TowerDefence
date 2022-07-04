using System.Collections.Generic;
using UnityEngine;

public class UpdateGameWorld : MonoBehaviour, IPauseble
{
    private List<ITickable> _tickables = new List<ITickable>();
    private bool _isPaused = false;

    public void AddTickableItem(ITickable tickable) => _tickables.Add(tickable);

    private void Update()
    {
        if (_isPaused == false)
        {
            foreach (var item in _tickables)
            {
                item.Tick();
            }
        }
    }

    public void SetPause(bool isPaused) => _isPaused = isPaused;
}
