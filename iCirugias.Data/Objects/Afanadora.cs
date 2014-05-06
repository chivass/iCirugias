using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCirugias.Data.Conexion;

namespace iCirugias.Data.Objects
{
    public class Afanadora : Base
    {
        public Afanadora(Connection conn)
            : base(conn)
        {
        }
        public override string TableName()
        {
            return "iCirugias.dbo.Afanadora";
        }

    }
}
