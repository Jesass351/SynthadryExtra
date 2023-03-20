using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class BaseBoost : MonoBehaviour
    {
        [Tooltip("Frequency at which the item will move up and down")]
        public float verticalBobFrequency = 1f;

        [Tooltip("Distance the item will move up and down")]
        public float bobbingAmount = 1f;

        [Tooltip("Rotation angle per second")] public float rotatingSpeed = 360f;

        public Rigidbody pickupRigidbody { get; private set; }

        private Collider _collider;
        private Vector3 _startPosition;

        protected virtual void Start()
        {
            pickupRigidbody = GetComponent<Rigidbody>();

            _collider = GetComponent<Collider>();

            pickupRigidbody.isKinematic = true;
            _collider.isTrigger = true;

            _startPosition = transform.position;
        }

        void Update()
        {
            float bobbingAnimationPhase = ((Mathf.Sin(Time.time * verticalBobFrequency) * 0.5f) + 0.5f) * bobbingAmount;
            transform.position = _startPosition + Vector3.up * bobbingAnimationPhase;

            transform.Rotate(Vector3.up, rotatingSpeed * Time.deltaTime, Space.Self);
        }

        void OnTriggerEnter(Collider other)
        {
            CustomCharacterController pickingPlayer = other.GetComponent<CustomCharacterController>();

            if (pickingPlayer != null)
            {
                OnPicked(pickingPlayer);
            }
        }

        protected virtual void OnPicked(CustomCharacterController playerController)
        {
            Destroy(gameObject);
        }
    }
