using UnityEngine;

public enum BonuceType {Shield, Jetpack}
public class Bonuce : MonoBehaviour
{
    [Header("Bonuce Type")]
    [SerializeField] private BonuceType _bonuceType;

    [Header("Jetpack Effect")]
    [SerializeField] private float _jetpackForce = 2f;

    [Header("Timer")]
    [SerializeField] private float _shieldActionTime = 10f;
    [SerializeField] private float _jetpackActionTime = 0f;


    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (_bonuceType == BonuceType.Shield)
        {
            if (collider2D.gameObject.CompareTag("Player"))
            {
                PlayerStates.PlayerStatesScript.AddShieldEffect(_shieldActionTime);
                PlayerStates.PlayerStatesScript.ShieldActive = true;
                Destroy(gameObject);
            }
        }
        else if (_bonuceType == BonuceType.Jetpack)
        {
            if (collider2D.gameObject.CompareTag("Player"))
            {
                PlayerStates.PlayerStatesScript.AddJetpackEffect(_jetpackActionTime, _jetpackForce);
                PlayerStates.PlayerStatesScript.JetpackActive = true;
                Destroy(gameObject);
            }
        }
    }

    //private void OnTriggerExit2D(Collider2D collider2D)
    //{
    //    if (collider2D.gameObject.CompareTag("Dead Zone"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
