using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using WINAPI.Models;

namespace WINAPI.helper
{
    public class DA
    {

        public static List<Plant> getPlant()
        {
            List<Plant> list = new List<Plant>();
            string sql = "SELECT ID, Naam, Omschrijving, Foto, ZaaiBegin, ZaaiEinde, PlantBegin, PlantEinde, OogstBegin, OogstEinde, ZaaiDiepte, AfstandTussen, AfstandRij, WaterGeven, DagenOogst, DagenVerplanten, Buiten, Binnen FROM Catalogus";
            DbDataReader reader = Database.GetData("DC", sql);


            while (reader.Read())
            {
                Plant o = new Plant()
                {
                    ID = Int32.Parse(reader["Id"].ToString()),
                    Naam = reader["Naam"].ToString(),
                    Omschrijving = reader["Omschrijving"].ToString(),
                    FotoUrl = reader["Foto"].ToString(),
                    ZaaiBegin = reader["ZaaiBegin"].ToString(),
                    ZaaiEinde = reader["ZaaiEinde"].ToString(),
                    PlantBegin = reader["PlantBegin"].ToString(),
                    PlantEinde = reader["PlantEinde"].ToString(),
                    OogstBegin = reader["OogstBegin"].ToString(),
                    OogstEinde = reader["OogstEinde"].ToString(),
                    ZaaiDiepte = reader["ZaaiDiepte"].ToString(),
                    AfstandTussen = reader["AfstandTussen"].ToString(),
                    AfstandRij = reader["AfstandRij"].ToString(),
                    WaterGeven = reader["WaterGeven"].ToString(),
                    DagenOogst = reader["DagenOogst"].ToString(),
                    DagenVerplanten = reader["DagenVerplanten"].ToString(),
                    Buiten = Int32.Parse(reader["Buiten"].ToString()),
                    Binnen = Int32.Parse(reader["Binnen"].ToString())


                };
                list.Add(o);
            }
            reader.Close();
            return list;
        }
        public static List<Taal> getTaal()
        {
            List<Taal> list = new List<Taal>();
            string sql = "SELECT ID, Naam FROM Taal";
            DbDataReader reader = Database.GetData("DC", sql);


            while (reader.Read())
            {
                Taal o = new Taal()
                {
                    ID = Int32.Parse(reader["Id"].ToString()),
                    taal = reader["Naam"].ToString(),
                   

                };
                list.Add(o);
            }
            reader.Close();
            return list;
        }

