using System;

/// <summary>
/// Summary description for CreateTable
/// </summary>
public class CreateTable
{
	public CreateTable()
	{
        string regExp = @"CREATE\s+TABLE\s+(\w+)\s+\(([^()]*)\);";
    }
}
