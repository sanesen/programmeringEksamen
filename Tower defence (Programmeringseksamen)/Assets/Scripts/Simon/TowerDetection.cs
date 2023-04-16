using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDetection : MonoBehaviour
{
    //Der oprettes en liste til de fjender, der kommer ind i t�rnets detektionsomr�de
    public List<GameObject> enemies;
    private TowerUpgrade tower;
    private TowerShooting towerShoot;


    // Start is called before the first frame update
    void Start()
    {
        //Der oprettes referencer til t�rnets stats i "TowerUpgrade" og t�rnets skydeegenskaber i "TowerShooting"
        tower = GetComponentInParent<TowerUpgrade>();
        towerShoot = GetComponentInParent<TowerShooting>();
        
        //Detektionsomr�dets radius s�ttes efter t�rnets start-stats
        transform.localScale = Vector3.one * tower.range;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Gameobjekter med tagget "Enemy" bliver tilf�jet til listen over fjender indenfor t�rnets r�kkevidde, n�r de rammer detektionsomr�det
        if (other.gameObject.tag == "Enemy")
        {
            enemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Fjenden fjernes fra listen n�r den flytter sig uden for detektionsomr�det
        if (collision.gameObject.tag == "Enemy")
        {
            enemies.Remove(collision.gameObject);
        }

        //Hvis fjenden, der forlader omr�det ogs� er t�rnets target, bliver denne reference fjernet
        if (towerShoot.target == collision.gameObject.transform)
        {
            towerShoot.target = null;
        }
    }

    //Denne funktion kaldes n�r t�rnets r�kkevidde bliver opgraderet
    public void RangeUpdate()
    {
        transform.localScale = Vector3.one * tower.range;
    }
}
