using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.Endless
{
    public class GamepadController : MonoBehaviour
    {
        public bool isOnMobile;
        public static GamepadController Ins;

        private bool m_canJump;

        public bool CanJump { get => m_canJump; set => m_canJump = value; }

        private void Awake()
        {
            Ins = this;
        }

        private void Update()
        {
            if (!isOnMobile)
                m_canJump = Input.GetKeyDown(KeyCode.Space);
        }
    }
}
