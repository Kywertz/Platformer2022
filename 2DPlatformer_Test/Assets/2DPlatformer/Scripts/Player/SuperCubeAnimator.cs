namespace GSGD2.Player
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using GSGD2.Utilities;
    public class SuperCubeAnimator : MonoBehaviour
    {
        [SerializeField]
        private PlayerReferences _playerReferences = null;
        //Runtime
        private CubeController _cubeController = null;
        private Animator _animator = null;
        private Rigidbody _rigidbody = null;
        [SerializeField]
        private float _endJumpDownwardSpeedThresholdWhenGrounded = 5f;
        [SerializeField]
        private DisplacementEstimationUpdater _displacementEstimationUpdater = null;

        private void Awake()
        {
            _playerReferences.TryGetCubeController(out _cubeController);
            _playerReferences.TryGetAnimator(out _animator);
            _playerReferences.TryGetRigidbody(out _rigidbody);
            _playerReferences.TryGetDisplacementEstimationUpdater(out _displacementEstimationUpdater);
        }

        private void OnEnable()
        {
           
            _cubeController.StateChanged -= _cubeController_StateChanged;
           
            _cubeController.StateChanged += _cubeController_StateChanged;
        }


        private void OnDisable()
        {
          
            _cubeController.StateChanged -= _cubeController_StateChanged;
        }
        private void _cubeController_StateChanged(CubeController cubeController, CubeController.CubeControllerEventArgs args)
        {
            Debug.Log("SuperCubeAnimator StateChanged:{0}");

            switch (args.currentState)
            {
                case CubeController.State.None:
                    break;
                case CubeController.State.Grounded:
                    {
                        var downwardVelocityBelowThreshold = Vector3.Dot(_displacementEstimationUpdater.Velocity, -transform.up) > _endJumpDownwardSpeedThresholdWhenGrounded;
                        if (downwardVelocityBelowThreshold == true)
                        {
                            _animator.SetTrigger("EndJump");
                            
                        }
                    }
                    break;
                case CubeController.State.Falling:
                    {
                        _animator.SetTrigger("Falling");
                    }
                    break;
                case CubeController.State.Bumping:
                    break;
                case CubeController.State.StartJump:
                    {
                        //_animator.SetTrigger("Jumping");
                    }
                    break;
                case CubeController.State.Jumping:
                    {
                        _animator.SetTrigger("Jumping");
                       
                    }
                    break;
                case CubeController.State.EndJump:
                    {

                        //_animator.SetTrigger("EndJump");
                    }
                    break;
                case CubeController.State.WallGrab:
                    break;
                case CubeController.State.WallJump:
                    break;
                case CubeController.State.Dashing:
                    break;
                case CubeController.State.DamageTaken:
                    break;
                case CubeController.State.Everything:
                    break;
                default:
                    break;
            }


        }

        private void Update()
        {
            float value = _rigidbody.velocity.z;
            _animator.SetFloat("IdleRunBlend", Mathf.Abs(value));
        }
    }
}