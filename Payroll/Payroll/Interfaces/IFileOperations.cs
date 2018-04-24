using System;
using System.Collections.Generic;
using System.Text;

namespace Payroll.Interfaces
{
   public interface IFileOperations
   {
       bool SavePDF(string fileName, byte[] data);
   }
}
