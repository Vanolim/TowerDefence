using System;
using UnityEngine;

public class InputHandler : IInputHandler
{
    private Camera _camera;

    private const string IGNORE_LAYER_RAYCAST = "Ignore Raycast";
    private const string IGNORE_LAYER_BORDER = "Border";
    private const string IGNORE_LAYER_HERO = "Hero";

    public event Action<IGoodsView> OnTouchPlaceForSale;
    public event Action<IGoodsView> OnTouchTowerPlace;
    public event Action<IGoodsView> OnTouchRawMine;

    public InputHandler(IInputService inputService)
    {
        inputService.OnTouch += LocateTouch;
    }

    private void LocateTouch(Vector2 position)
    {
        if(_camera == null)
            _camera = Camera.main;
        
        RaycastHit hit = RaycastHit(position);
        if (hit.collider != null)
        {
            GameObject hitObject = hit.collider.gameObject;
            
            if (hitObject.TryGetComponent(out TowerPlace towerPlace))
                OnTouchTowerPlace?.Invoke(towerPlace);
            if(hitObject.TryGetComponent(out TowerPlaceForSale placeForSale))
                OnTouchPlaceForSale?.Invoke(placeForSale);
            if (hitObject.TryGetComponent(out CrystalRawMine crystalRawMine))
                OnTouchRawMine?.Invoke(crystalRawMine);
        }
    }

    private RaycastHit RaycastHit(Vector2 position)
    {
        Physics.Raycast(_camera.ScreenPointToRay(position), out RaycastHit hit, 1000f, ~GetIgnoreLayers());
        return hit;
    }

    private LayerMask GetIgnoreLayers() =>
        (1 << LayerMask.NameToLayer(IGNORE_LAYER_RAYCAST) 
         | (1 << LayerMask.NameToLayer(IGNORE_LAYER_BORDER) | (1 << LayerMask.NameToLayer(IGNORE_LAYER_HERO))));
}