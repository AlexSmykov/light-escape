using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Darkness
{
    public class DarknessMove : MonoBehaviour, IDarknessMove
    {
        [SerializeField] private float defaultSpeed = 1f;
        [SerializeField] private bool isRunning = true;
        [SerializeField] private Vector2 direction = new(0f, 0f);
        [SerializeField] private List<float> multiplies = new();
        private Rigidbody2D _rigidbody;

        /// <summary>
        /// Return 1 if _multiplies is empty
        /// </summary>
        public float Speed
        {
            get { return isRunning ? multiplies.Aggregate(defaultSpeed, (x, y) => x * y) : 0f; }
        }

        public void StopDarkness()
        {
            isRunning = false;
        }

        public void ContinueDarkness()
        {
            isRunning = true;
        }

        public void AddMultipleToDarkness(float multiplier)
        {
            multiplies.Add(multiplier);
        }

        public void ClearAllMultiple()
        {
            multiplies.Clear();
        }

        private void Start()
        {
            Debug.Log("DARKNESS: START WORKING");
        }

        private void FixedUpdate()
        {
            transform.Translate(Time.smoothDeltaTime * Speed * direction);
        }
    }
}