using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TutorialesEF.Ejemplos;

namespace TutorialesEF
{
    class Program
    {
       
        static void Main(string[] args)
        {
            /*Hay ejemplos usando el ModelCreating en el contexto y relaciones en las entidades*/

            //EjemplosEF.GuardarStudentDB();//Ejemplo de guardar en DB
            //EjemplosEF.SimpleQueryDB(); //Ejemplo de hacer un query en DB
            //EjemplosEF.DoubleQueryDB(); //Ejemplo de query con Include
            //EjemplosEF.QuerryUsingSql(); //Ejemplo de query usando expresion SqlRaw
            //EjemplosEF.UpdatingData(); //Ejemplo de modificando data
            //EjemplosEF.DeletingData(); //Ejemplo de borrando data
            //EjemplosEF.UpdatingOnDisconnectedScenario(); //Ejemplo de actualizando con Range y desconectado
            //EjemplosEF.DeletingOnDisconnectedScenario(); //Ejemplo de borrando con range y desconectado
            //EjemplosEF.ChangeTracker(); //ejemplo para rastrear los metodos que invoquen el Contexto
            //EjemplosEF.DetachedContext(); //Este ejemplo sirve para separar un registro de la tabla de manera desconectada
        }
        
    }
}
