using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDetection : MonoBehaviour
{
    //Der oprettes en liste til de fjender, der kommer ind i tårnets detektionsområde
    public List<GameObject> enemies;
    private TowerUpgrade tower;
    private TowerShooting towerShoot;


    // Start is called before the first frame update
    void Start()
    {
        //Der oprettes referencer til tårnets stats i "TowerUpgrade" og tårnets skydeegenskaber i "TowerShooting"
        tower = GetComponentInParent<TowerUpgrade>();
        towerShoot = GetComponentInParent<TowerShooting>();
        
        //Detektionsområdets radius sættes efter tårnets start-stats
        transform.localScale = Vector3.one * tower.range;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Gameobjekter med tagget "Enemy" bliver tilføjet til listen over fjender indenfor tårnets rækkevidde, når de rammer detektionsområdet
        if (other.gameObject.tag == "Enemy")
        {
            enemies.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Fjenden fjernes fra listen når den flytter sig uden for detektionsområdet
        if (collision.gameObject.tag == "Enemy")
        {
            enemies.Remove(collision.gameObject);
        }

        //Hvis fjenden, der forlader området også er tårnets target, bliver denne reference fjernet
        if (towerShoot.target == collision.gameObject.transform)
        {
            towerShoot.target = null;
        }
    }

    //Denne funktion kaldes når tårnets rækkevidde bliver opgraderet
    public void RangeUpdate()
    {
        transform.localScale = Vector3.one * tower.range;
    }
}
