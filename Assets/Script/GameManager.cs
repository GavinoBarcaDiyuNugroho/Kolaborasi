using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState { START, PLAYERTURN, ENEMYTURN, GAMEWIN, GAMELOSE}

public class GameManager : MonoBehaviour
{
    public GameObject unit;
    public GameObject enemy;

    Unit_Movement unitMovement;
    Unit unitInfo;
    Unit enemyInfo;

    GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        unitMovement = unitInfo.GetComponent<Unit_Movement>();
        gameState = GameState.START;
        StartCoroutine(PlayerTurn());
    }
    IEnumerator PlayerTurn()
    {
        Debug.Log("Choose Your Action!");
        yield return null;
        PlayerMovement();
    }
    // Update is called once per frame
    IEnumerator PlayerMovement()
    {
        if (unitMovement.hasMoved)
        {
            yield return new WaitForSeconds(2f);
            gameState = GameState.ENEMYTURN;
        }
        unitMovement.hasMoved = false;
    }
}
