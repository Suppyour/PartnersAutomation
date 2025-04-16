namespace Backend.Models;

public class Category
{
    public const int MaxLength = 100;

    public Category(Guid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public static (Category Category, string Error) CreateCategory(Guid id, string name, string description)
    {
        if (string.IsNullOrEmpty(name) || name.Length > MaxLength)
            return (null, "Название категории не может быть пустым и не должно превышать 100 символов.");
        if (string.IsNullOrWhiteSpace(description))
        {
            return (null, "Описание категории не может быть пустым.");
        }

        var category = new Category(id, name, description);
        return (category, string.Empty);
    }
}