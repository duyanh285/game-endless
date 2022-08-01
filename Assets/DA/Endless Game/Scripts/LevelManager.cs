using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.Endless
{
    public class LevelManager : MonoBehaviour,ISingleton
    {
        public static LevelManager Ins;
        public LevelItem[] levels;

        private void Awake()
        {
            MakeSingleton();
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void Init()
        {
            if (levels == null || levels.Length <= 0) return;

            for (int i = 0; i < levels.Length; i++)
            {
                var level = levels[i];

                if (level == null) continue;
                if(i==0)
                {
                    //khoa level dau tien
                }
                else
                {
                    //neu du lieu chua duoc luu xuong may nguoi choi
                    //thi se luu du lieu (khoa cac level khac lai)
                }    
            }
        }
        public void MakeSingleton()
        {
            if (Ins == null)
            {
                Ins = this;
                DontDestroyOnLoad(this);
            }
            else
                Destroy(gameObject);
        }
    }
}
