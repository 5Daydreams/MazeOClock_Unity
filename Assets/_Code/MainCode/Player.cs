﻿using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace _Code.MainCode
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _stepSpeed = 1;
        private IMovePointBehavior _movePointBehavior;

        private void Awake()
        {
            _movePointBehavior = GetComponent<IMovePointBehavior>();
        }

        public void SetPosition(Vector3 position) // Used by gridGen for repositioning the player
        {
            gameObject.transform.position = position;
        }

        private void Update()
        {
            ChaseMovePoint();

            bool arrivedAtMovePoint =
                Vector3.Distance(transform.position, _movePointBehavior.MovePoint.position) < 0.05f;

            bool onlyOneDirectionIsPressed =
                Math.Abs(Input.GetAxisRaw("Horizontal")) + Math.Abs(Input.GetAxisRaw("Vertical")) == 1.0f;

            if (arrivedAtMovePoint)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    ScreenClickMovement();
                }
                else if (onlyOneDirectionIsPressed)
                {
                    var direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                    _movePointBehavior.StepTowards(direction);
                }
            }
        }

        void ChaseMovePoint()
        {
            transform.position =
                Vector3.MoveTowards(transform.position, _movePointBehavior.MovePoint.position, _stepSpeed*Time.deltaTime);
        }

        void ScreenClickMovement()
        {
            // here, I'm centering the cartesian of the screen in the center, as opposed to the bottom-left corner 
            var screenCenterPosition = new Vector2(Screen.width / 2.0f, Screen.height / 2.0f);
            var xPercent = (Input.mousePosition.x - screenCenterPosition.x) / screenCenterPosition.x;
            var yPercent = (Input.mousePosition.y - screenCenterPosition.y) / screenCenterPosition.y;

            if (Mathf.Abs(xPercent) > Mathf.Abs(yPercent))
            {
                _movePointBehavior.StepTowards(new Vector2(xPercent / Mathf.Abs(xPercent), 0));
            }
            else if (Mathf.Abs(yPercent) > Mathf.Abs(xPercent))
            {
                _movePointBehavior.StepTowards(new Vector2(0, yPercent / Mathf.Abs(yPercent)));
            }
        }
    }
}