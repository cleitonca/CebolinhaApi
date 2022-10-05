using CebolinhaApi.Models;

namespace CebolinhaApi.Repositorio
{
    public class RepositorioSimulado
    {
        private static List<Livro> livros;

        private static void GerarLivros()
        {
            livros = new List<Livro>();

            livros.Add(new Livro
            {
                Id = 1,
                Titulo = "Aprendendo ASP.NET Core",
                Autor = "Cleiton Araújo"

            });

            livros.Add(new Livro
            {
                Id = 2,
                Titulo = "Emagrecendo sem cortar o Arroz.",
                Autor = "Kálita Rodrigues"

            });

            livros.Add(new Livro
            {
                Id = 3,
                Titulo = "Aprendendo C#",
                Autor = "Cleiton Araújo"

            });

        }

        public static List<Livro> Livros
        {
            get 
            { 
                if (livros == null)
                {
                    GerarLivros();
                }
                return livros; 
            }
            set
            {
                livros = value;
            }
        }

    }
}
