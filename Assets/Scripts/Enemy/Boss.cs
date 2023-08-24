using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class Boss : MonoBehaviour
{
    [SerializeField] private Teleport _teleport;
    
    private GameObject _teleportPosition;

    private Enemy _boss;
    private bool _isBossDyi = false;

    private void Start()
    {
        _boss = GetComponent<Enemy>();
        
    }

    private void Update()
    {
        if(_boss.Health <= 0)
        {
            if(_isBossDyi == false)
            {
                OpenTeleport();
            }
        }
    }

    private void OpenTeleport()
    {
        Instantiate(_teleport, new Vector3(_teleportPosition.transform.position.x, _teleportPosition.transform.position.y, _teleportPosition.transform.position.z), transform.rotation);
        _isBossDyi = true;
    }

    public void GetTeleportPosition(GameObject teleportPosition)
    {
        _teleportPosition = teleportPosition;
    }
}
