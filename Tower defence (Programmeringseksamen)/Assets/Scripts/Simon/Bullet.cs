using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Variable, der bestemmer hvor meget projektilet skal skade fjenden
    public float damage;
    private float timer = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Destruerer projektilet, hvis det flyver i mere end 10 sekunder, for at forhindre at det flyver for evigt
        timer -= Time.deltaTime;
        if (timer<=0)
        {
            Destroy(this.gameObject);
        }
    }

    //Køres når projektilets collider, der er sat som trigger, rammer noget
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Tjekker om det ramte objekt har tagget "Enemy", hvis det ikke har det, skal der ikke ske noget
        if (collision.tag == "Enemy")
        {
            //Tager fat i det ramte objekts script og trækker værdien af "damage" fra fjendens liv
            collision.GetComponent<EnemyMovement>().lives -= damage;

            //Destruerer fjenden, hvis dens liv er mindre end eller lig med 0
            if (collision.GetComponent<EnemyMovement>().lives <= 0)
            {
                Destroy(collision.gameObject);
            }

            //Projektilet bliver selv destrueret
            Destroy(this.gameObject);
        }
    }
}
