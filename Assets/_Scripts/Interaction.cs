using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    public GameObject icon;
    public KeyCode interactionKey = KeyCode.E;

    public Transform _target;
    public Transform _interactionPos;
    [SerializeField]
    private float _range;
    private bool _canInteract = false;
    protected bool _isLocked = false;

    void Update()
    {
        if (_isLocked)
        {
            return;
        }

        if(Input.GetKeyDown(interactionKey) && _canInteract)
        {
            Run();
        }


        Vector2 pos = new Vector2(_interactionPos.position.x, _interactionPos.position.y);
        Vector2 targetPos = new Vector2(_target.position.x, _target.position.y);

        if (Vector2.Distance(pos, targetPos) <= _range)
        {
            icon.SetActive(true);
            _canInteract = true;
        }
        else
        {
            icon.SetActive(false);
            _canInteract = false;
        }
    }

    public virtual void Run()
    {
        Debug.Log("Running on " + transform.name);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, _range);
    //}
}
