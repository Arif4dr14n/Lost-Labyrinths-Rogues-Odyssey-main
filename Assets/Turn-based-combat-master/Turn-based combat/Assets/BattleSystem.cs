using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public Button attackButton;
    public Button healButton;

    public BattleState state;

    void Start()
    {
        state = BattleState.START;
        Debug.Log("Game started, setting up battle...");
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        Debug.Log("Setting up battle...");

        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        Debug.Log("Setting dialogue: A wild " + enemyUnit.unitName + " approaches...");
        dialogueText.text = "A wild " + enemyUnit.unitName + " approaches...";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(0f);

        Debug.Log("Changing state to PLAYERTURN");
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        Debug.Log("Player turn started. Updating dialogue text.");
        dialogueText.text = "Choose an action:"; // This might be frozen

        // Enable buttons so player can act
        attackButton.interactable = true;
        healButton.interactable = true;
    }

    IEnumerator PlayerAttack()
    {
        Debug.Log("Player attacks!");

        attackButton.interactable = false;
        healButton.interactable = false;

        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        enemyHUD.SetHP(enemyUnit.currentHP);

        Debug.Log("Setting dialogue: The attack is successful!");
        dialogueText.text = "The attack is successful!";

        yield return new WaitForSeconds(2f); // Might be stuck here?

        if (isDead)
        {
            Debug.Log("Enemy defeated. Ending battle.");
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            Debug.Log("Enemy survived. Switching to ENEMYTURN.");
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator PlayerHeal()
    {
        Debug.Log("Player heals!");

        // Disable buttons during action
        attackButton.interactable = false;
        healButton.interactable = false;

        playerUnit.Heal(5);
        playerHUD.SetHP(playerUnit.currentHP);
        dialogueText.text = "You feel renewed strength!";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator EnemyTurn()
    {
        Debug.Log("Enemy turn started.");

        dialogueText.text = enemyUnit.unitName + " attacks!";
        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
        playerHUD.SetHP(playerUnit.currentHP);

        Debug.Log("Player HP after attack: " + playerUnit.currentHP);
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
        Debug.Log("Battle ended with state: " + state);

        if (state == BattleState.WON)
        {
            dialogueText.text = "You won the battle!";
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "You were defeated.";
        }

        // Disable buttons at the end of battle
        attackButton.interactable = false;
        healButton.interactable = false;
    }

    public void OnAttackButton()
    {
        Debug.Log("Attack button pressed! Current state: " + state);

        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerAttack());
    }

    public void OnHealButton()
    {
        Debug.Log("Heal button pressed! Current state: " + state);

        if (state != BattleState.PLAYERTURN)
            return;

        StartCoroutine(PlayerHeal());
    }
}
