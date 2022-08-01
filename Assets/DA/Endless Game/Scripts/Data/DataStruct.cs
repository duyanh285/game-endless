using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DA.Endless
{
   public enum GameTag
    {
        Player,
        Block,
        DeadZone
    }
    public enum GamePlayer
    {
        Player,
        Block,
        Dead
    }

    public enum ChacAnim
    {
        Idle,
        Jump,
        Land,
        Dead
    }

    public enum GamePref 
    {
     BestScore,
     LevelUnlocked,
     CurLevelId,
     IsMusicOn,
     IsSoundOn
    }

    public enum GameScene
    {
        MainMenu,
        GamePlay1
    }

    public enum MoveOirection
    {
        Left,
        Right
    }

    public enum GameState
    {
        Starting,
        Playing,
        Gameover
    }

    [System.Serializable]
    public class LevelItem
    {
        public int scoreRequire;
        public Sprite unlockThumb;
        public Sprite lockThumb;
        public Sprite levelBG;
        public Sprite chacPreviewImg;
        public Player playerPb;
        public Block blockPb;
        public GameObject map;
        public float spawnTime;
        public float baseSpeed;
        public float maxSpeed;
    }
}
