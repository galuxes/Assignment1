using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ParticleSpawner : MonoBehaviour
{
    private Vector3 _clickPos = Vector3.zero;
    [SerializeField] private GameObject _particle;
    
    private void Update()
    {
        var mouse = Mouse.current;
        
        if (mouse.leftButton.wasPressedThisFrame)
        {
            Vector2 screenPosition = mouse.position.ReadValue();
            //Debug.Log(screenPosition);
            if (Camera.main != null)
            {
                Vector3 worldSpace = Camera.main.ScreenToWorldPoint(screenPosition);

                worldSpace.z = 0;
                
                _clickPos = worldSpace;
                Debug.Log(_clickPos);
            }
        }

        if (mouse.leftButton.wasReleasedThisFrame)
        {
            var obj =Instantiate(_particle, _clickPos, Quaternion.identity);
            
            Vector2 screenPosition = mouse.position.ReadValue();

            if (Camera.main != null)
            {
                Vector3 worldSpace = Camera.main.ScreenToWorldPoint(screenPosition);

                worldSpace.z = 0;

                obj.GetComponent<Particle2D>().velocity = worldSpace - _clickPos;
            }
        }
    }
}
