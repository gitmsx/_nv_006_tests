using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSokoban001 : MonoBehaviour
{

    private float speed = _global.Global_Speed;
    private LayerMask _blockMask = 0;
    private float Global_Scale = _global.Global_Scale;
    private float _detectionRadius = _global.Global_Scale;

    [SerializeField] private Vector3 _destination;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, _destination) < Mathf.Epsilon)
        {
            ;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _destination, speed * Time.deltaTime);
        }

        transform.position = Vector3.MoveTowards(transform.position, _destination, speed * Time.deltaTime);

        #region Check Directions 

        _destination = transform.position + Vector3.right * Global_Scale;

        //if (Input.GetAxisRaw("Horizontal") > 0)
        //{
        //    if (CheckDirection(Vector3.right))
        //    {
        //        _destination = transform.position + Vector3.right * Global_Scale;
        //    }
        //    else if (Input.GetAxisRaw("Horizontal") < 0)
        //    {
        //        _destination = transform.position - Vector3.right * Global_Scale;
        //    }
        //    else if (Input.GetAxisRaw("Vertical") > 0)
        //    {
        //        _destination = transform.position + Vector3.forward * Global_Scale;
        //    }
        //    else if (Input.GetAxisRaw("Vertical") < 0)
        //    {
        //        _destination = transform.position - Vector3.forward * Global_Scale;
        //    }



        //}
        #endregion

        CheckDirection(_destination);



    }

    bool CheckDirection(Vector3 direction)
    {
        // If there is something blocking movement in this direction,
        // do not allow movement (return false)
        if (Physics.Raycast(transform.position, direction, out RaycastHit hit, _detectionRadius,
        _blockMask))

        {
            // If it is pushable,
            if (hit.collider.gameObject.CompareTag("_blockMask"))
            {
                // Push it if able.
                //   PushableBlock pushableBlock = hit.collider.GetComponent<PushableBlock>();
                bool pushableBlock = true;
                // if (!pushableBlock) 
                //     return false;
                //// pushableBlock.Push(direction, _speed);
                // return false;
                return true;


            }
            return true;
        }
        return true;
    }
}






