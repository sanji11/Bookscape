﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public interface SQLiteDBInterface
    {
        SQLiteAsyncConnection createSQLiteDB();
    }
}
