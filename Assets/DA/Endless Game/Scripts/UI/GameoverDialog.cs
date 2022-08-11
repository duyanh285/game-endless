using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



namespace DA.Endless
{
    public class GameoverDialog : Dialog
    {
        public Text socreTxt;
        public Text bestScoreTxt;

        public override void Show(bool isShow)
        {
            base.Show(isShow);

            if (socreTxt)
                socreTxt.text = GameManager.Ins.Score.ToString();

            if (Pref.hasBestScore)
            {
                if (bestScoreTxt)
                    bestScoreTxt.text = $"NEW BEST:{Pref.bestScore}";
            }
            else
            {
                if (bestScoreTxt)
                    bestScoreTxt.text = $"TOP SCORE:{Pref.bestScore}";
            }
        }

        public void BackHome()
        {
            Close();
            SceneManager.LoadScene(GameScene.MainMenu.ToString());
        }

        public void Replay()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
