using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Noticias.DAOModel
{
    interface DAO<T, K>
    {

        void insert(T t);

        void edit(T t);

        void deleted(T t);

        T find(K id);

        List<T> findAll();

    }
}
