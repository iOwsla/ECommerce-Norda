using System;
using System.Text;
using System.Security.Cryptography;
using Microsoft.CodeAnalysis.Scripting;
namespace Divisima.WebUI.Tools
{
    public class GeneralTool
    {
        public static string getMd5(string input)
        {
            // MD5.Create() metodu ile MD5 hash algoritmasını oluştur
            using (MD5 md5 = MD5.Create())
            {
                // String değeri byte dizisine dönüştür
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);

                // MD5 hash hesapla
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Byte dizisini string formata dönüştür
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString().ToLower();
            }
        }

        public static string getSha256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // String değeri byte dizisine dönüştür
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);

                // MD5 hash hesapla
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // Byte dizisini string formata dönüştür
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString().ToLower();
            }
        }
        public static string GetBcryptHash(string input)
        {
            // Rastgele bir "salt" oluştur ve input string'ini hash'le
            string hash = BCrypt.Net.BCrypt.HashPassword(input);

            return hash;
        }

        // Hash doğrulama
        public static bool VerifyBcryptHash(string input, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(input, hash);
        }

        public static async Task<string> UploadImage(IFormFile file, string folderName, string fileName)
        {
            try
            {
                var combinePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", folderName);
                if (!Directory.Exists(combinePath))
                {
                    Directory.CreateDirectory(combinePath);
                }
                using (FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", folderName, fileName), FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return $"/images/" + folderName + "/" + fileName;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }


}