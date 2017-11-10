using System;
using Npgsql;

namespace LocalBookShopImport
{
    public class database
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=172.16.2.200;User Id=lcal_boot_shop; " + 
                                                     "Password=book123;Database=local_boot_shop;");
        
    }
}