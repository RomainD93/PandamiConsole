using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;



using System.Text;
using System.Threading.Tasks;

namespace ConsoleBDD
{
    class Program
    {
        static void Main(string[] args)
        {



            using (var reader = new StreamReader(@"C:\Pand-Ami\StOuen.csv"))
            {
                Adresses adresse = new Adresses();
                List<Adresses> listAdresse = new List<Adresses>();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    string[] values = line.Split(';');
                    adresse.Id = Int32.Parse(values[0]);
                    adresse.NumeroDeVoie = values[1];
                    adresse.NomDeVoie = values[2];
                    adresse.CodePostal = values[3];
                    adresse.Ville = values[4];
                    adresse.latitude = float.Parse(values[5]);
                    adresse.longitude = float.Parse(values[6]);


                    // Console.WriteLine(adresse.NumeroDeVoie+adresse.NomDeVoie+adresse.CodePostal+adresse.Ville+adresse.latitude+adresse.longitude);

                    string connectString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PandamiV1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";

                    DataClasses1DataContext _context = new DataClasses1DataContext(connectString);

                    var adresseBDD = from m in _context.Adresses
                                              where m.Id.Equals(adresse.Id)
                                              select m;

                    if (adresseBDD!=adresse)
                    {
                        _context.Adresses.InsertOnSubmit(adresse);
                        _context.SubmitChanges();
                    }

                    
                    



                }
            }










        }

        static void AjoutAdresseCSV(List<Adresses> listAdresse)
        {
            
        }
    }
}
