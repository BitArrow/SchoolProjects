using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using static System.Console;

namespace XMLFailideLoomineJaLugemine
{
    public class ClassRoomFunctions
    {
        /// <summary>
        /// Hangib XMList kõik klassiruumid.
        /// </summary>
        /// <param name="xdoc">Fail, kust infot loetakse</param>
        /// <returns>Klassiruumid, mis leiti</returns>
        internal static IEnumerable<XElement> AllClassRooms(XDocument xdoc)
        {
            return xdoc.Descendants("klass");
        }

        /// <summary>
        /// Otisb klassid numbri järgi
        /// </summary>
        /// <param name="xdoc">Fail, kust infot loetakse</param>
        /// <param name="classNumber">Klassi number, mida otsitakse</param>
        /// <returns>Klass(id), mis on etteantud numbriga</returns>
        internal static IEnumerable<XElement> ClassRoomByNumber(XDocument xdoc, string classNumber)
        {
            var query = xdoc.Descendants("klass");

            // Otsib retsepti pealkirja järgi
            var searchHead = query.Where(h => h.Element("number").Value.Contains(classNumber));

            return searchHead;
        }

        /// <summary>
        /// Trükib välja klasside info ja seal olevate arvutite info.
        /// </summary>
        /// <param name="query">kollektsioon, millest infot loetakse.</param>
        internal static void WriteClassRoomData(IEnumerable<XElement> query)
        {
            foreach (var classroom in query)
            {
                string roomNr = classroom.Element("number").Value;
                string roomPorpuse = classroom.Element("kasutus").Value;
                WriteLine("Klassiruum {0} - {1}", roomNr, roomPorpuse);

                // Hangib kõik arvutid klassiruumist
                foreach (var computer in classroom.Descendants("arvuti"))
                {
                    string compNum = computer.Element("number").Value;
                    WriteLine("Arvuti {0}:", compNum);
                    // Hangib kõik arvuti konfiguratsiooni andmed
                    foreach (var config in computer.Descendants("config"))
                    {
                        string configName = config.Attribute("name").Value;
                        string configValue = config.Value;
                        WriteLine("{0}: {1}", configName, configValue);
                    }
                    WriteLine("----------------");
                }

                WriteLine();
            }
        }
    }
}