        public static int newplant(Plant org)
        {
            int rowsaffected = 0;
            try
            {

                string sql = "INSERT INTO Catalogus(Naam, Omschrijving, Foto, ZaaiBegin, ZaaiEinde, PlantBegin, PlantEinde, OogstBegin, OogstEinde, ZaaiDiepte, AfstandTussen, AfstandRij, WaterGeven, DagenOogst, DagenVerplanten, Buiten, Binnen) VALUES(@Naam, @Omschrijving, @Foto, @ZaaiB, @ZaaiE, @PlantB, @PlantE, @OogstB, @OogstE, @ZaaiD, @Afstandtssn, @AfstandRij, @Watergeven, @DagenOogst, @DagenVerplanten, @Buiten, @Binnen)";
                //@Naam, @Omschrijving, @Foto, @ZaaiB, @ZaaiE, @PlantB, @PlantE, @OogstB, @OogstE, @ZaaiD,                                                                                               @Afstandtssn, @AfstandRij, @Watergeven, @DagenOogst, @DagenVerplanten, @Buiten, @Binnen
                DbParameter par1 = Database.AddParameter("DC", "@Naam", org.Naam);
                DbParameter par2 = Database.AddParameter("DC", "@Omschrijving", org.Omschrijving);
                DbParameter par3 = Database.AddParameter("DC", "@Foto", org.FotoUrl);
                DbParameter par4 = Database.AddParameter("DC", "@ZaaiB", org.ZaaiBegin);
                DbParameter par5 = Database.AddParameter("DC", "@ZaaiE", org.ZaaiEinde);
                DbParameter par6 = Database.AddParameter("DC", "@PlantB", org.PlantBegin);
                DbParameter par7 = Database.AddParameter("DC", "@PlantE", org.PlantEinde);
                DbParameter par8 = Database.AddParameter("DC", "@OogstB", org.OogstBegin);
                DbParameter par9 = Database.AddParameter("DC", "@OogstE", org.OogstEinde);
                DbParameter par10 = Database.AddParameter("DC", "@ZaaiD", org.ZaaiDiepte);
                DbParameter par11 = Database.AddParameter("DC", "@Afstandtssn", org.AfstandTussen);
                DbParameter par12 = Database.AddParameter("DC", "@AfstandRij", org.AfstandRij);
                DbParameter par13 = Database.AddParameter("DC", "@Watergeven", org.WaterGeven);
                DbParameter par14 = Database.AddParameter("DC", "@DagenOogst", org.DagenOogst);
                DbParameter par15 = Database.AddParameter("DC", "@DagenVerplanten", org.DagenVerplanten);
                DbParameter par16 = Database.AddParameter("DC", "@Buiten", org.Buiten);
                DbParameter par17 = Database.AddParameter("DC", "@Binnen", org.Binnen);

                rowsaffected += Database.InsertData("DC", sql, par1, par2, par3, par4, par5, par6, par7, par8, par9, par10, par11, par12, par13, par14, par15, par16, par17);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return rowsaffected;
        }
        public static int Updateplant(int si, Plant org)
        {
            int rowsaffected = 0;
            try
            {
                string sql = "UPDATE Catalogus SET Naam=@Naam, Omschrijving=@Omschrijving, Foto=@Foto, ZaaiBegin=@ZaaiB, ZaaiEinde=@ZaaiE, PlantBegin=@PlantB, PlantEinde=@PlantE, OogstBegin=@OogstB, OogstEinde=@OogstE, ZaaiDiepte=@ZaaiD, AfstandTussen=@Afstandtssn, AfstandRij=@AfstandRij, WaterGeven=@Watergeven, DagenOogst=@DagenOogst, DagenVerplanten=@DagenVerplanten, Buiten=@Buiten, Binnen=@Binnen WHERE ID=@ID";
                DbParameter par1 = Database.AddParameter("DC", "@Naam", org.Naam);
                DbParameter par2 = Database.AddParameter("DC", "@Omschrijving", org.Omschrijving);
                DbParameter par3 = Database.AddParameter("DC", "@Foto", org.FotoUrl);
                DbParameter par4 = Database.AddParameter("DC", "@ZaaiB", org.ZaaiBegin);
                DbParameter par5 = Database.AddParameter("DC", "@ZaaiE", org.ZaaiEinde);
                DbParameter par6 = Database.AddParameter("DC", "@PlantB", org.PlantBegin);
                DbParameter par7 = Database.AddParameter("DC", "@PlantE", org.PlantEinde);
                DbParameter par8 = Database.AddParameter("DC", "@OogstB", org.OogstBegin);
                DbParameter par9 = Database.AddParameter("DC", "@OogstE", org.OogstEinde);
                DbParameter par10 = Database.AddParameter("DC", "@ZaaiD", org.ZaaiDiepte);
                DbParameter par11 = Database.AddParameter("DC", "@Afstandtssn", org.AfstandTussen);
                DbParameter par12 = Database.AddParameter("DC", "@AfstandRij", org.AfstandRij);
                DbParameter par13 = Database.AddParameter("DC", "@Watergeven", org.WaterGeven);
                DbParameter par14 = Database.AddParameter("DC", "@DagenOogst", org.DagenOogst);
                DbParameter par15 = Database.AddParameter("DC", "@DagenVerplanten", org.DagenVerplanten);
                DbParameter par16 = Database.AddParameter("DC", "@Buiten", org.Buiten);
                DbParameter par17 = Database.AddParameter("DC", "@Binnen", org.Binnen);

                rowsaffected += Database.InsertData("DC", sql, par1, par2, par3, par4, par5, par6, par7, par8, par9, par10, par11, par12, par13, par14, par15, par16, par17);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return rowsaffected;
        }
        public static Instellingen GetInstellingen(int id) {
           
            string sql = "SELECT  ID, TaalID, Cortana, Push FROM Instellingen where ID=@1";
            DbParameter par1 = Database.AddParameter("DC", "@1", id);
            DbDataReader reader = Database.GetData("DC", sql, par1);

            reader.Read();
            Instellingen a = new Instellingen() {
                ID = Int32.Parse(reader["ID"].ToString()),

                Taal = GetTaal(Int32.Parse(reader["TaalID"].ToString())),
                Cortana = (reader["Cortana"].ToString()),
                PushNotificaties = (reader["Push"].ToString())
            };
            reader.Close();
            return a;
        }
        public static int UpdateInstellingen(Instellingen org)
        {
            int rowsaffected = 0;
            try
            {
                string sql = "UPDATE Instellingen SET TaalID=@1, Cortana=@2, Push=@3 WHERE ID=@ID";
                DbParameter par1 = Database.AddParameter("DC", "@1", org.Taal.ID);
                DbParameter par2 = Database.AddParameter("DC", "@2", org.Cortana);
                DbParameter par3 = Database.AddParameter("DC", "@3", org.PushNotificaties);
                DbParameter par4 = Database.AddParameter("DC", "@ID", org.ID);


                rowsaffected += Database.InsertData("DC", sql, par1, par2, par3, par4);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return rowsaffected;
        }

        public static int newInstellingen(Instellingen org)
        {
            int rowsaffected = 0;
            try
            {

                string sql = "INSERT INTO Instellingen(TaalID, Cortana, Push) VALUES(@1,@2,@3)";
                //@Naam, @Omschrijving, @Foto, @ZaaiB, @ZaaiE, @PlantB, @PlantE, @OogstB, @OogstE, @ZaaiD,                                                                                               @Afstandtssn, @AfstandRij, @Watergeven, @DagenOogst, @DagenVerplanten, @Buiten, @Binnen
                DbParameter par1 = Database.AddParameter("DC", "@1", org.Taal.ID);
                DbParameter par2 = Database.AddParameter("DC", "@2", org.Cortana);
                DbParameter par3 = Database.AddParameter("DC", "@3", org.PushNotificaties);

              
                rowsaffected += Database.InsertData("DC", sql, par1, par2, par3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return rowsaffected;
        }
        public static Taal GetTaal(int id)
        {
            
            string sql = "SELECT  ID, Naam FROM Taal where ID = @1";
            DbParameter par1 = Database.AddParameter("DC", "@1", id);
            DbDataReader reader = Database.GetData("DC", sql, par1);

            reader.Read();
            Taal a = new Taal()
            {
                ID = Int32.Parse(reader["ID"].ToString()),
taal = reader["Naam"].ToString()


            };
            reader.Close();
            return a;
        }
        public static int UpdateGebruiker(Gebruiker org)
        {
            int rowsaffected = 0;
            try
            {
                string sql = "UPDATE Gebruiker SET Naam=@1, Voornaam=@2, InstellingenID=@3, Facebook=@4, Active=@5 WHERE ID=@ID";
                DbParameter par1 = Database.AddParameter("DC", "@1", org.Naam);
                DbParameter par2 = Database.AddParameter("DC", "@2", org.Voornaam);
                DbParameter par3 = Database.AddParameter("DC", "@3", check(org.InstellingenID));
                DbParameter par5 = Database.AddParameter("DC", "@4", org.Facebook);

                DbParameter par6 = Database.AddParameter("DC", "@5", org.Active);

                DbParameter par4 = Database.AddParameter("DC", "@ID", org.ID);


                rowsaffected += Database.InsertData("DC", sql, par1, par2, par3, par4);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return rowsaffected;
        }
        private static int  check(Instellingen i) {
            Instellingen a = GetInstellingen(i.ID);
            if (a == i) { return i.ID; } else {
                UpdateInstellingen(i);
                return i.ID;
            }




        }
        public static Gebruiker GetGebruiker(string email)
        {
            List<Gebruiker> list = new List<Gebruiker>();
            string sql = "SELECT ID,Naam,Voornaam,InstellingenID, Facebook, Active FROM Gebruiker Where Facebook=@FB";

            DbParameter par1 = Database.AddParameter("DC", "@FB", email);
            DbDataReader reader = Database.GetData("DC", sql, par1);

            reader.Read();
            Gebruiker o = new Gebruiker()
            {
                ID = Int32.Parse(reader["ID"].ToString()),
                Naam = reader["Naam"].ToString(),
                Voornaam = reader["Voornaam"].ToString(),
                InstellingenID = GetInstellingen(Int32.Parse(reader["InstellingenID"].ToString())),
                Facebook = reader["Facebook"].ToString(),
                Active = reader["Active"].ToString()

                                          };


            reader.Close();
            return o;
        }

        public static int newgebruiker(Gebruiker org)
        {
            int rowsaffected = 0;
            try
            {
                newInstellingen(org.InstellingenID);
                string sql = "INSERT INTO Gebruiker(Naam,Voornaam, InstellingenID, Facebook, Active) VALUES(@N, @VN, @IID, @FB, @Active)";
                DbParameter par1 = Database.AddParameter("DC", "@N", org.Naam);
                DbParameter par2 = Database.AddParameter("DC", "@VN", org.Voornaam);
                DbParameter par3 = Database.AddParameter("DC", "@IID", getlastinsertedrowof());
                DbParameter par4 = Database.AddParameter("DC", "@FB", org.Facebook);
                DbParameter par5 = Database.AddParameter("DC", "@Active", org.Active);

                rowsaffected += Database.InsertData("DC", sql, par1, par2, par3, par4, par5);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return rowsaffected;
        }
        public static List<Notificatie> GetNotificatieperGebruiker(int gebruikerID)
        {
            List<Notificatie> list = new List<Notificatie>();
            string sql = "SELECT Notificaties.ID, t.Naam, Notificaties.Omschrijving, Notificaties.Datum, Notificaties.Uur, Alarm.Activate, Alarm.X_OP_VOORHAND, Alarm.Snooze, Notificaties.NotificatieID  FROM Notificaties JOIN[Type] t ON Notificaties.TypeID = t.ID JOIN Alarm ON Alarm.ID = Notificaties.AlarmID WHERE Notificaties.GebruikerID = @gid";
            DbParameter par6 = Database.AddParameter("DC", "@gid", gebruikerID);
            DbDataReader reader = Database.GetData("DC", sql, par6);


            while (reader.Read())
            {
                int id = 0;
                if (reader["NotificatieID"].ToString() == null)
                {
                    id = Int32.Parse(reader["NotificatieID"].ToString());
                }
                Notificatie o = new Notificatie()
                {
                    ID = Int32.Parse(reader["Id"].ToString()),
                    Type = Int32.Parse(reader["Naam"].ToString()),
                    Omschrijving = reader["Omschrijving"].ToString(),
                    Datum = reader["Datum"].ToString(),
                    uur = reader["Uur"].ToString(),
                    activate = reader["Activate"].ToString(),
                    X_op_voorhand = Int32.Parse(reader["X_OP_VOORHAND"].ToString()),
                    Snooze = Int32.Parse(reader["Snooze"].ToString()),
                    GebruikerID = gebruikerID,
                    NotificatieID = id

                };
                list.Add(o);
            }
            reader.Close();
            return list;
        }

        public static List<Notificatie> GetNotificatieperPlant(int PlantID)
        {
            List<Notificatie> list = new List<Notificatie>();
            string sql = "SELECT Notificaties.ID, t.Naam, Notificaties.Omschrijving, Notificaties.Datum, Notificaties.Uur, Alarm.Activate, Alarm.X_OP_VOORHAND, Alarm.Snooze, Notificaties.GebruikerID  FROM Notificaties JOIN[Type] t ON Notificaties.TypeID = t.ID JOIN Alarm ON Alarm.ID = Notificaties.AlarmID WHERE Notificaties.NotificatieID = @gid";
            DbParameter par6 = Database.AddParameter("DC", "@gid", PlantID);
            DbDataReader reader = Database.GetData("DC", sql, par6);


            while (reader.Read())
            {
                Notificatie o = new Notificatie()
                {
                    ID = Int32.Parse(reader["Id"].ToString()),
                    Type = Int32.Parse(reader["Naam"].ToString()),
                    Omschrijving = reader["Omschrijving"].ToString(),
                    Datum = reader["Datum"].ToString(),
                    uur = reader["Uur"].ToString(),
                    activate = reader["Activate"].ToString(),
                    X_op_voorhand = Int32.Parse(reader["X_OP_VOORHAND"].ToString()),
                    Snooze = Int32.Parse(reader["Snooze"].ToString()),
                    GebruikerID = Int32.Parse(reader["GebruikerID"].ToString()),
                    NotificatieID = PlantID

                };
                list.Add(o);
            }
            reader.Close();
            return list;
        }


        private static int ins(Notificatie a)
        {
            // Insert INTO Alarm(Activate, X_OP_VOORHAND, Snooze) VALUES('True', '20', '1')
            int rowsaffected = 0;
            try
            {
                string sql = "INSERT INTO Alarm(Activate, X_OP_VOORHAND, Snooze) VALUES(@A, @X, @S)";
                DbParameter par1 = Database.AddParameter("DC", "@A", a.activate);
                DbParameter par2 = Database.AddParameter("DC", "@X", a.X_op_voorhand);
                DbParameter par3 = Database.AddParameter("DC", "@S", a.Snooze);


                rowsaffected += Database.InsertData("DC", sql, par1, par2, par3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return getlastinsertedrow();

        }

        private static int getlastinsertedrowof()
        {
          string sql = "SELECT @@IDENTITY as 't' from Instellingen";


            DbDataReader reader = Database.GetData("DC", sql);

            reader.Read();
            string a = reader["t"].ToString();
            reader.Close();
            return Int32.Parse(a);
        }


        private static int getlastinsertedrow()
        {
            List<Gebruiker> list = new List<Gebruiker>();
            string sql = "SELECT @@IDENTITY as 't' from Alarm";


            DbDataReader reader = Database.GetData("DC", sql);

            reader.Read();
            string a = reader["t"].ToString();
            reader.Close();
            return Int32.Parse(a);
        }

        public static int AddNotificatie(Notificatie Not)
        {
            int alarmid = ins(Not);
            // int type = selecteerid(Not);


            int rowsaffected = 0;
            try
            {
                string sql = "INSERT INTO Notificaties(TypeID, Omschrijving, Datum, Uur, AlarmID, GebruikerID, NotificatieID) VALUES(@1 , @2, @3, @4, @5, @6, @7)";
                DbParameter par1 = Database.AddParameter("DC", "@1", Not.Type);
                DbParameter par2 = Database.AddParameter("DC", "@2", Not.Omschrijving);
                DbParameter par3 = Database.AddParameter("DC", "@3", Not.Datum);
                DbParameter par4 = Database.AddParameter("DC", "@4", Not.uur);
                DbParameter par5 = Database.AddParameter("DC", "@5", alarmid);
                DbParameter par6 = Database.AddParameter("DC", "@6", Not.GebruikerID);
                DbParameter par7 = Database.AddParameter("DC", "@7", Not.NotificatieID);
                rowsaffected += Database.InsertData("DC", sql, par1, par2, par3, par4, par5, par6, par7);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return rowsaffected;


        }

        public static int Updatenotificatie(int si, Notificatie Not)
        {
            int rowsaffected = 0;
            try
            {
                int a = Checkalarm(si, Not);
                string sql = "UPDATE Notificatie SET TypeID=@1, Omschrijving=@2, Datum=@3, uur=@4, AlarmID=@5, GebruikerID=@6, NotificatieID=@7 WHERE ID=@ID";
                DbParameter par1 = Database.AddParameter("DC", "@1", Not.Type);
                DbParameter par2 = Database.AddParameter("DC", "@2", Not.Omschrijving);
                DbParameter par3 = Database.AddParameter("DC", "@3", Not.Datum);
                DbParameter par4 = Database.AddParameter("DC", "@4", Not.uur);
                DbParameter par5 = Database.AddParameter("DC", "@5", a);
                DbParameter par6 = Database.AddParameter("DC", "@6", Not.GebruikerID);
                DbParameter par7 = Database.AddParameter("DC", "@7", Not.NotificatieID);
                DbParameter par8 = Database.AddParameter("DC", "@ID", si);
                rowsaffected += Database.InsertData("DC", sql, par1, par2, par3, par4, par5, par6, par7, par8);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return rowsaffected;
        }

        private static int Checkalarm(int a, Notificatie Not)
        {

            //Code hier dat kijkt of alarm gewijzigd is
            Notificatie oud = GetNotificatieperID(a);
            if (oud.Snooze == Not.Snooze && oud.activate == Not.activate && oud.X_op_voorhand == Not.X_op_voorhand)
            {
                //ALARM ID OPHALEN
                Alarm b = GetAlarmID(Not);
                return b.ID;
            }
            else
            {
                // ALARM  AANGEPAST AANPASSEN 
                Alarm b = GetAlarmID(Not);
                int PasAlar = PasAlarmaan(b);
                return PasAlar;
            }

        }

        private static int PasAlarmaan(Alarm b)
        {
            int rowsaffected = 0;
            try
            {
                string sql = "UPDATE Alarm SET Activate=@A, X_OP_VOORHAND=@X, Snooze=@S Where ID = @id";
                DbParameter par1 = Database.AddParameter("DC", "@A", b.activate);
                DbParameter par2 = Database.AddParameter("DC", "@X", b.X_OP_VOORHAND);
                DbParameter par3 = Database.AddParameter("DC", "@S", b.Snooze);
                DbParameter par4 = Database.AddParameter("DC", "@id", b.ID);

                rowsaffected += Database.InsertData("DC", sql, par1, par2, par3, par4);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return b.ID;

        }

        public static Notificatie GetNotificatieperID(int PlantID)
        {
            List<Notificatie> list = new List<Notificatie>();
            string sql = "SELECT Notificaties.ID, t.Naam, Notificaties.Omschrijving, Notificaties.Datum, Notificaties.Uur, Alarm.Activate, Alarm.X_OP_VOORHAND, Alarm.Snooze  FROM Notificaties JOIN[Type] t ON Notificaties.TypeID = t.ID JOIN Alarm ON Alarm.ID = Notificaties.AlarmID WHERE Notificaties.ID = @gid";
            DbParameter par6 = Database.AddParameter("DC", "@gid", PlantID);
            DbDataReader reader = Database.GetData("DC", sql, par6);

            reader.Read();
            Notificatie o = new Notificatie()
            {
                ID = Int32.Parse(reader["Id"].ToString()),
                Type = Int32.Parse(reader["Naam"].ToString()),
                Omschrijving = reader["Omschrijving"].ToString(),
                Datum = reader["Datum"].ToString(),
                uur = reader["Uur"].ToString(),
                activate = reader["Activate"].ToString(),
                X_op_voorhand = Int32.Parse(reader["X_OP_VOORHAND"].ToString()),
                Snooze = Int32.Parse(reader["Snooze"].ToString())

            };

            reader.Close();
            return o;
        }

        public static Alarm GetAlarmID(Notificatie NOT)
        {
            List<Alarm> list = new List<Alarm>();
            string sql = "SELECT ID, Activate, X_OP_VOORHAND, Snooze From Alarm Where Activate = @1 & X_OP_VOORHAND = @2 & Snooze = @3";
            DbParameter par6 = Database.AddParameter("DC", "@1", NOT.activate);
            DbParameter par7 = Database.AddParameter("DC", "@2", NOT.X_op_voorhand);
            DbParameter par8 = Database.AddParameter("DC", "@3", NOT.Snooze);
            DbDataReader reader = Database.GetData("DC", sql, par6, par7, par8);

            while (reader.Read())
            {
                Alarm a = new Alarm()
                {
                    ID = Int32.Parse(reader["ID"].ToString()),
                    activate = reader["Activate"].ToString(),
                    Snooze = Int32.Parse(reader["Snooze"].ToString()),
                    X_OP_VOORHAND = Int32.Parse(reader["X_OP_VOORHAND"].ToString())
                };
                list.Add(a);
            }

            reader.Close();
            return list[0];
        }

        public static Tuin GetTuin(int GebruikerID)
        {
            List<Tuin> list = new List<Tuin>();
            string sql = "SELECT ID, Extra, LaatstWater, GaplantOP, Aantal, Favoriet, Gebruiker_ID, Cat_ID FROM  CAT_PLANT where Gebruiker_ID = @1";
            DbParameter par6 = Database.AddParameter("DC", "@1", GebruikerID);

            DbDataReader reader = Database.GetData("DC", sql, par6);
            while (reader.Read())
            {
                Gebruiker a = GetGebruikerperid(GebruikerID);
                Plant p = getPlantperid(reader["Cat_ID"].ToString());
                Tuin t = new Tuin()
                {
                    Aantal = Int32.Parse(reader["Aantal"].ToString()),
                    Cat_ID = p,
                    Gebruiker_ID = a,
                    Extra = reader["Extra"].ToString(),
                    Favoriet = Int32.Parse(reader["Favoriet"].ToString()),
                    GeplantOP = reader["GaplantOP"].ToString(),
                    LaatstWater = reader["LaatstWater"].ToString(),
                    ID = Int32.Parse(reader["ID"].ToString())

                };

                list.Add(t);
            }

            reader.Close();
            return list[0];
        }

        private static Gebruiker GetGebruikerperid(int gebruikerID)
        {
            List<Gebruiker> list = new List<Gebruiker>();
            string sql = "SELECT ID,Naam,Voornaam,InstellingenID, Facebook, Active FROM Gebruiker Where ID=@FB";

            DbParameter par1 = Database.AddParameter("DC", "@FB", gebruikerID);
            DbDataReader reader = Database.GetData("DC", sql, par1);

            reader.Read();
            Gebruiker o = new Gebruiker()
            {
                ID = Int32.Parse(reader["ID"].ToString()),
                Naam = reader["Naam"].ToString(),
                Voornaam = reader["Voornaam"].ToString(),
                InstellingenID = GetInstellingen(Int32.Parse(reader["InstellingenID"].ToString())),
                Facebook = reader["Facebook"].ToString(),
                Active = reader["Active"].ToString()

            };


            reader.Close();
            return o;
        }

        private static Plant getPlantperid(string v)
        {
            int nr = Int32.Parse(v);
            string sql = "SELECT ID, Naam, Omschrijving, Foto, ZaaiBegin, ZaaiEinde, PlantBegin, PlantEinde, OogstBegin, OogstEinde, ZaaiDiepte, AfstandTussen, AfstandRij, WaterGeven, DagenOogst, DagenVerplanten, Buiten, Binnen FROM Catalogus WHERE ID = @1";
            DbParameter par1 = Database.AddParameter("DC", "@1", nr);
            DbDataReader reader = Database.GetData("DC", sql, par1);
            reader.Read();
            Plant o = new Plant()
            {
                ID = Int32.Parse(reader["Id"].ToString()),
                Naam = reader["Naam"].ToString(),
                Omschrijving = reader["Omschrijving"].ToString(),
                FotoUrl = reader["Foto"].ToString(),
                ZaaiBegin = reader["ZaaiBegin"].ToString(),
                ZaaiEinde = reader["ZaaiEinde"].ToString(),
                PlantBegin = reader["PlantBegin"].ToString(),
                PlantEinde = reader["PlantEinde"].ToString(),
                OogstBegin = reader["OogstBegin"].ToString(),
                OogstEinde = reader["OogstEinde"].ToString(),
                ZaaiDiepte = reader["ZaaiDiepte"].ToString(),
                AfstandTussen = reader["AfstandTussen"].ToString(),
                AfstandRij = reader["AfstandRij"].ToString(),
                WaterGeven = reader["WaterGeven"].ToString(),
                DagenOogst = reader["DagenOogst"].ToString(),
                DagenVerplanten = reader["DagenVerplanten"].ToString(),
                Buiten = Int32.Parse(reader["Buiten"].ToString()),
                Binnen = Int32.Parse(reader["Binnen"].ToString())


            };


            reader.Close();
            return o;

        }


        public static int Pastuinaan(Tuin b)
        {
            int rowsaffected = 0;
            try
            {
                string sql = "UPDATE CAT_PLANT SET Cat_ID=@1, Gebruiker_ID=@2, Favoriet=@3, Aantal = @4, GaplantOP=@5, LaatstWater=@6, Extra = @7  Where ID = @ID";
                DbParameter par1 = Database.AddParameter("DC", "@1", b.Cat_ID.ID);
                DbParameter par2 = Database.AddParameter("DC", "@2", b.Gebruiker_ID.ID);
                DbParameter par3 = Database.AddParameter("DC", "@3", b.Favoriet);
                DbParameter par4 = Database.AddParameter("DC", "@id", b.ID);
                DbParameter par5 = Database.AddParameter("DC", "@4", b.Aantal);
                DbParameter par6 = Database.AddParameter("DC", "@5", b.GeplantOP);
                DbParameter par7 = Database.AddParameter("DC", "@6", b.LaatstWater);
                DbParameter par8 = Database.AddParameter("DC", "@7", b.Extra);



                rowsaffected += Database.InsertData("DC", sql, par1, par2, par3, par4, par5, par6, par7, par8);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return b.ID;

        }
        public static int Voegnieuweplantaantuin(Tuin Not)
        {
            
            int rowsaffected = 0;
            try
            {
                string sql = "INSERT INTO CAT_PLANT(Cat_ID, Gebruiker_ID, Favoriet, Aantal, GaplantOP, LaatstWater, Extra) VALUES(@1 , @2, @3, @4, @5, @6, @7)";
                DbParameter par1 = Database.AddParameter("DC", "@1", Not.Cat_ID.ID);
                DbParameter par2 = Database.AddParameter("DC", "@2", Not.Gebruiker_ID.ID);
                DbParameter par3 = Database.AddParameter("DC", "@3", Not.Favoriet);
                DbParameter par4 = Database.AddParameter("DC", "@4", Not.Aantal);
                DbParameter par5 = Database.AddParameter("DC", "@5", Not.GeplantOP);
                DbParameter par6 = Database.AddParameter("DC", "@6", Not.LaatstWater);
                DbParameter par7 = Database.AddParameter("DC", "@7", Not.Extra);
                rowsaffected += Database.InsertData("DC", sql, par1, par2, par3, par4, par5, par6, par7);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return rowsaffected;


        }
    }
}