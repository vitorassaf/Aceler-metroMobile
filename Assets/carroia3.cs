using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carroia3 : MonoBehaviour
{
    public Vector3 origem;
    public float velocidade;

    public List<GameObject> waypoints;
    public List<GameObject> waypointsPassados;
    void Start()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("wayPoints3"))
        {
            origem = transform.position;
            //Está pegando cada item e colocando na variavel waypoints.
            waypoints.Add(item);


        }
    }


    void Update()
    {
        rotaPoints();
    }

    private void rotaPoints()
    {
        //Desenho do Trajeto que o NPC vai Seguir.

        //Origem do NPC, ou seja , Posição Inicial.

        #region 
        Vector3 pontoInicial = transform.position;

        int cont = 0;

        while (cont < waypoints.Count)
        {
            //Vai traçar uma linha entre todos os Pontos.
            Debug.DrawLine(pontoInicial, waypoints[cont].transform.position, Color.green);

            pontoInicial = waypoints[cont].transform.position;
            cont++;
        }

        #endregion;

        float distancia = Vector3.Distance(transform.position, waypoints[0].transform.position);

        if (distancia > 0.5f)
        {
            Vector3 direcao = waypoints[0].transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(direcao);
            transform.Translate(0, 0, velocidade * Time.deltaTime);
        }
        else
        {
            waypointsPassados.Add(waypoints[0]);
            //Remover os Pontos da Lista, de acordo da Trajetória.
            waypoints.RemoveAt(0);

            if (waypoints.Count == 0)
            {
                //Vai Recomeçar a Trajetória.
                //waypoints = waypointsPassados;


                //A Cada Ponto que ele passar ele vai deletando um por um.
                foreach (var ponto in waypointsPassados)
                {
                    waypoints.Add(ponto);
                }

                waypointsPassados.Clear();
            }
        }
    }
}
