using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : Menu
{
    public GameObject GameOverUI;
    public TMP_Text endStateTxt;
    public TMP_Text deathDescTxt;

    public void Display(string typeOfEndState, Faction fact) {
        switch(typeOfEndState) {
            case "factionRepZero":
                endStateTxt.text = "You Died";
                endStateTxt.color = Color.red;
                deathDescTxt.text = "Looks like someone got on the bad side of " + fact.getName() + 
                ". Well, the worst side, and you paid the ultimate price. Try not to let your reputation get so low with them next time";
                break;
            case "debt":
                endStateTxt.text = "You Died";
                endStateTxt.color = Color.red;
                deathDescTxt.text = "The vendors of this world don't take too kindly to strangers racking up such a debt." +
                "Try not to go 500 shards into the negative next time";
                break;
            case "voidDeath":
                endStateTxt.text = "You Died";
                endStateTxt.color = Color.red;
                deathDescTxt.text = "The Null is a nasty place. Few make it back out of the nothing. Though there are whispers of something more" +
                "Fanciful thinking. Like someone will risk their life for whatever is beyond";
                break;
            case "enemyDeath":
                endStateTxt.text = "You Died";
                endStateTxt.color = Color.red;
                deathDescTxt.text = "Everyone takes a hit from those crazed flyers. You just took a few more than you could handle";
                break;
            case "burnoutDeath":
                endStateTxt.text = "You Died";
                endStateTxt.color = Color.red;
                deathDescTxt.text = "Tis a harsh place out there when there is not a ounce of fuel to be found";
                break;
            case "factionRepFull":
                endStateTxt.text = "You Win";
                endStateTxt.color = Color.green;
                deathDescTxt.text = "Congratulations! You have built up such a high reputation with " + fact.getName() + 
                " that they will take you in under their care and protection. You will never want for anything again";
                break;
            case "voidEsc":
                endStateTxt.text = "You Win";
                endStateTxt.color = Color.green;
                deathDescTxt.text = "Congratulations! You have found true freedom. Out here, beyond the limited skies of Jura, Naardval and " +
                "Welkan, you are not bound to hauling. You can do as please. Forever";
                break;
            default:
                endStateTxt.text = "You Died";
                endStateTxt.color = Color.red;
                deathDescTxt.text = "Unlucky in Death";
                break;
        }
        GameOverUI.SetActive(true);

    }

}
