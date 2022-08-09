using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPattern.Command
{
    public class MoveObject : MonoBehaviour
    {
        private const float MOVE_STEP_DISTANCE = 1f;

        public void MoveFoward()
        {
            Move(Vector3.up);
            Debug.Log($"위");
        }

        public void MoveBack()
        {
            Move(Vector3.down);
            Debug.Log($"아래");
        }

        public void TurnLeft()
        {
            Rotate(90f);
            Debug.Log($"왼쪽");
        }

        public void TurnRight()
        {
            Rotate(-90f);
            Debug.Log($"오른쪽");
        }

        private void Move(Vector3 direction)
        {
            transform.Translate(direction * MOVE_STEP_DISTANCE);
        }

        private void Rotate(float degree)
        {
            transform.Rotate(Vector3.forward, degree);
        }
    }
}
