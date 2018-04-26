using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Payroll.Droid.NativeImplementations;
using Payroll.Interfaces;


[assembly: Xamarin.Forms.Dependency(typeof(FileOperations))]

namespace Payroll.Droid.NativeImplementations
{
    public class FileOperations : IFileOperations
    {
        public bool SavePDF(string fileName, byte[] data)
        {
            try
            {
                CreateFolder();
                var dir = new Java.IO.File
                    (Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/Document/Payroll");
                string filePath = System.IO.Path.Combine(dir.Path, fileName);
                File.WriteAllBytes(filePath, data);
                return true;
            }
            catch (System.Exception e)
            {
                return false;
            }
        }

        public byte[] ReadPDF(string fileName)
        {
            try
            {
                var dir = new Java.IO.File
                    (Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/Document/Payroll");
                string filePath = System.IO.Path.Combine(dir.Path, fileName);
                var bytes = File.ReadAllBytes(filePath);
                if (bytes.Length > 1)
                {
                    return bytes;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        public void CreateFolder()
        {
            var dir = new Java.IO.File
                (Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/Document/Payroll");
            if (!dir.Exists())
                dir.Mkdirs();
        }
    }
}