using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCirugias.Data.Conexion;

namespace iCirugias.Data.Objects
{
   public class Medico: Base
    {
       public Medico(Connection conn)
           : base(conn)
       {
       }

       public override string TableName()
       {
           return "iCirugias.dbo.Medico";
       }
    }
}
