using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCangeSts : MonoBehaviour
{
    //スタティック変数を初期化
    public void ResetSts()
    {
        TrainingButtonHamamatu.activeHamamatu = false;
        TrainingButtonHuzi.activeHuzi = false;
        TrainingButtonYama.activeYama = false;
        TrainingButtonIzu.activeIzu = false;
        TrainingButtonShizuoka.activeShizu2 = false;

        TrainingButtonHamamatu.canShotHamaButton = false;
        TrainingButtonHuzi.canShotHuziButton = false;
        TrainingButtonYama.canShotYamaButton = false;
        TrainingButtonIzu.canShotIzuButton = false;
        TrainingButtonShizuoka.canShotShizuButton2 = false;
        TrainingButtonShizuoka.canShotShizuButton = true;

        Emitter.stageCount = 1;
        PlayerHp.playerHp = 5;
        Score.maney = 0;
        TrainingEndButton.stageCount = 1;


}
}
