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
     LevelPrefix,
     CurPlayerId,
     IsMusicOn,
     IsSoundOn
    }

    public enum GameScene
    {
        MainMenu,
        GamePlay
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
}
