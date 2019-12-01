using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoAdoNet();
            //GravarUsandoEntity();
            RecuperarProdutos();
            ExcluirProdutos();
            RecuperarProdutos();
            AtualizarProduto();
        }

        private static void AtualizarProduto()
        {
            // Incluir um produto.
            GravarUsandoEntity();

            // Obter o produto e atualiza-lo.
            using (var repo = new ProdutoDAOEntity())
            {
                Produto primeiro = repo.Produtos().First();
                primeiro.Nome = "Cassino Royale - Editado";
                repo.Atualizar(primeiro);
            }

            RecuperarProdutos();
        }

        private static void ExcluirProdutos()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = repo.Produtos();
                foreach(var item in produtos)
                {
                    repo.Remover(item);
                }
            }
        }

        private static void RecuperarProdutos()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = repo.Produtos();
                Console.WriteLine("Foram encontrados {0} produtos.", produtos.Count);
                foreach(var item in produtos)
                {
                    Console.WriteLine(item.Nome);
                }
            }
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var contexto = new ProdutoDAOEntity())
            {
                contexto.Adicionar(p);
            }
            // Com o metódo AddRange(), podemos adicionar vários objetos de uma vez no metódo. Além disso,
            // ganhamos uma melhora de performance para a inclusão de vários objetos.
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
        // O metódo de gravar usando ADO usa como estratégia a criação de uma classe que representa o DAO
        // da classe a ser persistida (no caso, ProdutoDAO). No Entity, utilizamos uma classe que persista todas
        // as classes que devem ser persistidas, não apenas Produto. Essa classe é nomeada como Contexto da aplicação.
    }
}
