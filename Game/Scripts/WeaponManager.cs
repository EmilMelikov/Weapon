using UnityEngine;
using TMPro;
public enum WeaponType { Bouncing, Physics }
public class WeaponManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttonText;
    private WeaponType _currentWeapon = WeaponType.Bouncing;

    public void SwitchWeapon()
    {
        _currentWeapon = _currentWeapon == WeaponType.Bouncing ? WeaponType.Physics : WeaponType.Bouncing;
        buttonText.text = _currentWeapon == WeaponType.Bouncing ? "������� ���� ��� ������" : "������� ���� � �������";
    }

    public WeaponType GetCurrentWeapon() => _currentWeapon;
}