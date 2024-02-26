using RandomnessGenerators;
using System.Security.Cryptography;
using System.Transactions;

public class Program
{
    public static void Main()
    {
        Encrypter enc = new Encrypter();

        Console.WriteLine("Enter line to be encrypted and decrypted: ");

        string message = "";

        while (string.IsNullOrEmpty(message))
        {
            message = Console.ReadLine();
        }

        Console.WriteLine("\nMessage:\t" + message);
        string encryptedMessage = enc.Encrypt(message);
        Console.WriteLine("Enc message:\t" + encryptedMessage);
        string decryptedMessage = enc.Decrypt(encryptedMessage);
        Console.WriteLine("Dec message:\t" + decryptedMessage);
    }
}
