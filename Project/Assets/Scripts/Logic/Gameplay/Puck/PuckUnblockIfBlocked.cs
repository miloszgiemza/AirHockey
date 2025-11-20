using UnityEngine;

public class PuckUnblockIfBlocked : MonoBehaviour
{
    public bool Blocked => blocked;

    private Table table;

    private float contactTimeWithStrikerConsideredBlocked = 1.7f;
    private float currentTimer = 0f;

    private bool blocked = false;

    private void Awake()
    {
        table = FindFirstObjectByType<Table>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == GameObjectsTags.Striker.ToString())
        {
            currentTimer = 0f;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == GameObjectsTags.Striker.ToString())
        {
            currentTimer += Time.deltaTime;
            if (currentTimer >= contactTimeWithStrikerConsideredBlocked)
            {
                currentTimer = 0f;
                blocked = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == GameObjectsTags.Striker.ToString())
        {
            currentTimer = 0f;
        }
    }

    public void Reset()
    {
        blocked = false;
        currentTimer = 0f;
    }
}
