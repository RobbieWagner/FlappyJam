using UnityEngine;

namespace RobbieWagnerGames.CrappyBird
{
    public class ResetObject : MonoBehaviour
    {
        private Vector2 initialPosition;
        private void Awake()
        {
            initialPosition = transform.position;
            GameManager.Instance.OnStartPlaying += ResetObjectPosition;
        }

        private void ResetObjectPosition()
        {
            transform.position = initialPosition;
            transform.rotation = Quaternion.identity;
        }
    }
}