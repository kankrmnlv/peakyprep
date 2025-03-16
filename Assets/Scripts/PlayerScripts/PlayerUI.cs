using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text ammoText;

    InputReader inputReader;
    PlayerShoot player;
    private void OnEnable()
    {
        inputReader.OnShootInput += SetUIText;
    }
    private void OnDisable()
    {
        inputReader.OnShootInput -= SetUIText;
    }
    private void Awake()
    {
        player = GetComponent<PlayerShoot>();
        inputReader = GetComponent<InputReader>();
    }

    private void SetUIText()
    {
        scoreText.text = player.kills.ToString();
        ammoText.text = player.currentAmmo.ToString() + " / " + player.maxAmmo.ToString();
    }
}
