namespace GSGD2.Gameplay
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;
    using GSGD2.Player;
    using UnityEngine.InputSystem;
    using GSGD2.Extensions;

    /// <summary>
    /// Register a position where the player will be reset if entering the <see cref="KillZone"/>.
    /// The index can indicate the checkpoint, but it is not used by the framework itself.
    /// Checkpoint must be on the same gameobject as the collider since we'll not using rigidbody.
    /// Therefore, a <see cref="CheckpointFeedbackHandler"/> must be added as parent.
    /// </summary>
    public class Checkpoint : MonoBehaviour
    {
        [SerializeField]
        private PhysicsTriggerEvent _physicsTriggerEvent = null;

        [SerializeField]
        private GameObject _ennemies = null;

        [SerializeField]
        private EnnemiesManager _ennemiesManager = null;

        [SerializeField]
        private int _index = 0;

        [SerializeField]
        private InputActionMapWrapper _inputActionMapWrapper = null;

        private int _healthToChange = 50;

        private InputAction _abilityImproverInteractionInputAction = null;

        private bool _hasBeenTriggeredYet = false;

        private bool _isentered = false;

        [SerializeField]
        private GameObject _canvas = null;

        public int Index => _index;

        public enum EventType
        {
            FirstTimeReachedCheckpoint,
            CheckpointPassed,
            CheckpointExited
        }

        public delegate void CheckpointEvent(Checkpoint checkpoint, EventType eventType);
        public event CheckpointEvent _checkpointTriggered = null;

        public UnityEvent<Checkpoint> NewCheckpointAdded = null;
        public UnityEvent<Checkpoint> CheckpointPassed = null;
        public UnityEvent<Checkpoint> CheckpointExited = null;

        private void OnEnable()
        {
            LevelReferences.Instance.PlayerStart.AddCheckpoint(this);

            _physicsTriggerEvent._onTriggerEnter.RemoveListener(OnPhysicsTriggerEventEnter);
            _physicsTriggerEvent._onTriggerEnter.AddListener(OnPhysicsTriggerEventEnter);
            _physicsTriggerEvent._onTriggerExit.RemoveListener(OnPhysicsTriggerEventExit);
            _physicsTriggerEvent._onTriggerExit.AddListener(OnPhysicsTriggerEventExit);

            _checkpointTriggered -= OnCheckpointTriggered;
            _checkpointTriggered += OnCheckpointTriggered;

            if (_inputActionMapWrapper.TryFindAction("AbilityImproverInteraction", out _abilityImproverInteractionInputAction) == true)
            {
                _abilityImproverInteractionInputAction.performed -= AbilityImproverInteractionInputAction_performed;
                _abilityImproverInteractionInputAction.performed += AbilityImproverInteractionInputAction_performed;

            }
            _abilityImproverInteractionInputAction.Enable();
        }

        private void OnDisable()
        {
            _physicsTriggerEvent._onTriggerEnter.RemoveListener(OnPhysicsTriggerEventEnter);
            _physicsTriggerEvent._onTriggerExit.RemoveListener(OnPhysicsTriggerEventExit);

            _checkpointTriggered -= OnCheckpointTriggered;

            if (ApplicationExtension.IsPlaying == true)
            {
                _abilityImproverInteractionInputAction.performed -= AbilityImproverInteractionInputAction_performed;
                _abilityImproverInteractionInputAction.Disable();
                _canvas.gameObject.SetActive(false);
            }
            _abilityImproverInteractionInputAction.Disable();
        }

        private void OnPhysicsTriggerEventEnter(PhysicsTriggerEvent physicsTriggerEvent, Collider other)
        {
            CubeController concreteOther = other.GetComponentInParent<CubeController>();
            if (concreteOther != null)
            {
                _canvas.gameObject.SetActive(true);
                _isentered = true;
            }

        }

        private void LifeRefill()
        {
            if (LevelReferences.Instance.PlayerReferences.TryGetPlayerDamageable(out PlayerDamageable playerDamageable) == true)
            {

                playerDamageable.RestoreHealth(_healthToChange);

            }
        }

        private void OnPhysicsTriggerEventExit(PhysicsTriggerEvent physicsTriggerEvent, Collider other)
        {
            CubeController concreteOther = other.GetComponentInParent<CubeController>();
            if (concreteOther != null)
            {
                _checkpointTriggered.Invoke(this, EventType.CheckpointExited);
            }
            _canvas.gameObject.SetActive(false);
            _isentered = false;

        }

        private void AbilityImproverInteractionInputAction_performed(InputAction.CallbackContext obj)
        {
            Debug.Log("Test input");
            if (_isentered == true)
            {
                LevelReferences.Instance.PlayerStart.UpdateLastCheckpoint(this);
                _checkpointTriggered.Invoke(this, _hasBeenTriggeredYet == true ? EventType.CheckpointPassed : EventType.FirstTimeReachedCheckpoint);
                _hasBeenTriggeredYet = true;
                LevelReferences.Instance.SpellManager.ReloadSpells();
                LifeRefill();

               for (int i = 0; i < _ennemiesManager._spawners.Length; i++)
                {
                    Instantiate(_ennemies, transform.position, transform.rotation);
                    //LevelReferences.Instance.EnnemiesManager._spawners.
                    //comment avoir la position des spawner ?
                }

            }
        }

        private void OnCheckpointTriggered(Checkpoint checkpoint, EventType eventType)
        {
            switch (eventType)
            {
                case EventType.FirstTimeReachedCheckpoint:
                    {
                        NewCheckpointAdded.Invoke(this);
                    }
                    break;
                case EventType.CheckpointPassed:
                    {
                        CheckpointPassed.Invoke(this);
                    }
                    break;
                case EventType.CheckpointExited:
                    {
                        CheckpointExited.Invoke(this);
                    }
                    break;
                default: break;


            }
        }
    }
}