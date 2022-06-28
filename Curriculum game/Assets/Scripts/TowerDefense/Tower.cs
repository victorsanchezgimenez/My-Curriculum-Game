using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
   [SerializeField] int cost = 75;
   [SerializeField] Vector3 correctPosition;

   public bool CreateTower(Tower tower, Vector3 position)
   {
        
        Bank bank = FindObjectOfType<Bank>();
        if(bank == null)
        {
            return false;
        }
        
        if(bank.CurrentBalance >= cost)
        {
            Instantiate(tower.gameObject, position + correctPosition, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }

        return false;
   }
}
