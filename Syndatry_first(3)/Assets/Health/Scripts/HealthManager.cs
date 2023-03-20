using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int _maxHealth;//������������ ��
    [SerializeField] private int _currentHealth;//������� ��
    [SerializeField] private int _maxShield;//������������ ��
    [SerializeField] private int _currentShield;//������� ��
    [SerializeField] private HealthBarHandler _healthBarHandler;//������ � �������� �� ����

    public int CurrentHealth
    {
        get { return _currentHealth; }
    }

    private void Awake()
    {
        //��������, ��� ����. �� ������ 0, ����� ������
        if (_maxHealth <= 0)
        {
            Debug.LogError("����. �� = 0");
            Debug.Break();
        }

        HandleCurrentOverMax();
    }

    private void Start()
    {
        //��������� ������ ��� ������� ����
        _healthBarHandler.UpdateHealthBarStatus(_currentHealth, _maxHealth);
        _healthBarHandler.UpdateShieldBarStatus(_currentShield, _maxShield);
    }


    void Update()
    {
        HandleCurrentOverMax();
        HandleDeath();
    }

    //����� ��������� ����� � ���������� �� ����
    public void TakeDamage(int damage)
    {

        if(_currentShield > 0)
        {
            if (damage >= _currentShield)
            {
                int damageToHealth = damage - _currentShield;
                _currentShield -= damage - damageToHealth;
                _currentHealth -= damageToHealth;
                _healthBarHandler.UpdateShieldBarStatus(_currentShield, _maxShield);
                _healthBarHandler.UpdateHealthBarStatus(_currentHealth, _maxHealth);
                return;
            }
            else
            {
                _currentShield -= damage;
                _healthBarHandler.UpdateShieldBarStatus(_currentShield, _maxShield);
                return;
            }
        }

        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Debug.Log("������!");
            _currentHealth = 0;
        }
            _healthBarHandler.UpdateHealthBarStatus(_currentHealth, _maxHealth);
    }

    //����� �������������� �������� � ���������� �� ����
    public void TakeHeal(int heal)
    {
        _currentHealth += heal;
        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
        _healthBarHandler.UpdateHealthBarStatus(_currentHealth, _maxHealth);
    }

    public void TakeShield(int shield)
    {
        _currentShield += shield;
        if (_currentShield > _maxShield)
            _currentShield = _maxShield;
        _healthBarHandler.UpdateShieldBarStatus(_currentShield, _maxShield);
    }

    //���������� ���� �� 
    public void RecountMaxHealth(int adder)
    {
        _maxHealth += adder;
        _healthBarHandler.UpdateHealthBarStatus(_currentHealth, _maxHealth);
    }

    public void HandleDeath()
    {
        if (_currentHealth <= 0)
        {
            Debug.Log("Death");
            Destroy(this);
        }    
    }

    public void HandleCurrentOverMax()
    {
        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
    }
}
