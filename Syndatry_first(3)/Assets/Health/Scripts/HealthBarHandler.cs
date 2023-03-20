using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHandler : MonoBehaviour
{
    //����������� �� ����
    [SerializeField]
    private Image _healthBarImage;
    //����������� ���� ����
    [SerializeField]
    private Image _shieldBarImage;
    //����� ��� ����������� ���� ��
    [SerializeField] private TextMeshProUGUI _healthInfo;
    //����� ��� ����������� ���� ����
    [SerializeField] private TextMeshProUGUI _shieldInfo;

    //�������� ������ �� ����
    public void UpdateHealthBarStatus(int currentHP, int maxHP)
    {
        //����������� ����� ��������� �� � ��������� ����� �������� � ������������ �� ����
        _healthBarImage.fillAmount = (float)currentHP / maxHP;
        //������ �������� � ������
        _healthInfo.text = currentHP+"/"+maxHP;
    }

    public void UpdateShieldBarStatus(int currentShield, int maxShield)
    {
        //����������� ����� ��������� ���� � ��������� ����� �������� � ������������ ���� ����
        _shieldBarImage.fillAmount = (float)currentShield / maxShield;
        //������ �������� � ������
        _shieldInfo.text = currentShield + "/" + maxShield;
    }
}
