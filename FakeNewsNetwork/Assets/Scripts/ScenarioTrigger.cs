using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class ScenarioTrigger : MonoBehaviour
{
    [SerializeField] private List<GameObject> scenarios = new List<GameObject>();

    public void ChosenScenario(int chosenScenario)
    {
        for (int i = 0; i < scenarios.Count; i++)
        {
            scenarios[i].SetActive(false);
        }
        scenarios[chosenScenario].SetActive(true);
    }
}
