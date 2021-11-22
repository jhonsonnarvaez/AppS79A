using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppS79A
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();
    }
}
