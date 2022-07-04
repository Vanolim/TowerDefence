using TMPro;
using UnityEngine;

public class BalanceView : MonoBehaviour, IDisposable
{
    [SerializeField] private TMP_Text _text;
    private Wallet _wallet;

    public void Init(Wallet wallet)
    {
        _wallet = wallet;
        wallet.OnChanged += SetValue;
        SetValue(_wallet.CurrentBalance);
    }

    private void SetValue(int value)
    {
        _text.text = value.ToString();
    }

    public void Dispose()
    {
        _wallet.OnChanged -= SetValue;
    }
}