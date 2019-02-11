using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Select
{
	public Select()
	{
        SELECT\s + (\w +|\*)\s + FROM\s + (\w +)\s + WHERE\s + (\w +)= (\w +);
    }
}
