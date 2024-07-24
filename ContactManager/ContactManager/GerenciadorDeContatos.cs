using System;
using System.Collections.Generic;
using System.IO;
using ContactManager.Model;

namespace ContactManager.Data
{
    public class GerenciadorDeContatos
    {
        private const string CaminhoArquivo = "contatos.txt";

        public void SalvarContatos(List<Contato> contatos)
        {
            using (StreamWriter writer = new StreamWriter(CaminhoArquivo))
            {
                foreach (var contato in contatos)
                {
                    string linha = $"{contato.NomeCompleto};{contato.Telefone};{contato.Email};{contato.Endereco};{contato.DataNascimento:yyyy-MM-dd};{contato.Grupo}";
                    writer.WriteLine(linha);
                }
            }
        }

        public List<Contato> CarregarContatos()
        {
            List<Contato> contatos = new List<Contato>();

            if (File.Exists(CaminhoArquivo))
            {
                using (StreamReader reader = new StreamReader(CaminhoArquivo))
                {
                    string linha;
                    while ((linha = reader.ReadLine()) != null)
                    {
                        string[] dados = linha.Split(';');
                        Contato contato = new Contato
                        {
                            NomeCompleto = dados[0],
                            Telefone = dados[1],
                            Email = dados[2],
                            Endereco = dados[3],
                            DataNascimento = DateTime.Parse(dados[4]),
                            Grupo = dados[5]
                        };
                        contatos.Add(contato);
                    }
                }
            }

            return contatos;
        }
    }
}
