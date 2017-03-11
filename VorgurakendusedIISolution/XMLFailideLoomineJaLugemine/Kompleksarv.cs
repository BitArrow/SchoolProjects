using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

using static System.Console;

namespace XMLFailideLoomineJaLugemine
{
    public class Kompleksarv
    {
        Complex _complex;

        /// <summary>
        /// Loob uue kompleksarvu
        /// </summary>
        /// <param name="real"></param>
        /// <param name="imagi"></param>
        public Kompleksarv(double real, double imagi)
        {
            _complex = new Complex(real, imagi);
        }

        /// <summary>
        /// Loob uue kompleksarvu väärtusega 0
        /// </summary>
        public Kompleksarv()
        {
            _complex = new Complex(0, 0);
        }

        /// <summary>
        /// Liidab kompleks arvule juurde ette antava kompleksarvu.
        /// </summary>
        /// <param name="complex">Juurde liidetav kompleksarv</param>
        /// <returns></returns>
        public void Liida(Kompleksarv complex)
        {
            _complex += complex._complex;
        }

        /// <summary>
        /// Lahutab kompleks arvult maha kaasa antava kompleksarvu
        /// </summary>
        /// <param name="complex">Maha lahutatav kompleksarv</param>
        /// <returns></returns>
        public void Lahuta(Kompleksarv complex)
        {
            _complex -= complex._complex;
        }

        /// <summary>
        /// Kuvab konsooli kompleks arvu -- Write()
        /// </summary>
        public void Kuva()
        {
            Write("{0} + {1}i", _complex.Real, _complex.Imaginary);
        }

        /// <summary>
        /// Kuvab konsooli kompleks arvu -- WriteLine()
        /// </summary>
        public void KuvaRida()
        {
            WriteLine("{0} + {1}i", _complex.Real, _complex.Imaginary);
        }
    }
}
