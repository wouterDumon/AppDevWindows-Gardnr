using Gardenr.Models;
using NMCT.DropBox.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr.DataAcces
{
    class InstellingenDA
    {
        private const string CONNECTIONSTRING = "DefaultConnection";
        public Instellingen GetInstellingenById(int id)
        {
            Instellingen GebruikerInstellingen = new Instellingen();
           /* string sql = "SELECT * FROM Instellingen";
            DbDataReader reader = Database.GetData(CONNECTIONSTRING, sql);
            while(reader.Read())
            {

            }*/
            return GebruikerInstellingen;
        }
        public void UpdateInstellingen(Instellingen settings)
        {

        }

        public void DeleteInstelling(int id)
        {

        }
    }
}
