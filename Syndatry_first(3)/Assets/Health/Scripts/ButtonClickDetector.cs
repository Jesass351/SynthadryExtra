using UnityEngine;
using UnityEngine.UI;

public class ButtonClickDetector : MonoBehaviour
{
    //скрипт для теста хп бара

    public Button button1;
    public Button button2;
    [SerializeField] private HealthManager _healthManager;

    void OnEnable()
    {
        //Register Button Events
        button1.onClick.AddListener(() => buttonCallBack(button1));
        button2.onClick.AddListener(() => buttonCallBack(button2));
    }

    private void buttonCallBack(Button buttonPressed)
    {
        if (buttonPressed == button1)
        {
            _healthManager.TakeDamage(10);
        }

        if (buttonPressed == button2)
        {
            _healthManager.TakeHeal(10);
        }
    }

    void OnDisable()
    {
        //Un-Register Button Events
        button1.onClick.RemoveAllListeners();
        button2.onClick.RemoveAllListeners();
    }
}
