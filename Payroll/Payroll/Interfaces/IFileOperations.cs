namespace Payroll.Interfaces
{
   public interface IFileOperations
   {
       bool SavePDF(string fileName, byte[] data);

       byte[] ReadPDF(string fileName);
    }
}
