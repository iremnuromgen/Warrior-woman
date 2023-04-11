using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    internal Rigidbody2D rigid;
    internal Animator anim;

    [SerializeField]
    internal float speed;

    internal bool facingRight;
}
