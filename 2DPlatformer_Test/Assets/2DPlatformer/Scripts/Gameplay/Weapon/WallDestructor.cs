using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using GSGD2.Player;
public class WallDestructor : MonoBehaviour
{
    private InputAction _shootInputAction = null;
    private InputAction _horizontalInputAction = null;
    private InputAction _verticalInputAction = null;

    [SerializeField]
    private GameObject _offsetOfTheFlute = null;

    [SerializeField]
    private GameObject _ratBlancToLunch = null;




    [SerializeField]
    private Transform _transformOfDestructor = null;

    [SerializeField]
    private InputActionMapWrapper _InputActionMapWrapper = null;

    private float HorizontalDirection => _horizontalInputAction.ReadValue<float>();
    private float VerticalDirection => _verticalInputAction.ReadValue<float>();


    private void OnEnable()
    {
        if (_InputActionMapWrapper.TryFindAction("SecondAttackDefaultInput", out _shootInputAction, true))
        {
            _shootInputAction.performed -= _inputAction_performed;
            _shootInputAction.performed += _inputAction_performed;
        }


        _InputActionMapWrapper.TryFindAction("SecondAttackVerticalDirection", out _verticalInputAction, true);
        _InputActionMapWrapper.TryFindAction("SecondAttackHorizontalDirection", out _horizontalInputAction, true);


    }

    private void OnDisable()
    {
        _shootInputAction.performed -= _inputAction_performed;
        _shootInputAction.Disable();
    }

    private void _inputAction_performed(InputAction.CallbackContext obj)
    {
        Instantiate(_ratBlancToLunch, _offsetOfTheFlute.transform.position, transform.rotation);
    }

    private void Update()
    {
        Vector3 direction = new Vector3(0, VerticalDirection, HorizontalDirection).normalized;
        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction, -Vector3.right);
            _transformOfDestructor.rotation = rotation;
        }
    }

}