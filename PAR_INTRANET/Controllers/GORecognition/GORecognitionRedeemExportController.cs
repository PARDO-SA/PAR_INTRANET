using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using PAR_INTRANET.Models;

namespace PAR_INTRANET.Controllers
{
    public class GORecognitionRedeemExportController : Controller
    {
        // GET: GORecognitionRedeemExport
        public ActionResult Index()
        {
            return View(new List<GORecognitionRedeemExport>());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            List<GORecognitionRedeemExport> Redeems = new List<GORecognitionRedeemExport>();
            string filePath = string.Empty;
            if (postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                filePath = path + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(filePath);

                //Read the contents of CSV file.
                string csvData = System.IO.File.ReadAllText(filePath);

                int linea = 0;
                //Execute a loop over the rows.
                foreach (string row in csvData.Split('\n'))
                {                    
                    if (!string.IsNullOrEmpty(row))
                    {
                        if (linea > 0)
                            {
                                Redeems.Add(new GORecognitionRedeemExport
                                {
                                    Fecha = Convert.ToDateTime(row.Split(',')[0].ToString().Replace('\"', ' ').Trim()),
                                    Numero = Convert.ToInt32(row.Split(',')[1].ToString().Replace('\"', ' ').Trim()),
                                    Detalle = row.Split(',')[2].ToString().Replace('\"', ' ').Trim() + " x " + Convert.ToInt16(row.Split(',')[5].ToString().Replace('\"', ' ').Trim()),
                                    //FechaUso = Convert.ToDateTime(row.Split(',')[3].ToString().Replace('\"', ' ').Trim()),
                                    Tipo = row.Split(',')[4].ToString().Replace('\"', ' ').Trim(),
                                    Cantidad = Convert.ToInt16(row.Split(',')[5].ToString().Replace('\"', ' ').Trim()),
                                    //DireccionEnvio = row.Split(',')[6].ToString().Replace('\"', ' ').Trim(),
                                    //Duracion = row.Split(',')[7].ToString().Replace('\"', ' ').Trim(),
                                    //Opcion = row.Split(',')[8].ToString().Replace('\"', ' ').Trim(),
                                    Puntos = Convert.ToInt16(row.Split(',')[9].ToString().Replace('\"', ' ').Trim()),
                                    Estado = row.Split(',')[10].ToString().Replace('\"', ' ').Trim(),
                                    Documento = Convert.ToInt32(row.Split(',')[11].ToString().Replace('\"', ' ').Trim()),
                                    ApellidoNombre = row.Split(',')[12].ToString().Replace('\"', ' ').Trim(),
                                    Contacto = row.Split(',')[13].ToString().Replace('\"', ' ').Trim(),
                                    //Genero = row.Split(',')[14].ToString().Replace('\"', ' ').Trim(),
                                    //FechaNacimiento = Convert.ToDateTime(row.Split(',')[15].ToString().Replace('\"', ' ').Trim())//,
                                    //ReportaA = row.Split(',')[16]
                                    Importar = false
                                });
                            }
                        linea++;
                    }
                }
            }

            return View(Redeems);
        }
    }
}