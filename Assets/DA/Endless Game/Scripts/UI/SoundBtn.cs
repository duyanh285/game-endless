using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace DA.Endless
{
    public class SoundBtn : MonoBehaviour
    {
        private Button m_btn;

        private void Awake()
        {
            m_btn = GetComponent<Button>();
        }

        void Start()
        {
            if (m_btn == null) return;
            if (AudioController.ins == null) return;

            m_btn.onClick.RemoveAllListeners();
            m_btn.onClick.AddListener(() => PlaySound());
        }
        private void PlaySound()
        {
            if (AudioController.ins == null) return;

            AudioController.ins.PlaySound(AudioController.ins.btnClick);
        }
    }
}
