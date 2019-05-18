using Dados.Collections;
using Xunit;

namespace Dados.Tests
{
    public class DadosCollectionTest
    {
        private readonly IDadosCollection collection;

        public DadosCollectionTest()
        {
            collection = new DadosCollection();

            collection.Add("ano.nascimento", 1982, "pedro");
            collection.Add("ano.nascimento", 1983, "maria");
            collection.Add("ano.nascimento", 1982, "joao");
            collection.Add("ano.nascimento", 1983, "maria");// não deve inserir
            collection.Add("ano.nascimento", 1982, "pedro"); // não deve inserir
            collection.Add("ano.nascimento", 1983, "joão");
            collection.Add("ano.nascimento", 1983, "bruno");
            collection.Add("ano.nascimento", 1982, "arnaldo");
            collection.Add("teste", 1, "adiciona");
            collection.Add("teste", 1, "adiciona 2");
        }

        [Fact]
        public void TestAdd_Novo_Elemento()
        {
            // retorna true - adiciona novo elemento
            var key = "teste";
            var subKey = 100;
            var value = "adiciona";

            bool add = collection.Add(key, subKey, value);

            Assert.True(add);
        }


        [Fact]
        public void TestAdd_Elemento_Existente()
        {
            // retorna false. valor já existe na lista
            var key = "teste";
            var subKey = 1;
            var value = "adiciona";

            bool add = collection.Add(key, subKey, value);

            Assert.False(add);
        }

        [Fact]
        public void TestIndexOf_Elemento()
        {
            var key = "ano.nascimento";
            var value = "bruno";
            var valorEsperado = 3;

            var retorno = (int)collection.IndexOf(key, value);

            Assert.Equal(valorEsperado, retorno);
        }

        [Fact]
        public void TestGet_Lista_Elementos()
        {
            var nascimentos = collection.Get("ano.nascimento", 0, -1);
            var count = nascimentos.Count;
            var valorEsperado = 6;

            Assert.Equal(valorEsperado, count);
        }

        [Fact]
        public void TestRemove_Elemento()
        {
            var key = "teste";
            bool remove = collection.Remove(key);

            Assert.True(remove);
        }

        [Fact]
        public void TestRemove_Elemento_NaoExistente()
        {
            var key = "teste_teste";
            bool remove = collection.Remove(key);

            Assert.False(remove);
        }

        [Fact]
        public void TestRemoveValuesFromSubIndex()
        {
            var key = "ano.nascimento";
            var subKey = 1982;

            bool remove = collection.RemoveValuesFromSubIndex(key, subKey);

            Assert.True(remove);
        }
    }
}
