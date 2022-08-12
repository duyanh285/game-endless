using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.Endless
{
    public class MainMenu : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            if (AudioController.ins == null) return;

            AudioController.ins.PlayMusic(AudioController.ins.menus);
        }

       
    }
}
