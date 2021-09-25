using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender defender;
    private GameObject defenderparent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderparent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderparent)
        {
            defenderparent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender selectedDefender)
    {
        defender = selectedDefender;
    }

    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        StarDisplay starDisplay = FindObjectOfType<StarDisplay>();
        if (defender != null)
        {
            int defenderCost = defender.GetStarCost();
            if (starDisplay.HaveEnoughStars(defenderCost))
            {
                SpawnDefender(gridPos);
                starDisplay.SpendingStars(defenderCost);
            }
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 roundedPos)
    {
        roundedPos.y = roundedPos.y + 0.05f;
        if (defender != null)
        {
            Defender newDefender = Instantiate(defender, roundedPos, transform.rotation);
            newDefender.transform.parent = defenderparent.transform;
        }
    }
}
