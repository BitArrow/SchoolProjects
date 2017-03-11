using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using static System.Console;

namespace XMLFailideLoomineJaLugemine
{
    public class ReceiptFunctions
    {
        /// <summary>
        /// Hangib kõik retseptid
        /// </summary>
        /// <returns>Tagasta kõik retseptid</returns>
        public static IEnumerable<XElement> AllReceipts(XDocument xdoc)
        {
            return xdoc.Descendants("retsept");
        }

        /// <summary>
        /// Otsib elementi pealkirja järgi
        /// </summary>
        /// <param name="xdoc">Dokument millest loetakse infot</param>
        /// <param name="heading">Pealkiri, mille järgi otsitakse</param>
        /// <returns>Elemendid, mille pealkirjas on otsitav sisu</returns>
        public static IEnumerable<XElement> SearchByHeading(XDocument xdoc, string heading)
        {
            var query = xdoc.Descendants("retsept");

            // Otsib retsepti pealkirja järgi
            var searchHead = query.Where(h => h.Element("pealkiri").Value.Contains(heading));

            return searchHead;
        }

        /// <summary>
        /// Otsib kõik retseptid koostisosa järgi
        /// </summary>
        /// <param name="xdoc">Document, millest loetakse infot</param>
        /// <param name="inc">Koostisosa, mille järgi otsitakse</param>
        /// <returns>Elemendid, mis sisaldavad vastavat koostisosa</returns>
        public static IEnumerable<XElement> SearchByIngredient(XDocument xdoc, string inc)
        {
            var query = xdoc.Descendants("retsept");

            // Otsib retsepti koostisosa järgi
            var searchInc = query.Where(k => k.Descendants("koostisosa").Any(v => v.Value.Contains(inc)));

            return searchInc;
        }

        /// <summary>
        /// Kirjutab välja retseptid
        /// </summary>
        /// <param name="query">Retseptid</param>
        public static void WriteReceiptData(IEnumerable<XElement> query)
        {
            foreach (var receipt in query)
            {
                string heading = receipt.Element("pealkiri").Value;
                WriteLine(heading);

                // Hangib retsepti kõik koositsosad
                foreach (var ingredient in receipt.Descendants("koostisosa"))
                {
                    string ammount = ingredient.Attribute("kogus").Value;
                    string unit = ingredient.Attribute("yhik").Value;
                    string name = ingredient.Value;
                    WriteLine("{0}{1} {2}", ammount, unit, name);
                }

                WriteLine();
            }
        }
    }
}
