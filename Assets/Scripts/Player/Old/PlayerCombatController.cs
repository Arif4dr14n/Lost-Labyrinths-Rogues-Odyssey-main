using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatController : MonoBehaviour
{
    //[SerializeField]
    //private bool combatenabled;
    //[SerializeField]
    //private float inputtimer, attack1radius, attack1damage;
    //[SerializeField]
    //private float stundamageamount = 1f;
    //[SerializeField]
    //private Transform attack1hitboxpos;
    //[SerializeField]
    //private LayerMask whatisdamageable;

    //private bool gotinput, isattacking, isfirstattack;

    //private float lastinputtime = Mathf.NegativeInfinity;

    //private attackDetails attackdetails;

    //private Animator anim;

    //private PlayerController pc;
    //private PlayerStats ps;

    //private void start()
    //{
    //    anim = GetComponent<Animator>();
    //    anim.SetBool("canattack", combatenabled);
    //    pc = GetComponent<PlayerController>();
    //    ps = GetComponent<PlayerStats>();
    //}

    //private void update()
    //{
    //    checkcombatinput();
    //    checkattacks();
    //}

    //private void checkcombatinput()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        if (combatenabled)
    //        {
    //            //attempt combat
    //            gotinput = true;
    //            lastinputtime = Time.time;
    //        }
    //    }
    //}

    //private void checkattacks()
    //{
    //    if (gotinput)
    //    {
    //        //perform attack1
    //        if (!isattacking)
    //        {
    //            gotinput = false;
    //            isattacking = true;
    //            isfirstattack = !isfirstattack;
    //            anim.SetBool("attack1", true);
    //            anim.SetBool("firstattack", isfirstattack);
    //            anim.SetBool("isattacking", isattacking);
    //        }
    //    }

    //    if (Time.time >= lastinputtime + inputtimer)
    //    {
    //        //wait for new input
    //        gotinput = false;
    //    }
    //}

    //private void checkattackhitbox()
    //{
    //    Collider2D[] detectedobjects = Physics2D.OverlapCircleAll(attack1hitboxpos.position, attack1radius, whatisdamageable);

    //    attackdetails.damageAmount = attack1damage;
    //    attackdetails.position = transform.position;
    //    attackdetails.stundamageamount = stundamageamount;

    //    foreach (Collider2D collider in detectedobjects)
    //    {
    //        collider.transform.parent.SendMessage("damage", attackdetails);
    //        //instantiate hit particle
    //    }
    //}

    //private void finishattack1()
    //{
    //    isattacking = false;
    //    anim.SetBool("isattacking", isattacking);
    //    anim.SetBool("attack1", false);
    //}

    //private void damage(WeaponAttackDetails attackdetails)
    //{
    //    if (!pc.GetDashStatus())
    //    {
    //        int direction;

    //        ps.DecreaseHealth(attackdetails.damageAmount);

    //        if (attackdetails.position.x < transform.position.x)
    //        {
    //            direction = 1;
    //        }
    //        else
    //        {
    //            direction = -1;
    //        }

    //        pc.Knockback(direction);
    //    }
    //}

    //private void ondrawgizmos()
    //{
    //    Gizmos.DrawWireSphere(attack1hitboxpos.position, attack1radius);
    //}

}
