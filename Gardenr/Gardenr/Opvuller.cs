using GalaSoft.MvvmLight.Ioc;
using Gardenr.Models;
using Gardenr.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardenr
{
    class Opvuller
    {
        public Opvuller()
        {

        }
        private IPlantRepository repoPlant = SimpleIoc.Default.GetInstance<IPlantRepository>();
        //http://zaaikalender.com/
        public async void VulCatalogus()
        {
            Plant plant1 = new Plant();
            plant1.Naam = "Tomaat";
            plant1.Omschrijving = "De tomaat is een vrucht, afkomstig van de tomatenplant. De populaire vrucht is culinair gezien een groente";
            plant1.FotoUrl = "http://student.howest.be/cedric.lecat/Gardnr/Tomaat.jpg";
            plant1.ZaaiBegin = "01/01/2000";
            plant1.ZaaiEinde = "30/12/2000";
            plant1.OogstBegin = "01/01/2000";
            plant1.OogstEinde = "30/12/2000";
            plant1.ZaaiDiepte = "5";
            plant1.AfstandTussen = "30";
            plant1.AfstandRij = "50";
            plant1.WaterGeven = "5";
            plant1.DagenOogst = "365";
            plant1.DagenVerplanten = "0";
            plant1.Binnen = 1;
            plant1.Buiten = 1;
            repoPlant.AddPlant(plant1);

            Plant plant2 = new Plant();
            plant2.Naam = "Prei";
            plant2.Omschrijving = "Prei, Allium ampeloprasum var. porrum, synoniem: Allium porrum, is een plant uit de lookfamilie, die als groente wordt gegeten. ";
            plant2.FotoUrl = "http://student.howest.be/cedric.lecat/Gardnr/Prei.jpg";
            plant2.ZaaiBegin = "01/01";
            plant2.ZaaiEinde = "30/12";
            plant2.OogstBegin = "01/01";
            plant2.OogstEinde = "30/12";
            plant2.ZaaiDiepte = "20";
            plant2.AfstandTussen = "10";
            plant2.AfstandRij = "30";
            plant2.WaterGeven = "5";
            plant2.DagenOogst = "365";
            plant2.DagenVerplanten = "20";
            plant2.Binnen = 0;
            plant2.Buiten = 1;
            repoPlant.AddPlant(plant2);

            Plant plant3 = new Plant();
            plant2.Naam = "BindSla";
            plant2.Omschrijving = "Bindsla (Lactuca sativa var. longifolia, synoniem: Lactuca sativa var. romana), ook bekend als Romeinse sla, is een bladgroente die vooral in volkstuinen wordt geteeld, maar de beroepsteelt neem toe ter vervanging van ijsbergsla[bron?]. Bindsla vormt tot 40 cm lange, langwerpige kroppen. Bindsla was al 4000 jaar geleden bij de Egyptenaren bekend en werd voornamelijk in het Middellandse Zeegebied geteeld, maar wordt nu in heel Europa en in Noord-Amerika geteeld";
            plant2.FotoUrl = "http://student.howest.be/cedric.lecat/Gardnr/Bindsla.jpg";
            plant2.ZaaiBegin = "01/04/2000";
            plant2.ZaaiEinde = "30/08/2000";
            plant2.OogstBegin = "01/06/2000";
            plant2.OogstEinde = "30/09/2000";
            plant2.ZaaiDiepte = "5";
            plant2.AfstandTussen = "25";
            plant2.AfstandRij = "30";
            plant2.WaterGeven = "5";
            plant2.DagenOogst = "90";
            plant2.DagenVerplanten = "12";
            plant2.Binnen = 1;
            plant2.Buiten = 1;
            repoPlant.AddPlant(plant3);

            Plant plant4 = new Plant();
            plant4.Naam = "Andijvie";
            plant4.Omschrijving = "Andijvie (Cichorium endivia) is een eenjarig bladgewas dat nauw verwant is aan witlof (Cichorium intybus var. foliosum). De groente is vrijwel het gehele jaar verkrijgbaar. In de wintermaanden en in het vroege voorjaar komt de andijvie uit de glastuinbouw, deze andijviestruiken zijn veel kleiner en zachter dan die van de koude grond en hebben daardoor een kortere kooktijd";
            plant4.FotoUrl = "http://student.howest.be/cedric.lecat/Gardnr/Andijvi.jpg";
            plant4.ZaaiBegin = "01/04/2000";
            plant4.ZaaiEinde = "30/08/2000";
            plant4.OogstBegin = "01/07/2000";
            plant4.OogstEinde = "30/11/2000";
            plant4.ZaaiDiepte = "5";
            plant4.AfstandTussen = "30";
            plant4.AfstandRij = "30";
            plant4.WaterGeven = "5";
            plant4.DagenOogst = "90";
            plant4.DagenVerplanten = "15";
            plant4.Binnen = 1;
            plant4.Buiten = 1;
            repoPlant.AddPlant(plant4);

            Plant plant5 = new Plant();
            plant5.Naam = "Kropsla";
            plant5.Omschrijving = "Sla (Lactuca) is een geslacht van bladgroenten die tegenwoordig rauw gegeten worden. In de Romeinse tijd werd sla nog gekookt omdat hij nog niet mals genoeg was";
            plant5.FotoUrl = "http://student.howest.be/cedric.lecat/Gardnr/Kropsla.jpg";
            plant5.ZaaiBegin = "01/03/2000";
            plant5.ZaaiEinde = "30/04/2000";
            plant5.OogstBegin = "01/05/2000";
            plant5.OogstEinde = "30/11/2000";
            plant5.ZaaiDiepte = "5";
            plant5.AfstandTussen = "30";
            plant5.AfstandRij = "30";
            plant5.WaterGeven = "5";
            plant5.DagenOogst = "65";
            plant5.DagenVerplanten = "12";
            plant5.Binnen = 1;
            plant5.Buiten = 1;
            repoPlant.AddPlant(plant5);

            Plant plant6 = new Plant();
            plant6.Naam = "Mosterd";
            plant6.Omschrijving = "De mosterdplant is een kleine eenjarige plant met gele bloemen, het wordt vaak verward met koolzaad waar het erg op lijkt en ook nauw verwant aan is. Mosterdzaadjes zijn ongeveer 0,5 tot 1 mm groot";
            plant6.FotoUrl = "http://student.howest.be/cedric.lecat/Gardnr/Mustard.jpg";
            plant6.ZaaiBegin = "01/03/2000";
            plant6.ZaaiEinde = "30/08/2000";
            plant6.OogstBegin = "01/04/2000";
            plant6.OogstEinde = "30/09/2000";
            plant6.ZaaiDiepte = "5";
            plant6.AfstandTussen = "15";
            plant6.AfstandRij = "30";
            plant6.WaterGeven = "5";
            plant6.DagenOogst = "90";
            plant6.DagenVerplanten = "4";
            plant6.Binnen = 1;
            plant6.Buiten = 1;
            repoPlant.AddPlant(plant6);

            Plant plant7 = new Plant();
            plant7.Naam = "Rabarber";
            plant7.Omschrijving = "Rabarber (Rheum rhabarbarum) is een plant uit de duizendknoopfamilie. De plant wordt gekweekt vanwege zijn eetbare delen.";
            plant7.FotoUrl = "http://student.howest.be/cedric.lecat/Gardnr/Rabarber.jpg";
            plant7.ZaaiBegin = "01/09/2000";
            plant7.ZaaiEinde = "30/012/2000";
            plant7.OogstBegin = "01/04/2000";
            plant7.OogstEinde = "30/08/2000";
            plant7.ZaaiDiepte = "5";
            plant7.AfstandTussen = "50";
            plant7.AfstandRij = "50";
            plant7.WaterGeven = "5";
            plant7.DagenOogst = "360";
            plant7.DagenVerplanten = "8";
            plant7.Binnen = 1;
            plant7.Buiten = 1;
            repoPlant.AddPlant(plant7);


            Plant plant9 = new Plant();
            plant9.Naam = "Spinazie";
            plant9.Omschrijving = "Spinazie (Spinacia oleracea) is een plant uit de amarantenfamilie (Amaranthaceae) die verwant is aan bijvoorbeeld ganzenvoet en melde. Het is een snelgroeiende, eenjarige bladgroente, die al vroeg in het voorjaar beschikbaar is";
            plant9.FotoUrl = "http://student.howest.be/cedric.lecat/Gardnr/Spinazi.jpg";
            plant9.ZaaiBegin = "01/01/2000";
            plant9.ZaaiEinde = "30/08/2000";
            plant9.OogstBegin = "01/04/2000";
            plant9.OogstEinde = "30/11/2000";
            plant9.ZaaiDiepte = "5";
            plant9.AfstandTussen = "5";
            plant9.AfstandRij = "15";
            plant9.WaterGeven = "5";
            plant9.DagenOogst = "35";
            plant9.DagenVerplanten = "10";
            plant9.Binnen = 1;
            plant9.Buiten = 1;
            repoPlant.AddPlant(plant9);

            Plant plant10 = new Plant();
            plant10.Naam = "VeldSla";
            plant10.Omschrijving = "Veldsla (Valerianella locusta, synoniem: Valerianella olitoria) is een plant uit kamperfoeliefamilie (Caprifoliaceae). De soort wordt ook wel korensla of ezelsoor genoemd.";
            plant10.FotoUrl = "http://student.howest.be/cedric.lecat/Gardnr/Veldsla.jpg";
            plant10.ZaaiBegin = "01/03/2000";
            plant10.ZaaiEinde = "30/09/2000";
            plant10.OogstBegin = "01/04/2000";
            plant10.OogstEinde = "30/12/2000";
            plant10.ZaaiDiepte = "5";
            plant10.AfstandTussen = "5";
            plant10.AfstandRij = "20";
            plant10.WaterGeven = "5";
            plant10.DagenOogst = "75";
            plant10.DagenVerplanten = "15";
            plant10.Binnen = 1;
            plant10.Buiten = 1;
            repoPlant.AddPlant(plant10);

            Plant plant11 = new Plant();
            plant11.Naam = "Waterkers";
            plant11.Omschrijving = "Waterkers (Rorippa, synoniem: Nasturtium) is een geslacht van kruidachtige planten uit de kruisbloemenfamilie (Brassicaceae). Het zijn planten die meestal op zeer vochtige plaatsen groeien";
            plant11.FotoUrl = "http://student.howest.be/cedric.lecat/Gardnr/Waterkers.jpg";
            plant11.ZaaiBegin = "01/03/2000";
            plant11.ZaaiEinde = "30/06/2000";
            plant11.OogstBegin = "01/04/2000";
            plant11.OogstEinde = "30/12/2000";
            plant11.ZaaiDiepte = "5";
            plant11.AfstandTussen = "15";
            plant11.AfstandRij = "30";
            plant11.WaterGeven = "5";
            plant11.DagenOogst = "75";
            plant11.DagenVerplanten = "15";
            plant11.Binnen = 1;
            plant11.Buiten = 1;
            repoPlant.AddPlant(plant11);

            Plant plant12 = new Plant();
            plant12.Naam = "Aardappel";
            plant12.Omschrijving = "De aardappel (Solanum tuberosum) is een plant die ondergronds een energievoorraad in de vorm van zetmeel aanlegt. Het zetmeel wordt bewaard in knollen, die aardappelen of aardappels worden genoemd";
            plant12.FotoUrl = "http://student.howest.be/cedric.lecat/Gardnr/Aardappel.jpg";
            plant12.ZaaiBegin = "01/04/2000";
            plant12.ZaaiEinde = "30/06/2000";
            plant12.OogstBegin = "01/07/2000";
            plant12.OogstEinde = "30/09/2000";
            plant12.ZaaiDiepte = "5";
            plant12.AfstandTussen = "40";
            plant12.AfstandRij = "50";
            plant12.WaterGeven = "5";
            plant12.DagenOogst = "120";
            plant12.DagenVerplanten = "20";
            plant12.Binnen = 1;
            plant12.Buiten = 1;
            repoPlant.AddPlant(plant12);

            Plant plant13 = new Plant();
            plant13.Naam = "Spruitjes";
            plant13.Omschrijving = "Spruitkool of spruitjes (Brassica oleracea convar. oleracea var. gemmifera) zijn een kleine koolsoort. Het is een belangrijke wintergroente.";
            plant13.FotoUrl = "http://student.howest.be/cedric.lecat/Gardnr/Spruitjes.jpg";
            plant13.ZaaiBegin = "01/02/2000";
            plant13.ZaaiEinde = "30/04/2000";
            plant13.OogstBegin = "01/09/2000";
            plant13.OogstEinde = "30/12/2000";
            plant13.ZaaiDiepte = "5";
            plant13.AfstandTussen = "60";
            plant13.AfstandRij = "60";
            plant13.WaterGeven = "5";
            plant13.DagenOogst = "250";
            plant13.DagenVerplanten = "15";
            plant13.Binnen = 1;
            plant13.Buiten = 1;
            repoPlant.AddPlant(plant13);

            Plant plant14 = new Plant();
            plant14.Naam = "Knolselderij";
            plant14.Omschrijving = "Knolselderij, Apium graveolens var. rapaceum, is een variant van selderij die net boven de grond een knol vormt. Knolselderij vormt een knol met een diameter van zo'n 10 cm. De knollen voor industriële verwerking moeten groter zijn dan die voor verse consumptie.";
            plant14.FotoUrl = "http://student.howest.be/cedric.lecat/Gardnr/Knolselder.jpg";
            plant14.ZaaiBegin = "01/03/2000";
            plant14.ZaaiEinde = "30/04/2000";
            plant14.OogstBegin = "01/09/2000";
            plant14.OogstEinde = "30/12/2000";
            plant14.ZaaiDiepte = "5";
            plant14.AfstandTussen = "35";
            plant14.AfstandRij = "50";
            plant14.WaterGeven = "5";
            plant14.DagenOogst = "260";
            plant14.DagenVerplanten = "20";
            plant14.Binnen = 1;
            plant14.Buiten = 1;
            repoPlant.AddPlant(plant14);

            Plant plant15 = new Plant();
            plant15.Naam = "Radijs";
            plant15.Omschrijving = "De radijs (Raphanus sativus subsp. sativus) is een plant uit de kruisbloemenfamilie (Cruciferae oftewel Brassicaceae)";
            plant15.FotoUrl = "http://student.howest.be/cedric.lecat/Gardnr/Radijs.jpg";
            plant15.ZaaiBegin = "01/04/2000";
            plant15.ZaaiEinde = "30/09/2000";
            plant15.OogstBegin = "01/04/2000";
            plant15.OogstEinde = "30/10/2000";
            plant15.ZaaiDiepte = "5";
            plant15.AfstandTussen = "5";
            plant15.AfstandRij = "10";
            plant15.WaterGeven = "5";
            plant15.DagenOogst = "40";
            plant15.DagenVerplanten = "10";
            plant15.Binnen = 1;
            plant15.Buiten = 1;
            repoPlant.AddPlant(plant15);

        }
    }
}
