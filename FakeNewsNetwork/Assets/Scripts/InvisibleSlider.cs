using UnityEngine;
using UnityEngine.Events;


public class InvisibleSlider : MonoBehaviour
{
    private ScenarioTrigger _scenarioTrigger;
    [SerializeField] public int sliderValue;
    private void Awake()
    {
        _scenarioTrigger = this.GetComponent<ScenarioTrigger>();
        SliderCalculator();
    }

    public void CheckValue(int addedValue)
    {
        sliderValue += addedValue;
        
        if (sliderValue < 0) sliderValue = 0;
        else if (sliderValue > 15) sliderValue = 15;
        
        SliderCalculator();
    }

    private void SliderCalculator()
    {
        var chosenScenario = 1;
        if (sliderValue ! >= 6 && sliderValue ! <= 10)
        {
            _scenarioTrigger.ChosenScenario(chosenScenario);
            return;
        }
        chosenScenario = sliderValue < 6 ? 0 : 2;
        _scenarioTrigger.ChosenScenario(chosenScenario);
        
    }
}
