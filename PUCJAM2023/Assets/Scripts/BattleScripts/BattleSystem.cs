using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }
public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject infoPanel, dialogue, attackPanal;
    public GameObject[] enemyPrefab;
    public float damage;
   

    public string attackType;
    public bool magicAttack;
    public int magicCost;
    public float defenseMultiplier;
    public float multiplier;

    GameManager gameManager;
    public int currentFightIndex;

    public Transform playerBattleStage;
    public Transform enemyBattleStage;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    public FighterStats playerStats;
    public FighterStats enemyStats;
    public TextMeshProUGUI dialogueText;
    void Start()
    {
        state = BattleState.START;
        GameObject game = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = game.GetComponent<GameManager>();
        StartCoroutine(SetupBattle());
    }
    IEnumerator SetupBattle()
    {
        currentFightIndex = gameManager.whichFightToLoad;
        GameObject enemyGO = Instantiate(enemyPrefab[currentFightIndex], enemyBattleStage);
        enemyStats = enemyGO.GetComponent<FighterStats>();
        enemyHUD.SetHUD(enemyStats);
        dialogueText.text = "A demon " + enemyStats.unitName + " is invoked...";

       
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStage);
        playerStats = playerGO.GetComponent<FighterStats>();
        playerHUD.SetHUD(playerStats);
        yield return new WaitForSeconds(5f);
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }
    public IEnumerator PlayerAttack()
    {
        defenseMultiplier = Random.Range(enemyStats.minDefenseMultiplier, enemyStats.maxDefenseMultiplier);
        damage = multiplier * playerStats.meleeAtck;
        damage = Mathf.Max(0, damage - (defenseMultiplier * enemyStats.defense));
        bool isDead = enemyStats.ReceiveDamage(Mathf.CeilToInt(damage));



        enemyHUD.SetHp(enemyStats.currentHealth);
        infoPanel.SetActive(false);
        dialogue.SetActive(true);
        dialogueText.text = "The attack is successful!";
        yield return new WaitForSeconds(2f);
        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();

        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
    IEnumerator EnemyTurn()
    {
        string attackType = Random.Range(0, 2) == 1 ? "melee" : "ranged";
        enemyPrefab[currentFightIndex].GetComponent<FighterAction>().SelectedAttack(attackType);
        yield return new WaitForSeconds(1f);
        bool isDead = playerStats.ReceiveDamage(0);
        playerHUD.SetHp(playerStats.currentHealth);
        yield return new WaitForSeconds(1f);
        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();

        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

    }
    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "You won the battle!";

        }
        else
        {
            dialogueText.text = "You were defeated";
        }
    }
    void PlayerTurn()
    {
        dialogueText.text = "Choose an action:";
        StartCoroutine(AtivarInfoPLayer());
    }
   IEnumerator AtivarInfoPLayer()
    {
        yield return new WaitForSeconds(3f);
        dialogue.SetActive(false);
        infoPanel.SetActive(true);

    }

    
    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());

    }
}
