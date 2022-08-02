using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.Endless
{
    public class GameManager : MonoBehaviour, ICompChk
    {
        public static GameManager Ins;
        public float speedUp;
        public GameState state;
        public GameObject warningSignPb;

        private Player m_curPlayer;
        private Block m_curBlock;
        private LevelItem m_curLevel;

        private Vector2 m_camSize;
        private int m_blockIdx;
        private float m_blockSpawnPosY;
        private float m_blockSpeed;
        private int m_score;

        public Block CurBlock { get => m_curBlock; }
        public int Score { get => m_score; }

        private void Awake()
        {
            Ins = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            Init();
        }

        public void Init()
        {
            if (IsComponentsNull()) return;

            state = GameState.Starting;
            m_camSize = Helper.Get2DCamSize();
            m_blockSpawnPosY = -m_camSize.y / 2 + 1f;
            m_curLevel = LevelManager.Ins.GetLevel();
            Pref.hasBestScore = false;
            if (m_curLevel != null)
            {
                m_blockSpeed = m_curLevel.baseSpeed;
                var mapPb = m_curLevel.mapPb;
                if (mapPb)
                    Instantiate(mapPb, Vector3.zero, Quaternion.identity);
                var blockPb = m_curLevel.blockPb;
                if (blockPb)
                    m_curBlock = Instantiate(blockPb, new Vector3(0, m_blockSpawnPosY, 0f), Quaternion.identity);
            }

            ActivePlayer();
        }

        public void ActivePlayer()
        {
            if (IsComponentsNull()) return;

            if (m_curPlayer)
                Destroy(m_curPlayer.gameObject);

            if (m_curLevel != null)
            {
                var newPlayerPb = m_curLevel.playerPb;
                if (newPlayerPb)
                    m_curPlayer = Instantiate(newPlayerPb,new Vector3(0, -1f, 0), Quaternion.identity);

            }
        }

        public bool IsComponentsNull()
        {
            bool checking = LevelManager.Ins == null;

            if (checking)
                Debug.LogError("Some component is null . please check!!!");

            return checking;
        }
    }
}
