using UnityEngine;
using UnityEngine.UI;


public class Collect : MonoBehaviour
{
    public int coinAmount;
    public int coinTotal;
    public Text coint;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.CompareTag("Coin"))
            {
                Destroy(other.gameObject);
                coinTotal += coinAmount;
                coint.text = "" + coinTotal;
            }


        }
    }
}
