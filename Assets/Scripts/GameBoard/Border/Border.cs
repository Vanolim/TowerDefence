using UnityEngine;

public class Border : MonoBehaviour
{
   [SerializeField] private ZoneBorder _zoneBorder;
   [SerializeField] private MeshRenderer _meshRenderer;

   private void OnEnable()
   {
      _zoneBorder.OnEnter += EnableView;
      _zoneBorder.OnExit += DisableView;
   }

   private void EnableView() => _meshRenderer.enabled = true;
   private void DisableView() => _meshRenderer.enabled = false;

   private void OnDisable()
   {
      _zoneBorder.OnEnter -= EnableView;
      _zoneBorder.OnExit -= DisableView;
   }
}
