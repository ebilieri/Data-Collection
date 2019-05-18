using Dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dados.Collections
{
    public class DadosCollection : IDadosCollection
    {
        List<Collection> _listCollection;

        public DadosCollection()
        {
            _listCollection = new List<Collection>();
        }

        /// <summary>
        /// Complexidade 
        /// O(n) Find
        /// O(1) Add
        /// O(n log(n)) Orderby
        /// 
        /// O(n * 1) + n log(n)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="subIndex"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Add(string key, int subIndex, string value)
        {
            // verificar se o elemento ja existe na lista
            Collection itemCollection = _listCollection.Find(k => k.Key.ToLower() == key.ToLower()
                                                            && k.SubKey == subIndex
                                                            && k.Value.ToLower() == value.ToLower());

            if (itemCollection != null)
            {
                return false;
            }
            else
            {
                // adiciona elemento na lista
                _listCollection.Add(new Collection { Key = key, SubKey = subIndex, Value = value });

                // retornar lista ordernada
                _listCollection = _listCollection.OrderBy(k => k.Key).ThenBy(s => s.SubKey).ThenBy(v => v.Value).ToList();                

                return true;
            }
        }

        /// <summary>
        /// Complexidade 
        /// O(n) Select
        /// O(n) for
        /// O(1) Add    
        /// 
        /// O(n * n * 1)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public IList<string> Get(string key, int start, int end)
        {
            // retornar os valores da coleção key
            string[] arraySelect = (from nascimento in _listCollection
                                    where nascimento.Key.ToLower() == key.ToLower()
                                    select nascimento.Value).ToArray();

            if (start < 0)
                start = 0;
            else if (start > arraySelect.Length)
                start = arraySelect.Length - 1;

            if (end < 0)
                end = arraySelect.Length + end;
            else if (end > arraySelect.Length)
                end = arraySelect.Length - 1;

            // retornar os elementos dentro range informado
            var listValues = new List<string>();
            for (int i = start; i <= end; i++)
            {
                listValues.Add(arraySelect[i]);
            }

            return listValues;
        }

        /// <summary>
        /// Complexidade 
        /// O(n) Select
        /// O(1) IndexOf   
        /// 
        /// O(n * 1)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public long IndexOf(string key, string value)
        {
            // retornar os valores da coleção key
            string[] arraySelect = (from nascimento in _listCollection
                                    where nascimento.Key.ToLower() == key.ToLower()
                                    select nascimento.Value).ToArray();

            // retornar o indice do elemento value
            return Array.IndexOf(arraySelect, value);
        }

        /// <summary>
        /// Complexidade 
        /// O(n) Find
        /// O(n) Select
        /// 
        /// O(n * n)
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            // verifica se elemento existe  na lista
            Collection item = _listCollection.Find(k => k.Key.ToLower() == key.ToLower());

            if (item == null)
            {
                return false;
            }
            else
            {
                // retorna todos elementos diferentes da coleção key
                _listCollection = (from list in _listCollection
                                   where list.Key.ToLower() != key.ToLower()
                                   select list).ToList();

                return true;
            }
        }

        /// <summary>
        /// Complexidade 
        /// O(n) Find
        /// O(n) Remove   
        /// 
        /// O(n * n)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="subIndex"></param>
        /// <returns></returns>
        public bool RemoveValuesFromSubIndex(string key, int subIndex)
        {
            // verifica se o elemento existe na coleção
            Collection item = _listCollection.Find(k => k.Key.ToLower() == key.ToLower() && k.SubKey == subIndex);

            if (item == null)
            {
                return false;
            }
            else
            {
                do
                {
                    // enquanto existir elementos romove
                    _listCollection.Remove(item);
                    item = _listCollection.Find(k => k.Key.ToLower() == key.ToLower() && k.SubKey == subIndex);
                } while (item != null);

                return true;
            }
        }
    }
}
