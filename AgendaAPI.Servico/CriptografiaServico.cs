using AgendaAPI.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AgendaAPI.Servico
{
    public class CriptografiaServico : ICriptografiaServico
    {
        public string Criptografar(string stringDecriptografada)
        {
            byte[] bytesDecriptografados = Encoding.UTF8.GetBytes(stringDecriptografada);
            byte[] bytesCriptografados;
            HashAlgorithm hash = new SHA512Managed();

            try
            {
                bytesCriptografados = hash.ComputeHash(bytesDecriptografados);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Convert.ToBase64String(bytesCriptografados);

        }
    }
}
