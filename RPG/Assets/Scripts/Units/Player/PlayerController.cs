using UnityEngine;
using UnityEngine.InputSystem;

namespace RPG.Units.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        private StatsAssistant _statsAssistant;
        private PlayerActionControls _controls;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _statsAssistant = new StatsAssistant();
            
            _controls = new PlayerActionControls();
            _controls.GameMap.FastAttack.performed += OnFastAttack;
            _controls.GameMap.StrongAttack.performed += OnStrongAttack;
        }

        private void Update()
        {
            OnMovement();
        }

        private void OnMovement()
        {
            var direction = _controls.GameMap.Movement.ReadValue<Vector2>();

            var velocity = new Vector3(direction.x, 0, direction.y);
            transform.position += velocity * _statsAssistant.GetSpeed() * Time.deltaTime;
        }

        private void OnStrongAttack(InputAction.CallbackContext obj)
        {
            //TODO
            Debug.Log("OnStrongAttack");
        }

        private void OnFastAttack(InputAction.CallbackContext obj)
        {
            //TODO
            Debug.Log("OnFastAttack");
        }

        private void OnDestroy()
        {
            _controls.Dispose();
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }
    }
}
