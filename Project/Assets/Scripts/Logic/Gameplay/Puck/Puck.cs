using UnityEngine;

using Players;
using GameSettingsAndSaveSystem;

public class Puck : MonoBehaviour
{

    public Vector3 CurrentVelocity => currentVelocity;

    public float MaxMaxVelocity => maxMaxVelocity;
    public float CurrentMaxVelocity => currentMaxVelocity;
    public float MinMaxVelocity => minMaxVelocity;
    public float DefaultMaxVelocity => defaultMaxVelocity;

    [SerializeField] private Rigidbody rigidbody;

    private float velocityOnWhichAddMore = 0.2f;
    private float maxAddedVelocity = 3f;

    private float maxMaxVelocity = 30f;
    private float currentMaxVelocity = 12.8f;
    private float minMaxVelocity = 9f;
    private float defaultMaxVelocity = 12.8f;

    private Vector3 currentVelocity = new Vector3();

    private void OnEnable()
    {
        rigidbody.maxLinearVelocity = currentMaxVelocity;
    }

    private void Start()
    {
        currentMaxVelocity = GameSettings.Instance.TryLoadSetting(GameSettings.SettingsOptions.PuckMaxSpeed, defaultMaxVelocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == GameObjectsTags.Striker.ToString())
        {
            AddReverseVelocityOnCollisionWithPlayerToAvoidGlitching(collision);
        }
    }

    public void RunPuck()
    {
        AddVelocityIfBlocked();
        currentVelocity = rigidbody.linearVelocity;
    }

    private void AddVelocityIfBlocked()
    {
        if(Mathf.Abs(rigidbody.linearVelocity.x) < velocityOnWhichAddMore && Mathf.Abs(rigidbody.linearVelocity.y) < velocityOnWhichAddMore)
        {
            rigidbody.AddForce( new Vector3(Random.Range(-maxAddedVelocity, maxAddedVelocity), 0f, Random.Range(-maxAddedVelocity, maxAddedVelocity)) );
        }
    }

    private void AddReverseVelocityOnCollisionWithPlayerToAvoidGlitching(Collision collision)
    {
        float reverseForce = 25;

        if(collision.gameObject.tag == GameObjectsTags.Striker.ToString())
        {
            rigidbody.AddForce( (-collision.gameObject.transform.position - transform.position).normalized * reverseForce);
        }
    }

    public void SetPuckPosition(Vector3 position)
    {
        transform.position = position;
    }
}
