using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sintaxis_1
{
    //Requerimiento: Número de linea donde se encuentra el error
    public class Error : Exception
    {
        public Error(string mensaje, StreamWriter log) : base("Error: " + mensaje)
        {
            log.WriteLine("Error: " + mensaje);
        }

        private void lineaError(string mensaje, StreamWriter log)
        {
            var stackTrace = new StackTrace(true);
            var frame = stackTrace.GetFrame(0);
            var lineNumber = frame.GetFileLineNumber();

            log.WriteLine("Error en la linea"+lineNumber);
            throw new Exception("Error en la linea"+lineNumber);
        }
    }
}