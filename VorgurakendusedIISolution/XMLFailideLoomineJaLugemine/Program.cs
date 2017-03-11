using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using static System.Console;

namespace XMLFailideLoomineJaLugemine
{
    // https://wiki.itcollege.ee/index.php/Praktikum:_XML_failide_loomine(VR2.1)
    // Tauri Busch - Kodutöö 1
    class Program
    {
        static void Main(string[] args)
        {
            //string xmlReceiptPath = @"c:\users\tauri\documents\visual studio 2015\Projects\VorgurakendusedIISolution\XMLFailideLoomineJaLugemine\RetseptiRaamat.xml";
            //string xmlClassRoomPath = @"c:\users\tauri\documents\visual studio 2015\Projects\VorgurakendusedIISolution\XMLFailideLoomineJaLugemine\Klassiruumid.xml";
            string xmlReceiptPath = GetFilePath("RetseptiRaamat.xml");
            string xmlClassRoomPath = GetFilePath("Klassiruumid.xml");

            ReceiptFun(GetDoc(xmlReceiptPath));
            ClassRoomFun(GetDoc(xmlClassRoomPath));
            ComplexFun();

            ReadLine();
        }

        /// <summary>
        /// Kuvab kompleksarvulised tegevused
        /// </summary>
        private static void ComplexFun()
        {
            var komp1 = new Kompleksarv(5, 2);
            var komp2 = new Kompleksarv(4, 3);
            var komp3 = new Kompleksarv(17, 7);

            Write("Komp1 = ");
            komp1.KuvaRida();
            Write("Komp2 = ");
            komp2.KuvaRida();
            Write("Komp3 = ");
            komp3.KuvaRida();
            WriteLine();

            Write("komp1 + komp2 = ");
            komp1.Liida(komp2);
            komp1.KuvaRida();
            Write("komp3 - komp1 = ");
            komp3.Lahuta(komp1);
            komp3.KuvaRida();
        }

        /// <summary>
        /// Kuvab klassiruumiga seonduvad tegevused
        /// </summary>
        /// <param name="doc">Fail, kust infot loetakse</param>
        private static void ClassRoomFun(XDocument doc)
        {
            WriteLine("Kõik klassiruumid");
            var resAll = ClassRoomFunctions.AllClassRooms(doc);
            ClassRoomFunctions.WriteClassRoomData(resAll);

            WriteLine("Kindel klassiruum:");
            var resSpec = ClassRoomFunctions.ClassRoomByNumber(doc, "201");
            ClassRoomFunctions.WriteClassRoomData(resSpec);
        }

        /// <summary>
        /// Kutsub esile retseptiraamatu funktsioonid
        /// </summary>
        /// <param name="doc">Dokument, millest infot loetakse</param>
        private static void ReceiptFun(XDocument doc)
        {
            WriteLine("Pealkirja järgi:");
            var resH = ReceiptFunctions.SearchByHeading(doc, "Viin");
            ReceiptFunctions.WriteReceiptData(resH);

            WriteLine("Koostisosa järgi:");
            var resI = ReceiptFunctions.SearchByIngredient(doc, "Vorst");
            ReceiptFunctions.WriteReceiptData(resI);
        }

        /// <summary>
        /// Laeb dokumendi
        /// </summary>
        /// <param name="path">dokumendi asukoht</param>
        /// <returns>Dokument</returns>
        private static XDocument GetDoc(string path)
        {
            return XDocument.Load(path);
        }

        /// <summary>
        /// Koostab faili asukoha projekti kaustast (bin) + faili nimi
        /// </summary>
        /// <param name="filename">Faili nimi</param>
        /// <returns>Teekond failini projekti (bin) kaustast</returns>
        private static string GetFilePath(string filename)
        {
            return Path.Combine(Environment.CurrentDirectory, filename);
        }
    }
}
