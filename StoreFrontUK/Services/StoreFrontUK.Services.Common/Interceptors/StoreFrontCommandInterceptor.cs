using System.Data.Common;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace StoreFrontUK.Services.StoreFrontUK.Services.Common.Interceptors;

public class StoreFrontCommandInterceptor : DbCommandInterceptor
{
    public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
    {
        Console.WriteLine($"EXECUTING SQL - {command.CommandText}");
        return base.ReaderExecuted(command, eventData, result);
    }
}