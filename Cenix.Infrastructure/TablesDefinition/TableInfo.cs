namespace Cenix.Infrastructure.TablesDefinition;

public class TableInfo
{
    public string Name { get; }
    public string Schema { get; }
    public string Description { get; }

    public TableInfo(string name, string schema, string description)
    {
        Name = name;
        Schema = schema;
        Description = description;
    }
}