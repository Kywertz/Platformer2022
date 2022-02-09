using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using GSGD2.Player;
public class TouchManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _UiAttaqueBaseSelection;
    [SerializeField]
    private GameObject _UiRatAttackSelection;
    [SerializeField]
    private GameObject _UiDashSelection;
    [SerializeField]
    private GameObject _UiHealSpellSelection;

    private InputAction _UiAttaqueBaseInputAction;
    private InputAction _UiRatAttackInputAction;
    private InputAction _UiDashInputAction;
    private InputAction _UiHealSpellInputAction;

    [SerializeField]
    private InputActionMapWrapper _attaqueBasicMapWrapper = null;

    [SerializeField]
    private InputActionMapWrapper _dashMapWrapper = null;

    [SerializeField]
    private InputActionMapWrapper _healSpellMapWrapper = null;

    [SerializeField]
    private InputActionMapWrapper _secondAttaqueMapWrapper = null;

    private float _float = 1f;

    private void OnEnable()
    {
        if (_attaqueBasicMapWrapper.TryFindAction("BasicAttack", out _UiAttaqueBaseInputAction) == true)
        {
            _UiAttaqueBaseInputAction.performed -= ButtonAttackPerformed;
            _UiAttaqueBaseInputAction.performed += ButtonAttackPerformed;
            _UiAttaqueBaseInputAction.Enable();
        }

        if (_dashMapWrapper.TryFindAction("Dash", out _UiDashInputAction) == true)
        {
            _UiDashInputAction.performed -= ButtonDashPerformed;
            _UiDashInputAction.performed += ButtonDashPerformed;
            _UiDashInputAction.Enable();
        }

        if (_healSpellMapWrapper.TryFindAction("HealSpell", out _UiHealSpellInputAction) == true)
        {
            _UiHealSpellInputAction.performed -= ButtonHealSpellSPerformed;
            _UiHealSpellInputAction.performed += ButtonHealSpellSPerformed;
            _UiHealSpellInputAction.Enable();
        }

        if (_secondAttaqueMapWrapper.TryFindAction("SecondAttackDefaultInput", out _UiRatAttackInputAction) == true)
        {
            _UiRatAttackInputAction.performed -= ButtonRatAttackPerformed;
            _UiRatAttackInputAction.performed += ButtonRatAttackPerformed;
            _UiRatAttackInputAction.Enable();
        }
    }

    private void OnDisable()
    {
        if (Application.isPlaying == false)
        {

            _UiAttaqueBaseInputAction.performed -= ButtonAttackPerformed;
            _UiAttaqueBaseInputAction.Disable();
            _UiDashInputAction.performed -= ButtonDashPerformed;
            _UiDashInputAction.Disable();
            _UiHealSpellInputAction.performed -= ButtonHealSpellSPerformed;
            _UiHealSpellInputAction.Disable();
            _UiRatAttackInputAction.performed -= ButtonRatAttackPerformed;
            _UiRatAttackInputAction.Disable();
        }
    }

    public void ButtonAttackPerformed(InputAction.CallbackContext obj)
    {
        _UiAttaqueBaseSelection.SetActive(true);
        _UiRatAttackSelection.SetActive(false);
        _UiHealSpellSelection.SetActive(false);
        _UiDashSelection.SetActive(false);
    }

    public void ButtonRatAttackPerformed(InputAction.CallbackContext obj)
    {
        _UiRatAttackSelection.SetActive(true);
        _UiAttaqueBaseSelection.SetActive(false);
        _UiHealSpellSelection.SetActive(false);
        _UiDashSelection.SetActive(false);
    }

    public void ButtonDashPerformed(InputAction.CallbackContext obj)
    {
        _UiDashSelection.SetActive(true);
        _UiAttaqueBaseSelection.SetActive(false);
        _UiRatAttackSelection.SetActive(false);
        _UiHealSpellSelection.SetActive(false);
    }

    public void ButtonHealSpellSPerformed(InputAction.CallbackContext obj)
    {
        _UiHealSpellSelection.SetActive(true);
        _UiAttaqueBaseSelection.SetActive(false);
        _UiRatAttackSelection.SetActive(false);
        _UiDashSelection.SetActive(false);
    }

    private void Update()
    {
        _float -= Time.deltaTime;

        if (_float == 0|| _float < 0 )
        {
            _UiAttaqueBaseSelection.SetActive(false);
            _UiRatAttackSelection.SetActive(false);
            _UiDashSelection.SetActive(false);
            _UiHealSpellSelection.SetActive(false);
            _float = 0.5f;
        }

       
    }
}
