using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

public class ZipToTxtFile
{

    static public void Main()
    {
        Console.WriteLine("--- Main Init ---\n");

        string path = Directory.GetCurrentDirectory();
        Console.WriteLine("The current directory is {0}", path, "\n");
        
        //  Set the name of your zip file location below
        string zipFileName = path + "/temp/allData.zip";

        StringBuilder zipBytes = StreamFile(zipFileName);

        WriteBytesToFile(zipBytes);
        WriteHashToFile(zipBytes);
    }

    static StringBuilder StreamFile(string zipFileName)
    {

        Console.WriteLine("--- StreamFile ---\n");

        if (File.Exists(zipFileName))
        {
            Console.WriteLine("--- File Found --- \n");
        }
        else
        {
            throw new ArgumentException("--- File Not Found! ---\n");
        }

        FileStream fs = new FileStream(zipFileName, FileMode.Open, FileAccess.Read);

        // Create a byte array of file stream length
        byte[] zipBytes = File.ReadAllBytes(fs.Name);
        StringBuilder byteString = new StringBuilder();

        foreach (byte s in zipBytes)
        {
            byteString.Append(s);
        }

        // Close the File Stream
        fs.Close();
        return byteString; // return the byte data
    }

    static void WriteBytesToFile(StringBuilder byteString)
    {
        Console.WriteLine("--- WriteBytesToFile ---\n");

        string txtFileName = "./temp/bytes.txt";

        try
        {
            // Check if file already exists. If yes, delete it.     
            if (File.Exists(txtFileName))
            {
                Console.WriteLine("--- File Exists ---\n");
                File.Delete(txtFileName);
            }

            // Create a new file     
            using (StreamWriter sw = File.CreateText(txtFileName))
            {
                sw.WriteLine(byteString);
            }

        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.ToString());
        }
    }

    static void WriteHashToFile(StringBuilder byteString)
    {
        Console.WriteLine("--- WriteHashToFile ---\n");

        string hashFileName = "./temp/" + DateTime.Now.ToString("MM-dd-yy") + "-hash.txt";

        try
        {
            // Check if file already exists. If yes, delete it.     
            if (File.Exists(hashFileName))
            {
                Console.WriteLine("--- File Exists ---\n");
                File.Delete(hashFileName);
            }
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(byteString.ToString()));

                // Convert byte array to a string 
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    // x2 formats the string as two lowercase hexadecimal characters
                    builder.Append(bytes[i].ToString("x2"));
                }
                // Create a new file     
                using (StreamWriter sw = File.CreateText(hashFileName))
                {
                    sw.WriteLine(builder.ToString());
                }
            }
        }
        catch (Exception Ex)
        {
            Console.WriteLine(Ex.ToString());
        }
    }
}
